

namespace Expert.WebShop.Vjezbe.models
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }
        public Products Product { get; set; }

        public int NumberOfItems { get; set; }



        //public string OrderedByName { get; set; }
        //public string OrderedByEmail { get; set; }
        //public string ShippingAdress { get; set; }


    }
}
