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
        Product? lastAddedProduct = null;
        if (TempData["LastAddedProductId"] is int id)
        {
            lastAddedProduct = _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        // Calculate subtotal based on current cart
        decimal subtotal = Cart.Sum(item => item.Price * item.Quantity);
        decimal shipping = 3.00m; // currently hardcoded
        decimal total = subtotal + shipping;

        // Pass totals to the view
        ViewBag.Subtotal = subtotal.ToString("0.00");
        ViewBag.Shipping = shipping.ToString("0.00");
        ViewBag.Total = total.ToString("0.00");


        var viewModel = new CartPreviewViewModel
        {
            Product = lastAddedProduct,
            CartItems = Cart
        };

        return View(viewModel);
    }


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
                Quantity = 1,
                Product = product
            });
        }

        TempData["LastAddedProductId"] = product.ProductId;
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult UpdateQuantity(int productId, int quantity)
    {

        var item = Cart.SingleOrDefault(ci => ci.ProductId == productId);
        if (item == null) return NotFound();

        if (quantity <= 0)
        {
            Cart.Remove(item); // ✅ Remove if quantity is zero
        }
        else
        {
            item.Quantity = quantity;
        }

        return RedirectToAction("Index");
    }


}
