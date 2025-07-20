using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WIF.Core.Data;
using WIF.Core.Services;

namespace WIF.Base.Mvc.Controllers.API
{
    [AllowAnonymous]
    [Route("api/import/budgetbaker")]
    public class BudgetBakerAPIController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BBWalletImportService _bbWalletImportService;

        public BudgetBakerAPIController(
            ApplicationDbContext context,
            BBWalletImportService bbWalletImportService
        )
        {
            _context = context;
            _bbWalletImportService = bbWalletImportService;
        }

        [AllowAnonymous]
        [HttpGet("getRecords")]
        public async Task<IActionResult> GetRecords(string kendoListRequestString)
        {
            try
            {
                var response = await this._bbWalletImportService.GetBBWalletImportRecords(kendoListRequestString);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
