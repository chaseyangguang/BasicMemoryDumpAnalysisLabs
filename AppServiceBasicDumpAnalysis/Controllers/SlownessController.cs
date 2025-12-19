using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AppServiceBasicDumpAnalysis.Controllers
{
    public class SlownessController : Controller
    {
        public static bool repro;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StartSlowness()
        {
            //await _cpuService.StopAsync();
            repro = true;
            //return Json(new { ok = true, running = _cpuService.IsRunning });
            if (repro)
            {
                Thread.Sleep(30000);
            }
            //repro = false;
            return View();
        }
        [HttpPost]
        public IActionResult StopSlowness()
        {
            //await _cpuService.StopAsync();
            //return Json(new { ok = true, running = _cpuService.IsRunning });
            repro = false;
            return View();
        }
    }
}
