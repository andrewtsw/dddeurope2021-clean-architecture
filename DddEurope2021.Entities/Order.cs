using System.Collections.Generic;
using System.Linq;

namespace DddEurope2021.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public decimal CalculateTotalPrice()
        {
            var subTotal = OrderItems.Sum(x => x.CalculatePrice());
            var discount = CalculateDiscount();
            var tax = CalculateTax();
            return subTotal - discount + tax;
        }

        public decimal CalculateDiscount()
        {
            // TODO:
            return 0;
        }

        public decimal CalculateTax()
        {
            // TODO:
            return 0;
        }
    }
}
