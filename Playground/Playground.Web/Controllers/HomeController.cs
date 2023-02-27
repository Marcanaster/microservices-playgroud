using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Playground.Web.Models;
using Playground.Web.Services.IService;
using System.Diagnostics;

namespace Playground.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _service;
        private readonly ICartService _cartservice;

        public HomeController(ILogger<HomeController> logger, IProductService service, ICartService cartservice)
        {
            _logger = logger;
            _service = service;
            _cartservice = cartservice;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.FindAllProducts("");
            return View(products);
        }
        [Authorize]
        public async Task<IActionResult> Details( int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _service.GetProductById(id, token);
            return View(model);
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize]
        public async Task<IActionResult> Detailspost( ProductViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            CartViewModel cart = new()
            {
                CartHeader = new CartHeaderViewModel
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };
            CartDetailViewModel cartDetail = new CartDetailViewModel()
            {
                Count = model.Count,
                ProductId = model.Id,
                Product = await _service.GetProductById(model.Id, token)
            };
            List<CartDetailViewModel> cartDetails = new List<CartDetailViewModel>();
            cartDetails.Add(cartDetail);
            cart.CartDetails= cartDetails;
            var response = await _cartservice.AddItemToCart(cart, token);

            if(response != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}