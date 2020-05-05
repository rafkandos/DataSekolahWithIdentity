using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataSekolahWithIdentity.Data;
using Newtonsoft.Json;

namespace DataSekolahWithIdentity.Controllers
{
    public class KepsekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KepsekController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string GetData()
        {
            List<Dictionary<String, Int32>> _list = new List<Dictionary<string, int>>();

            var dt = _context.Kelas.ToList();
            foreach (var d in dt)
            {
                var dtSiswa = _context.Siswa.Where(s => s.KelasId == d.KelasId).ToList();
                Dictionary<string, int> dict = new Dictionary<string, int>();
                dict.Add("arg", Convert.ToInt32(d.Tingkat));
                dict.Add("val", dtSiswa.Count());
                _list.Add(dict);
            }

            return JsonConvert.SerializeObject(_list);
        }
    }
}