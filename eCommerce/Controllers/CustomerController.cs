using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class CustomerController : Controller
{

    private readonly eCommerceDatabaseContext _context;


    // constructor
    public CustomerController(eCommerceDatabaseContext context)
    {
        _context = context;
    }
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(RegistrationViewModel reg)
    {
        if (ModelState.IsValid)
        {
            Customer newCustomer = new()
            {
                FirstName = reg.FirstName,
                LastName = reg.LastName,
                Email = reg.Email,
                Password = reg.Password,
                ConfirmPassword = reg.ConfirmPassword,
                Phone = reg.Phone,
                StreetAddress = reg.StreetAddress,
                City = reg.City,
                State = reg.State
            };
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            //placeholer later we an redirect to the login page
            return RedirectToAction("Index", "Home");
        }
        return View(reg);
    }

    public IActionResult Login()
    {
        return View();
    }


}
