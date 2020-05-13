using System.Collections.Generic;

namespace WooliesX.DomainModel
{
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
        }

        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
