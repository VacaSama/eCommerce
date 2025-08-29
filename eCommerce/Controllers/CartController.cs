using Azure.Core;
using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers;

public class CartController : Controller
{
    private readonly eCommerceDatabaseContext _context;

    //// constructor 
    public CartController(eCommerceDatabaseContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Product> allProducts = await _context.Products.ToListAsync();

        return View(allProducts);
    }

    /// <summary>
    /// This action will allow the user to add something to their cart 
    /// and pushes the product id to the cart 
    /// </summary>
    /// <returns></returns>
    //[HttpPost]
    //public IActionResult AddCart()
    //{
    //    return View();
    //}

    ///// <summary>
    ///// This action/method will allow the user to remove something from their 
    ///// cart. If the cart is empty a message will appear.
    ///// </summary>
    ///// <returns></returns>
    //[HttpPost]

    //public IActionResult RemoveCart()
    //{
    //    return View();
    //}
}
