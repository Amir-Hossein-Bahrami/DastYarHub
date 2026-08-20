using DastYarHub.Models;
using DastYarHub.Services;
using DastYarHub.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DastYarHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryApiService _categoryApiService;

        public HomeController(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetActiveCategoriesAsync();

            var viewModel = new HomeViewModel
            {
                Categories = categories
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
