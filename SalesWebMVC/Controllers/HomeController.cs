using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SalesWebMVC.Models.ViewModels;
using System.Threading.Tasks;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly SellerService _sellerService; //injeção de dependencia
        private readonly DepartmentService _departmentService;//injeção de dependencia para o department servic
        public HomeController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found!" });
            }

            return View(obj);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Salles Web MVC App from giovannijanial.";
            ViewData["Dev"] = "Giovanni Janial.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewData["Email"] = "giovannijanial@gmail.com";

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
