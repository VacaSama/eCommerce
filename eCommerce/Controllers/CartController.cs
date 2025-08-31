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

}
