using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSekolahWithIdentity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataSekolahWithIdentity.Controllers
{
    public class KepsekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KepsekController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dtKelas = _context.Kelas.ToList();
            ViewBag.Kelas = dtKelas.Count();
            var dtSiswa = _context.Siswa.ToList();
            ViewBag.Siswa = dtSiswa.Count();
            return View();
        }
    }
}