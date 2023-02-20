using Microsoft.AspNetCore.Mvc;
using Playground.Web.Models;
using Playground.Web.Services.IService;

namespace Playground.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _service.FindAllProducts();
            return View(products);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.CreateProduct(model);
                if (response != null) return RedirectToAction(nameof(ProductIndex));

            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var model = await _service.GetProductById(id);
            if (model != null)
            {
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.UpdateProduct(model);
                if (response != null) return RedirectToAction(nameof(ProductIndex));

            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var model = await _service.GetProductById(id);
            if (model != null)
            {
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var response = await _service.DeleteProduct(model.Id);
            if (response) return RedirectToAction(nameof(ProductIndex));

            return View(model);
        }
    }
}
