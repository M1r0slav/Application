using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {        
        private readonly ILogger<HomeController> _logger;
        private readonly DBSeeder dbSeeder;

        public HomeController(ILogger<HomeController> logger,DBSeeder dbSeeder)
        {
            _logger = logger;
            this.dbSeeder = dbSeeder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            dbSeeder.Seed();             
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
