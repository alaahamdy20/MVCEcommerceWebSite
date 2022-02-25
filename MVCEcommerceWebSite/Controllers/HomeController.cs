using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCEcommerceWebSite.Data;
using MVCEcommerceWebSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEcommerceWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

      
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _dbContext)
        {
            _logger = logger;
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {

            return View(dbContext.Products.ToList());
        }
        public IActionResult Contact()
        {

            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
