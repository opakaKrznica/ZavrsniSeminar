

namespace Expert.WebShop.Vjezbe.models
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }
        public Products Product { get; set; }

        public int NumberOfItems { get; set; }

    }
}
