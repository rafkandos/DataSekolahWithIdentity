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
    public class KelasController : Controller
    {
        private ApplicationDbContext _context;

        public KelasController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var kelas = _context.Kelas.Select(i => new {
                i.KelasId,
                i.Tingkat,
                i.Jurusan,
                i.WaliKelas
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "KelasId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(kelas, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Kelas();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Kelas.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.KelasId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Kelas.FirstOrDefaultAsync(item => item.KelasId == key);
            if(model == null)
                return StatusCode(409, "Kelas not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.Kelas.FirstOrDefaultAsync(item => item.KelasId == key);

            _context.Kelas.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Kelas model, IDictionary values) {
            string KELAS_ID = nameof(Kelas.KelasId);
            string TINGKAT = nameof(Kelas.Tingkat);
            string JURUSAN = nameof(Kelas.Jurusan);
            string WALI_KELAS = nameof(Kelas.WaliKelas);

            if(values.Contains(KELAS_ID)) {
                model.KelasId = Convert.ToInt32(values[KELAS_ID]);
            }

            if(values.Contains(TINGKAT)) {
                model.Tingkat = Convert.ToString(values[TINGKAT]);
            }

            if(values.Contains(JURUSAN)) {
                model.Jurusan = Convert.ToString(values[JURUSAN]);
            }

            if(values.Contains(WALI_KELAS)) {
                model.WaliKelas = Convert.ToString(values[WALI_KELAS]);
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