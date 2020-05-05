using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataSekolahWithIdentity.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DataSekolahWithIdentity.Data;
using System.IO;

namespace DataSekolahWithIdentity.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewBag.Role = HttpContext.Session.GetString("Role");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //private List<Siswa> GetDataFromExcelFile(Stream stream)
        //{
        //    var _list = new List<Siswa>();
        //    try
        //    {
        //        using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
        //        {
        //            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
        //            {
        //                ConfigureDataTable = _ => new ExcelDataTableConfiguration
        //                {
        //                    UseHeaderRow = true
        //                }
        //            });

        //            if (dataSet.Tables.Count > 0)
        //            {
        //                var dataTable = dataSet.Tables[0];
        //                foreach(DataRow obj in dataTable.Rows)
        //                {
        //                    if(obj.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
        //                    _list.Add(new Siswa()
        //                    {
        //                        NIM = Convert.ToInt32(obj["NIM"].ToString()),
        //                        Nama = obj["Nama"].ToString(),
        //                        KelasId = Convert.ToInt32(obj["KelasId"].ToString())
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return _list;
        //}

        //[HttpPost]
        //public IActionResult AddSiswa()
        //{
        //    try
        //    {
        //        IFormFile file = Request.Form.Files[0];
        //        string folderName = "Upload";
        //        string webRootPath = _hostingEnvironment.WebRootPath;
        //        string newPath = Path.Combine(webRootPath, folderName);
        //        StringBuilder sb = new StringBuilder();
        //        if (!Directory.Exists(newPath))
        //        {
        //            Directory.CreateDirectory(newPath);
        //        }

        //        string fileEx = Path.GetExtension(file.FileName);
        //        ISheet sheet;
        //        string fullPath = Path.Combine(newPath, file.FileName);

        //        return Json(new { Status = 0, Message = "Sukses", Lokasi = fullPath  });

        //        //Validate uploaded file and return error.
        //        //if (fileEx != ".xls" && fileEx != ".xlsx")
        //        //{
        //        //    ViewBag.Message = "Please select the excel file with .xls or .xlsx extension";
        //        //    return View();
        //        //}

        //        //string excelConString = string.Empty;
        //        //switch (fileEx)
        //        //{
        //        //    case ".xls":
        //        //        excelConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
        //        //        break;
        //        //    //If uploaded file is Excel 2007 and above
        //        //    case ".xlsx":
        //        //        excelConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
        //        //        break;
        //        //}

        //        //DataTable dt = new DataTable();
        //        //excelConString = string.Format(excelConString, fullPath);

        //        //using(oledbconnection )

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Status = 0, Message = ex.Message });
        //    }
        //}

        //[HttpPost]
        //public string BuatTes(IFormFile files)
        //{
        //    List<Dictionary<String, String>> _list = new List<Dictionary<string, string>>();

        //    string folderName = "Upload";
        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    string newPath = Path.Combine(webRootPath, folderName);
        //    StringBuilder sb = new StringBuilder();
        //    if (!Directory.Exists(newPath))
        //    {
        //        Directory.CreateDirectory(newPath);
        //    }

        //    //string fileEx = Path.GetExtension(file.FileName);
        //    string fullPath = Path.Combine(newPath, files.FileName);

        //    //return Json(new { Status = 0, Message = "Sukses", Lokasi = fullPath });
        //    Dictionary<string, string> dict = new Dictionary<string, string>();
        //    dict.Add("status", "Sukses");
        //    dict.Add("path", fullPath);
        //    _list.Add(dict);

        //    return JsonConvert.SerializeObject(_list);
        //}
    }
}
