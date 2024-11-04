using EventForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ?
                "Good Morning" : "Good Afternoon"; 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult FilledForm()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult FilledForm(GuestResponse guestResponse )
        {   
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse); 
        }
        
        public IActionResult ListResponses() 
        {
            return View(Repository.Responses.Where
                (r=> r.WillAttend == true )); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
