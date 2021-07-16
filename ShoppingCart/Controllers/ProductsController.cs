using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using ShoppingCart.Repository.IRepository;

namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Product.GetAll().ToList<Product>());
            
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    _unitOfWork.Product.Add(product);

                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            Product product = new Product();
            if (id == 0)
            {
                return View(product);
            }

            product = _unitOfWork.Product.GetFirstOrDefault(u => u.ProductID == id);
            if (product.ProductID != 0)
            {
                _unitOfWork.Product.Remove(product);

            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            Product product = new Product();
            if (id == null)
            {
                //this is for create
                return View(product);
            }
            //this is for edit
            product = _unitOfWork.Product.Get(id.GetValueOrDefault());
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    _unitOfWork.Product.Add(product);

                }
                else
                {
                    _unitOfWork.Product.Update(product);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        

    }
}
