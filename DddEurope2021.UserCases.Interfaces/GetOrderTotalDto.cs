namespace DddEurope2021.UseCases.Interfaces
{
    public class GetOrderTotalDto
    {
        public int Id { get; set; }

        public string ExternalId { get; set; }

        public string Comment { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }
    }
}
