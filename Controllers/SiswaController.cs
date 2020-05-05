using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataSekolahWithIdentity.Data;
using DataSekolahWithIdentity.Models;

namespace DataSekolahWithIdentity.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SiswaController : Controller
    {
        private ApplicationDbContext _context;

        public SiswaController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var siswa = _context.Siswa.Select(i => new {
                i.Id,
                i.NIM,
                i.Nama,
                i.KelasId
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(siswa, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Siswa();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Siswa.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Siswa.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Siswa not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.Siswa.FirstOrDefaultAsync(item => item.Id == key);

            _context.Siswa.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> KelasLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Kelas
                         orderby i.Tingkat
                         select new {
                             Value = i.KelasId,
                             Text = i.Tingkat
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Siswa model, IDictionary values) {
            string ID = nameof(Siswa.Id);
            string NIM = nameof(Siswa.NIM);
            string NAMA = nameof(Siswa.Nama);
            string KELAS_ID = nameof(Siswa.KelasId);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NIM)) {
                model.NIM = Convert.ToInt32(values[NIM]);
            }

            if(values.Contains(NAMA)) {
                model.Nama = Convert.ToString(values[NAMA]);
            }

            if(values.Contains(KELAS_ID)) {
                model.KelasId = Convert.ToInt32(values[KELAS_ID]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}