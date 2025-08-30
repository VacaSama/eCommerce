using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class CustomerController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }


}
