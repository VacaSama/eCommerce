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

    /// <summary>
    /// This represents a temporary list of cart for the user. 
    /// </summary>
    public static List<CartItem> Cart = new(); // Simulated cart


    /// <summary>
    /// CART INDEX// This calculates the total, subtotal and hardcodes the shipping cost
    /// so that the view can update automatically, it returns the viewModel 
    /// and stores temporary data so that the cart can stay up to date. 
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// AddCart takes a param of productId (int), to find and add a product using the productid
    /// to the cart. 
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
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

    /// <summary>
    /// UpdateQuantity takes two params int productId and int quantity, deafult quantity is 1. 
    /// If the Quantity is equal to or less than zero it gets completely removed from the temporary cart. 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>

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
