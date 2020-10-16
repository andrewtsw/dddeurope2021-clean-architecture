using System.Collections.Generic;

namespace DddEurope2021.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
