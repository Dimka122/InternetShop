using Korzina_magazina.Models;

namespace Korzina_magazina
{
    public interface ICartService
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(string productId);
        void ClearCart();
        Cart GetCart();
    }
}
