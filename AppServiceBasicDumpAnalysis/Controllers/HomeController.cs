using AppServiceBasicDumpAnalysis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Diagnostics;

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

        static volatile int id = 0;
        static HttpClient client = new HttpClient();
        public async Task<IActionResult> Memory()
        {
            // 假设在 Controller / Minimal API 里可以直接访问 HttpContext / Request
            var scheme = Request.Scheme;                 // "http" or "https"
            var host = Request.Host.Host;                // server name
            var port = Request.Host.Port;                // nullable int
            var pathBase = Request.PathBase.Value ?? ""; // 相当于 ApplicationPath（如果有虚拟目录）

            // 如果没有显式端口（80/443 或被隐藏），这里根据 scheme 给一个默认值
            var actualPort = port ?? (string.Equals(scheme, "https", StringComparison.OrdinalIgnoreCase) ? 443 : 80);

            // 保持你原来的拼接逻辑
            var urlString = $"{scheme}://{host}:{actualPort}{pathBase}/Home/Cached/{id++}";

            var response = await client.GetStringAsync(urlString);

            ViewData["URL"] = urlString;
            ViewData["Response"] = response;
            return View();
        }

        [HttpGet]
        [OutputCache(Duration = 3 * 24 * 60 * 60, VaryByQueryKeys = new[] { "id" })]
        public IActionResult Cached(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ThrowException()
        {
            // ViewBag.IsRunning = _cpuService.IsRunning;
            //doloop();
            throw new InvalidOperationException("This is a test exception for dump analysis.");
            //return View();
        }
        public IActionResult Crash()
        {
            // ViewBag.IsRunning = _cpuService.IsRunning;
            //doloop();
            Environment.FailFast("This is a test crash for dump analysis.");
            return View();
        }
    }
}
