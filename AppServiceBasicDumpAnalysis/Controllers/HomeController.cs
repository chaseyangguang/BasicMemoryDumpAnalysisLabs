using System.Diagnostics;
using AppServiceBasicDumpAnalysis.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppServiceBasicDumpAnalysis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static bool repro = false;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Slowness()
        {
            // ViewBag.IsRunning = _cpuService.IsRunning;
            //doloop();
            Thread.Sleep(30000);
            return View();
        }
        
        public IActionResult CPU()
         {
             // ViewBag.IsRunning = _cpuService.IsRunning;
             //doloop();
             return View();
         }
        /*
        public void doloop()
         {
             while (repro == true)
             {
                 for (int i = 0; i < 10000; i++)
                 {
                     Thread.Yield();
                 }
             }
         }

         [HttpPost]
         public IActionResult StartCPU()
         {
             repro = true;
             // ViewBag.IsRunning = _cpuService.IsRunning;
             doloop();
             return View();
         }

         [HttpPost]
         public IActionResult StopCPU()
         {
             repro = false;
             return View();

         }
         */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
