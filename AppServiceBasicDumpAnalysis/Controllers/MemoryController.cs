using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Net.Http;
using System.Web;

namespace AppServiceBasicDumpAnalysis.Controllers
{
    public class MemoryController : Controller
    {
        static volatile int id = 0;
        static HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            /* string schema = Request.IsSecureConnection ? "https" : "http";
             string serverName = Request.ServerVariables["server_name"];
             string serverPort = Request.ServerVariables["server_port"];
             string path = Request.ApplicationPath;
             string urlString = $"{schema}://{serverName}:{serverPort}{path}Repro/Cached/{id++}";
             string response = await client.GetStringAsync(urlString);

             ViewData["URL"] = urlString;
             ViewData["Response"] = response;
            */
            return View();
        }
        
    }
}
