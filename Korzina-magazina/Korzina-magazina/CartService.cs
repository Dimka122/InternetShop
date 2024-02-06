using Korzina_magazina.Data;
using Korzina_magazina.Models;
using Newtonsoft.Json;

namespace Korzina_magazina
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private readonly ProductContext _context;
        private Cart _cart = new Cart();

        public CartService(ProductContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _cart = GetCartFromSession();

        }
        public Cart GetCart()
        {
            return _cart;
        }
        public void AddItem(Product product, int quantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (item == null)
            {
                item = new Item { Product = product, Quantity = quantity };
                _cart.Items.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
            UpdateCartInSession();
        }

        private void UpdateCartInSession()
        {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(_cart));
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }
        public void AddToCart(string productId, int quantity)
        {
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                var newItem = new Item { Product = product, Quantity = quantity };
                _cart.Items.Add(newItem);
            }
        }
        public void UpdateCart(Cart cart)
        {
            _cart = cart;
            SaveCartToSession(_cart);
        }

        private void SaveCartToSession(Cart cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            _httpContextAccessor.HttpContext.Session.SetString("Cart", cartJson);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }

        private Cart GetCartFromSession()
        {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            var cartJson = _httpContextAccessor.HttpContext.Session.GetString("Cart");
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.

            if (!string.IsNullOrEmpty(cartJson))
            {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
                return JsonConvert.DeserializeObject<Cart>(cartJson);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            }

            var cart = new Cart();
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            return cart;
        }

        public void RemoveItem(string productId)
        {
            var cart = GetCart();
            var itemToRemove = cart.Items.FirstOrDefault(item => item.Product.Id == productId);

            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
                UpdateCartInSession();

            }
        }
        public void ClearCart()
        {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            _httpContextAccessor.HttpContext.Session.Remove("Cart");
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }


    }
}