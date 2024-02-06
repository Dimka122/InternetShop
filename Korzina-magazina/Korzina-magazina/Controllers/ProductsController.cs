using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Korzina_magazina.Data;
using Korzina_magazina;
using System.Threading.Tasks;
using System.Linq;


namespace ECommerceShoppingCartAppASPNET7.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        private readonly CartService _cartService;

        public ProductsController(ProductContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        // GET: Products

        public async Task<IActionResult> Index()
        {
            var products = _context.Products.ToList();

            var cart = _cartService.GetCart();
            foreach (var item in cart.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.Product.Id);
                if (product != null)
                {
                    product.Quantity = item.Quantity;
                }
            }

            return View(products);
        }
    }

}