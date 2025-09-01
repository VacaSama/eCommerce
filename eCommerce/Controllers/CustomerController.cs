using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var newCustomer = new Customer()
            {
                FirstName = reg.FirstName,
                LastName = reg.LastName,
                Email = reg.Email,
                Password = reg.Password,
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


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (!ModelState.IsValid || login == null)
        {
            TempData["LoginMessage"] = "Please fill out all required fields.";
            return View(login);
        }

        var loggedInCustomer = await _context.Customers
            .SingleOrDefaultAsync(c => c.Email == login.Email && c.Password == login.Password);

        if (loggedInCustomer != null)
        {
            TempData["LoginMessage"] = $"Welcome back, {loggedInCustomer.FirstName}!";
            // You could store session info here if needed
            return RedirectToAction("Index", "Home");
        }
        else
        {
            TempData["LoginMessage"] = "Invalid email or password.";
            return View(login);
        }

    }

}
