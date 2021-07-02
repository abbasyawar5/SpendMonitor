using Microsoft.AspNetCore.Mvc;
using SpendMonitor.Models;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinancialStatsService _stateService;

        public HomeController(IFinancialStatsService stateService)
        {
            _stateService = stateService;
        }
        public IActionResult Index()
        {
            var lastSixMonths = Enumerable.Range(0, 7).Select(i => DateTime.Now.AddMonths(i - 6).ToString("MM/yyyy"));

            foreach (var monthAndYear in lastSixMonths)
            {
                //_stateService.GetStats();
            }
            
            return View();
        }
    }
}
