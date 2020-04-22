using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataSekolahWithIdentity.Controllers
{
    public class KepsekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}