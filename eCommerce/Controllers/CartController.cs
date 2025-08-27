using eCommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CartController : Controller
    {
        //private readonly eCommerceDatabaseContext _context;

        //// constructor 
        //public CartController(eCommerceDatabaseContext context)
        //{
        //    _context = context;
        //}

        //public IActionResult Add(int id)
        //{
        //    var product = _context.Products.FirstOrDefault(x => x.Id == id);
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
