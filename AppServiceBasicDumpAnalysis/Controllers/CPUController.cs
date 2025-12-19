using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppServiceBasicDumpAnalysis.Controllers
{
    public class CPUController : Controller
    {


        // public HighCpuService _cpuService;
        public static bool repro;

        public CPUController()
        {
            //_cpuService = cpuService;
            repro = false;
        }

       
        [HttpPost]
        public IActionResult StartCPU()
        {
            //_cpuService.Start();
            //return Json(new { ok = true, running = _cpuService.IsRunning });
            //return 
            repro = true;
            doloop();

            return View();

        }
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
        public IActionResult StopCPU()
        {
            //await _cpuService.StopAsync();
            //return Json(new { ok = true, running = _cpuService.IsRunning });
            repro = false;
            return View();
        }
    }

}
