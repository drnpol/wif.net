using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WIF.Core.Data;
using WIF.Core.Models;
using WIF.Core.Services;

namespace WIF.Base.Mvc.Controllers
{
    [Authorize]
    public class ImportController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BBWalletImportService _bbWalletImportService;

        public ImportController(
            ApplicationDbContext context,
            BBWalletImportService bbWalletImportService
        )
        {
            _context = context;
            _bbWalletImportService = bbWalletImportService;
        }

        // GET: Import
        public async Task<IActionResult> Index()
        {
              return _context.BBWalletImports != null ? 
                          View(await _context.BBWalletImports.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BBWalletImports'  is null.");
        }

        public async Task<IActionResult> GetBBWalletImportRecords(string kendoListRequestString)
        {
            var response = await this._bbWalletImportService.GetBBWalletImportRecords(kendoListRequestString);
            return Ok(response);
        }

        // GET: Import/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.BBWalletImports == null)
            {
                return NotFound();
            }

            var bBWalletImport = await _context.BBWalletImports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bBWalletImport == null)
            {
                return NotFound();
            }

            return View(bBWalletImport);
        }

        // GET: Import/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Import/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Uid,UserUid,Account,Category,Currency,Amount,RefCurrencyAmount,Type,PaymentType,PaymentTypeLocal,Note,Date,GpsLatitude,GpsLongitude,GpsAccuracyInMeters,WarrantyInMonth,Transfer,Payee,Labels,EnvelopeId,CustomCategory,CreatedAt,CreatedByUserUid,UpdatedAt,UpdatedByUserUid")] BBWalletImport bBWalletImport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bBWalletImport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bBWalletImport);
        }

        // GET: Import/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.BBWalletImports == null)
            {
                return NotFound();
            }

            var bBWalletImport = await _context.BBWalletImports.FindAsync(id);
            if (bBWalletImport == null)
            {
                return NotFound();
            }
            return View(bBWalletImport);
        }

        // POST: Import/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Uid,UserUid,Account,Category,Currency,Amount,RefCurrencyAmount,Type,PaymentType,PaymentTypeLocal,Note,Date,GpsLatitude,GpsLongitude,GpsAccuracyInMeters,WarrantyInMonth,Transfer,Payee,Labels,EnvelopeId,CustomCategory,CreatedAt,CreatedByUserUid,UpdatedAt,UpdatedByUserUid")] BBWalletImport bBWalletImport)
        {
            if (id != bBWalletImport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bBWalletImport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BBWalletImportExists(bBWalletImport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bBWalletImport);
        }

        // GET: Import/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.BBWalletImports == null)
            {
                return NotFound();
            }

            var bBWalletImport = await _context.BBWalletImports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bBWalletImport == null)
            {
                return NotFound();
            }

            return View(bBWalletImport);
        }

        // POST: Import/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.BBWalletImports == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BBWalletImports'  is null.");
            }
            var bBWalletImport = await _context.BBWalletImports.FindAsync(id);
            if (bBWalletImport != null)
            {
                _context.BBWalletImports.Remove(bBWalletImport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BBWalletImportExists(long id)
        {
          return (_context.BBWalletImports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
