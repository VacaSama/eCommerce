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

    public static List<CartItem> Cart = new(); // Simulated cart

    public IActionResult Index()
    {
        var cartItems = Cart; // using your static cart list


        var viewModel = new CartPreviewViewModel
        {
            Product = null, // or use TempData to store the last added product
            CartItems = cartItems
        };

        decimal subtotal = Cart.Sum(item => item.Price * item.Quantity);
        decimal shipping = 3.00m; // or use dropdown logic
        decimal total = subtotal + shipping;

        ViewBag.Subtotal = subtotal;
        ViewBag.Shipping = shipping;
        ViewBag.Total = total;

        return View(viewModel);
    }

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
                ProductId = productId,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1,
                Product = product // if you're using nested Product info in your view
            });
        }

        return RedirectToAction("Index");
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
