// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WIF.Base.Mvc.Models.AccountViewModels;
using WIF.Core.Data;
using WIF.Core.Models;
using WIF.Core.Services;

namespace WIF.Base.Mvc.Controllers.Import
{
    [Authorize]
    [Route("Import/BudgetBaker")]
    public class BudgetBakerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BBWalletImportService _bbWalletImportService;

        public BudgetBakerController(
            ApplicationDbContext context,
            BBWalletImportService bbWalletImportService
        )
        {
            _context = context;
            _bbWalletImportService = bbWalletImportService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.BBWalletImports != null ?
                          View("/Views/Import/BudgetBaker/Index.cshtml", await _context.BBWalletImports.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BBWalletImports'  is null.");
        }
        
        [HttpGet("Records")]
        public async Task<IActionResult> Records()
        {
            return View("/Views/Import/BudgetBaker/Records.cshtml");
        }

        [HttpGet("GetRecords")]
        public async Task<IActionResult> GetRecords(string kendoListRequestString)
        {
            try
            {
                var response = await this._bbWalletImportService.GetBBWalletImportRecords(kendoListRequestString, true);
                return Ok(response);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }
    }
}
