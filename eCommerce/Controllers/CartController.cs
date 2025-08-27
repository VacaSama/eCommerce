using eCommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;

namespace eCommerce.Controllers;

public class CartController : Controller
{
    private readonly eCommerceDatabaseContext _context;

    //// constructor 
    public CartController(eCommerceDatabaseContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }


    /// <summary>
    /// This action will allow the user to add something to their cart 
    /// and pushes the product id to the cart 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddCart(int id)
    {
        return View();
    }


    /// <summary>
    /// This action/method will allow the user to remove something from their 
    /// cart. If the cart is empty a message will appear.
    /// </summary>
    /// <returns></returns>
    [HttpDelete]

    public IActionResult RemoveCart()
    {
        return View();
    }
}
