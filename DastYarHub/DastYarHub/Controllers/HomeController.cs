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
        private readonly IToolUsageService _toolUsageService;

        public HomeController(ICategoryApiService categoryApiService, IToolUsageService toolUsageService)
        {
            _categoryApiService = categoryApiService;
            _toolUsageService = toolUsageService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetActiveCategoriesAsync();
            var popularTolls = await _toolUsageService.GetPopularToolsAsync();

            var viewModel = new HomeViewModel
            {
                Categories = categories,
                PopularTools = popularTolls
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
