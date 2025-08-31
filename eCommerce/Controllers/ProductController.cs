using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers;

public class ProductController : Controller
{
    private readonly eCommerceDatabaseContext _context;

    public ProductController(eCommerceDatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// This takes all of the Products with the eCommerceDatabaseContext 
    /// in an asyncronous way and allows me to retrieve them and distribute them 
    /// throughout the pages that I need the data from 
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        List<Product> allProducts = await _context.Products.ToListAsync();

        return View(allProducts);
    }
}
