using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
