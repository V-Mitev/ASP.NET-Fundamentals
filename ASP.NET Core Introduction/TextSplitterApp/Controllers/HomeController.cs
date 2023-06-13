﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp.Models;
using TextSplitterApp.ViewModels.Home;

namespace TextSplitterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextViewModel textViewModel)
        {
            return View(textViewModel);
        }

        [HttpPost]
        public IActionResult Split(TextViewModel textViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", textViewModel);
            }

            var splitTextArray = textViewModel.Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            textViewModel.SplitText = string.Join(Environment.NewLine, splitTextArray);

            return RedirectToAction("Index", textViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}