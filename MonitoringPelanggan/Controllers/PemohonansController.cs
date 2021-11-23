using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonitoringPelanggan.Models;

namespace MonitoringPelanggan.Controllers
{
    public class PemohonansController : Controller
    {
        private readonly MonitoringPlgContext _context;

        public PemohonansController(MonitoringPlgContext context)
        {
            _context = context;
        }

        // GET: Pemohonans
        public async Task<IActionResult> Index()
        {
            var monitoringPlgContext = _context.Pemohonans.Include(p => p.IdPetugasNavigation);
            return View(await monitoringPlgContext.ToListAsync());
        }

        // GET: Pemohonans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemohonan = await _context.Pemohonans
                .Include(p => p.IdPetugasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pemohonan == null)
            {
                return NotFound();
            }

            return View(pemohonan);
        }

        // GET: Pemohonans/Create
        public IActionResult Create()
        {
            ViewData["IdPetugas"] = new SelectList(_context.Petugas, "IdPetugas", "IdPetugas");
            return View();
        }

        // POST: Pemohonans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NoKk,NamaPenuh,Alamat,NoHp,Kelayakan,IdPetugas,Proses")] Pemohonan pemohonan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pemohonan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPetugas"] = new SelectList(_context.Petugas, "IdPetugas", "IdPetugas", pemohonan.IdPetugas);
            return View(pemohonan);
        }

        // GET: Pemohonans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemohonan = await _context.Pemohonans.FindAsync(id);
            if (pemohonan == null)
            {
                return NotFound();
            }
            ViewData["IdPetugas"] = new SelectList(_context.Petugas, "IdPetugas", "IdPetugas", pemohonan.IdPetugas);
            return View(pemohonan);
        }

        // POST: Pemohonans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NoKk,NamaPenuh,Alamat,NoHp,Kelayakan,IdPetugas,Proses")] Pemohonan pemohonan)
        {
            if (id != pemohonan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pemohonan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PemohonanExists(pemohonan.Id))
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
            ViewData["IdPetugas"] = new SelectList(_context.Petugas, "IdPetugas", "IdPetugas", pemohonan.IdPetugas);
            return View(pemohonan);
        }

        // GET: Pemohonans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemohonan = await _context.Pemohonans
                .Include(p => p.IdPetugasNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pemohonan == null)
            {
                return NotFound();
            }

            return View(pemohonan);
        }

        // POST: Pemohonans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pemohonan = await _context.Pemohonans.FindAsync(id);
            _context.Pemohonans.Remove(pemohonan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PemohonanExists(int id)
        {
            return _context.Pemohonans.Any(e => e.Id == id);
        }
    }
}
