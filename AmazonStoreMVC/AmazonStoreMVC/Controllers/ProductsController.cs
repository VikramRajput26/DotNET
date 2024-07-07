using AmazonStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using AmazonStoreMVC.Services;

namespace ProductsOnline.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(model);
                return RedirectToAction("GetProducts");
            }
            return View(model);
        }

        public IActionResult GetProducts()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("GetProducts");
        }

        public IActionResult GetById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Update() {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Product model)
        {
            
                _productService.Update(model);
                return RedirectToAction("GetProducts");
           
            
        }


    }
}
