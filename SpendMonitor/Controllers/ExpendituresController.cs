

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpendMonitor.Repositories;
using SpendMonitor.Repositories.Interfaces;
using SpendMonitor.Services;
using SpendMonitor.Services.Interfaces;

namespace SpendMonitor.Controllers
{
    public class ExpendituresController : Controller
    {

        private readonly IExpenditureService _expenditureService;
        public ExpendituresController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        public IActionResult Index()
        {
            var expenditures = _expenditureService.GetAllExpenditures();
            return View(expenditures);
        }

        // GET: ExpendituresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpendituresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpendituresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpendituresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpendituresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpendituresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpendituresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
