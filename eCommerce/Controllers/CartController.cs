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
        var cartItems = await _context.CartItems
                        .Include(ci => ci.Product)
                        .ToListAsync();
        return View(cartItems);
    }



    [HttpPost]
    public async Task<IActionResult> AddCart(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product == null)
        {
            return NotFound();
        }

        // Check if item already exists in cart
        var existingItem = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += 1;
        }
        else
        {
            var cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = 1,
                Product = product
            };

            _context.CartItems.Add(cartItem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
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
