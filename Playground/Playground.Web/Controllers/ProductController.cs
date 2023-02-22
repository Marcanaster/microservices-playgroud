using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Playground.Web.Models;
using Playground.Web.Services.IService;
using Playground.Web.Utils;

namespace Playground.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var products = await _service.FindAllProducts(token);
            return View(products);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _service.CreateProduct(model, token);
                if (response != null) return RedirectToAction(nameof(ProductIndex));

            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _service.GetProductById(id, token);
            if (model != null)
            {
                return View(model);
            }

            return NotFound();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _service.UpdateProduct(model, token);
                if (response != null) return RedirectToAction(nameof(ProductIndex));

            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _service.GetProductById(id, token);
            if (model != null)
            {
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _service.DeleteProduct(model.Id, token);
            if (response) return RedirectToAction(nameof(ProductIndex));

            return View(model);
        }
    }
}
