using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Controllers
{
    public class StubbyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
