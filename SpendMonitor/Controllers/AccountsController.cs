using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpendMonitor.Models;
using SpendMonitor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendMonitor.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountService _accService;

        public AccountsController(IAccountService accService)
        {
            _accService = accService;
        }
        public IActionResult Index()
        {

            return View(_accService.GetAllAccounts().ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AccountBankName,AccountIsDebit,AccountBalance")] TblAccount account)
        {
            if (ModelState.IsValid)
            {
                _accService.AddAccount(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public IActionResult Transfer()
        {
            ViewData["FromAccounts"] = new SelectList(_accService.GetAllAccounts(), "AccountId", "AccountBankName");
            ViewData["ToAccounts"] = new SelectList(_accService.GetAllAccounts(), "AccountId", "AccountBankName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                int fromAccountValue = int.Parse(Request.Form["FromAccount"].ToString());
                int toAccountValue = int.Parse(Request.Form["ToAccount"].ToString());
                string strTransferAmount = Request.Form["TransferAmount"];
                decimal transferAmount = 0;
                if (strTransferAmount != string.Empty)
                    transferAmount = decimal.Parse(strTransferAmount);

                if (fromAccountValue == toAccountValue)
                {
                    ModelState.AddModelError("Error", "From and To Accounts cannot be the same");
                    return ReturnToTransfer();
                }

                try
                {
                    if (transferAmount > 0)
                    {
                        if (_accService.TransferBetweenAccounts(fromAccountValue, toAccountValue, transferAmount))
                            return RedirectToAction(nameof(Index));
                        else
                        {
                            ModelState.AddModelError("Error", "Something went wrong");
                            return ReturnToTransfer();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Transfer Amount Is 0");
                        return ReturnToTransfer();
                    }
                }
                catch (Exception Ex)
                {
                    ModelState.AddModelError("Error", Ex.ToString());
                    return ReturnToTransfer();
                }
            }
            return View();
        }

        public IActionResult ReturnToTransfer()
        {
            ViewData["FromAccounts"] = new SelectList(_accService.GetAllAccounts(), "AccountId", "AccountBankName");
            ViewData["ToAccounts"] = new SelectList(_accService.GetAllAccounts(), "AccountId", "AccountBankName");
            return View();
        }
    }
}
