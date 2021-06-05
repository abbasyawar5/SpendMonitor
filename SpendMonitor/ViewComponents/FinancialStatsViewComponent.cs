using Microsoft.AspNetCore.Mvc;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.ViewComponents
{
    public class FinancialStatsViewComponent : ViewComponent
    {
        private readonly IFinancialStatsService _financialStatsService;

        public FinancialStatsViewComponent(IFinancialStatsService financialService) => _financialStatsService = financialService;

        public Task<IViewComponentResult> InvokeAsync()
        {
            var stats = _financialStatsService.GetStats();
            return Task.FromResult<IViewComponentResult>(View(stats));
        }
    }
}
