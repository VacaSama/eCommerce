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

    public static List<CartItem> Cart = new(); // Simulated cart

    [HttpPost]
    public IActionResult AddCart(int productId)
    {
        var product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
        if (product == null) return NotFound();

        var existingItem = Cart.SingleOrDefault(ci => ci.ProductId == productId);
        if (existingItem != null)
        {
            existingItem.Quantity += 1;
        }
        else
        {
            Cart.Add(new CartItem
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1
            });
        }

        return RedirectToAction("Index", Cart);
    }

    //[HttpPost]
    //public IActionResult UpdateQuantity(int productId, int change)
    //{
    //    var item = Cart.FirstOrDefault(ci => ci.ProductId == productId);
    //    if (item != null)
    //    {
    //        item.Quantity += change;
    //        if (item.Quantity <= 0)
    //        {
    //            Cart.Remove(item);
    //        }
    //    }
    //    return RedirectToAction("Index");
    //}


    /// <summary>
    /// This action/method will allow the user to clear all items from the 
    /// cart.
    /// </summary>
    /// <returns></returns>
    //public IActionResult RemoveCart()
    //{
    //    Cart.Clear();
    //    return RedirectToAction("Index");
    //}
}
