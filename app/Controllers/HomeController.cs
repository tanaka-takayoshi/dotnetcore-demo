using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using System.Runtime.InteropServices;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Crash()
        {
            var p = Marshal.AllocHGlobal(1);
            for (var _ = 0u; _ < 100_000_000; _++)
            {
                p = new IntPtr(p.ToInt64() + 1);
                Marshal.WriteByte(p, 0xff);
            }
            return Ok();
        }
    }
}
