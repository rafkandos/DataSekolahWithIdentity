using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataSekolahWithIdentity.Data;
using DataSekolahWithIdentity.Models;

namespace DataSekolahWithIdentity.Controllers
{
    public class SiswaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiswaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Siswa
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Siswa.Include(s => s.Kelas);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Siswa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .Include(s => s.Kelas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // GET: Siswa/Create
        public IActionResult Create()
        {
            //ViewData["KelasId"] = new SelectList(_context.Kelas, "KelasId", "KelasId");
            ViewBag.Kelas = _context.Kelas.ToList();
            return View();
        }

        // POST: Siswa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NIM,Nama,KelasId")] Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KelasId"] = new SelectList(_context.Kelas, "KelasId", "KelasId", siswa.KelasId);
            return View(siswa);
        }

        // GET: Siswa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa.FindAsync(id);
            if (siswa == null)
            {
                return NotFound();
            }
            ViewBag.Kelas = _context.Kelas.ToList();
            return View(siswa);
        }

        // POST: Siswa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NIM,Nama,KelasId")] Siswa siswa)
        {
            if (id != siswa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiswaExists(siswa.Id))
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
            ViewData["KelasId"] = new SelectList(_context.Kelas, "KelasId", "KelasId", siswa.KelasId);
            return View(siswa);
        }

        // GET: Siswa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswa
                .Include(s => s.Kelas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // POST: Siswa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siswa = await _context.Siswa.FindAsync(id);
            _context.Siswa.Remove(siswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiswaExists(int id)
        {
            return _context.Siswa.Any(e => e.Id == id);
        }
    }
}
