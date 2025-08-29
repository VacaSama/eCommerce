using Azure.Core;
using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        var cart = TempData["Cart"] as List<CartItem> ?? new List<CartItem>();
        TempData.Keep("Cart");

        decimal subtotal = cart.Sum(item => item.Price * item.Quantity);
        decimal shipping = 3.00m; // or use dropdown logic
        decimal total = subtotal + shipping;

        ViewBag.Subtotal = subtotal;
        ViewBag.Shipping = shipping;
        ViewBag.Total = total;

        return View(cart);
    }

    public IActionResult AddCart(int productId)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
        if (product == null) return NotFound();

        List<CartItem> cart = TempData["Cart"] as List<CartItem> ?? new List<CartItem>();

        var existingItem = cart.FirstOrDefault(ci => ci.ProductId == productId);
        if (existingItem != null)
        {
            existingItem.Quantity += 1;
        }
        else
        {
            cart.Add(new CartItem
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1
            });
        }

        TempData["Cart"] = cart;
        TempData.Keep("Cart");

        return RedirectToAction("Index", "Cart");
    }


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
