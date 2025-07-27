// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WIF.Base.Mvc.Models.AccountViewModels;
using WIF.PortfolioManager.Persistence;
using WIF.PortfolioManager.Application.Services;

namespace WIF.Base.Mvc.Controllers.Import
{
    [Authorize]
    [Route("import/budgetbaker")]
    public class BudgetBakerController : Controller
    {
        private readonly ApplicationPersistenceDbContext _context;
        private readonly BBWalletImportService _bbWalletImportService;

        public BudgetBakerController(
            ApplicationPersistenceDbContext context,
            BBWalletImportService bbWalletImportService
        )
        {
            _context = context;
            _bbWalletImportService = bbWalletImportService;
        }

        //[HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.BBWalletImports != null ?
                          View("/Views/Import/BudgetBaker/Index.cshtml", await _context.BBWalletImports.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BBWalletImports'  is null.");
        }
        
        [HttpGet("records")]
        public async Task<IActionResult> Records()
        {
            return View("/Views/Import/BudgetBaker/Records.cshtml");
        }
        public async Task<IActionResult> Upload()
        {
            return View("/Views/Import/BudgetBaker/Records.cshtml");
        }
    }
}
