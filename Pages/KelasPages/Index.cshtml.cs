using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataSekolahWithIdentity.Data;
using DataSekolahWithIdentity.Models;

namespace DataSekolahWithIdentity.Pages.KelasPages
{
    public class IndexModel : PageModel
    {
        private readonly DataSekolahWithIdentity.Data.ApplicationDbContext _context;

        public IndexModel(DataSekolahWithIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Kelas> Kelas { get;set; }

        public async Task OnGetAsync()
        {
            Kelas = await _context.Kelas.ToListAsync();
        }
    }
}
