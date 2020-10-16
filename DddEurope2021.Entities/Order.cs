using System.Collections.Generic;
using System.Linq;

namespace DddEurope2021.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public string ExternalId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public decimal CalculateSubTotal()
        {
            return OrderItems.Sum(x => x.CalculatePrice());
        }

        public decimal CalculateTotalPrice()
        {
            var subTotal = OrderItems.Sum(x => x.CalculatePrice());
            var discount = CalculateDiscount();
            var tax = CalculateTax();
            return CalculateTotal(subTotal, discount, tax);
        }

        public decimal CalculateTotal(decimal subTotal, decimal discount, decimal tax)
        {
            return subTotal - discount + tax;
        }

        public decimal CalculateDiscount()
        {
            // TODO:
            return 1;
        }

        public decimal CalculateTax()
        {
            // TODO:
            return 2;
        }
    }
}
