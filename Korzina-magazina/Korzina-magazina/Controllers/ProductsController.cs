using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Korzina_magazina.Data;
using Korzina_magazina.Models;

namespace Korzina_magazina.Controllers
{
    public class ProductsController:Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        

        public async Task<IActionResult> Index()
        {
            return _context.Products != null ?
                        View(await _context.Products.ToListAsync()) :
                        Problem("Entity set 'ProductContext.Products'  is null.");
        }
    }
}
