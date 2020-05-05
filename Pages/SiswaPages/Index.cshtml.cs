using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataSekolahWithIdentity.Data;
using DataSekolahWithIdentity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text;
using OfficeOpenXml;

namespace DataSekolahWithIdentity.Pages.SiswaPages
{
    public class IndexModel : PageModel
    {
        private readonly DataSekolahWithIdentity.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public IndexModel(IHostingEnvironment hostingEnvironment, DataSekolahWithIdentity.Data.ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        public IList<Siswa> Siswa { get;set; }

        public async Task OnGetAsync()
        {
            Siswa = await _context.Siswa
                .Include(s => s.Kelas).ToListAsync();
        }

        //public ActionResult OnPostDownloadFile()
        //{
        //    return File("~/wwwroot/Template Add Siswa.xlsx");
        //}

        public async Task<IActionResult> OnPostAsync(IFormFile importFile)
        {
            var fileName = Path.GetFileName(importFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await importFile.CopyToAsync(fileStream);
            }

            FileInfo file = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Lembar1"];
                int totalRows = workSheet.Dimension.Rows;

                List<Siswa> customerList = new List<Siswa>();

                for (int i = 2; i <= totalRows; i++)
                {
                    customerList.Add(new Siswa
                    {
                        NIM = Convert.ToInt32(workSheet.Cells[i, 1].Value.ToString()),
                        Nama = workSheet.Cells[i, 2].Value.ToString(),
                        KelasId = Convert.ToInt32(workSheet.Cells[i, 3].Value.ToString())
                    });
                }

                _context.Siswa.AddRange(customerList);
                _context.SaveChanges();
            }

            return Redirect("~/SiswaPages");
        }
    }
}
