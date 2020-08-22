using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicCardsWithAspCoreRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicCardsWithAspCoreRazor.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository _productsRepository ;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        [Route("")]
        [Route("Products")]
        public IActionResult Products()
        {
            IEnumerable<Products> products = _productsRepository.GetAllProducts();
            return View("~/Views/Products.cshtml", products);
        }

        // you can use the same controller for the two views just need an if condition and return view
        [Route("Products1")]
        public IActionResult ProductsHorizontal()
        {
            IEnumerable<Products> products = _productsRepository.GetAllProducts();
            return View("~/Views/ProductsHorizontal.cshtml", products);
        }
    }
}
