using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;
        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }
        public async Task <IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }
        //public IActionResult Create()
        //{

        //    var departaments = _departamentService.FindAll();
        //    var viewModel = new SellerFormViewModel { Departaments = departaments };
        //    return View(viewModel);
        //}
        public async Task <IActionResult> Create()
        {
            var viewModel = new SellerFormViewModel
            {
                Seller = new Seller(), // Initialize Seller to avoid null reference
                Departaments = await _departamentService.FindAllAsync()
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new { Seller = seller, Departaments = departaments };
                return View(viewModel);
            }
           await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }
        public async Task <IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Departament> departaments = await _departamentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new {Seller = seller, Departaments = departaments};
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id miss match" });
            }
            try
            {

                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public Microsoft.AspNetCore.Http.HttpContext GetHttpContext()
        {
            return HttpContext;
        }

        public IActionResult Error(string message, Microsoft.AspNetCore.Http.HttpContext httpContext)
        {

            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }





    }
}
