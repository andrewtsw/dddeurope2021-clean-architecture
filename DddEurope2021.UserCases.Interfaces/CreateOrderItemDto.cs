﻿namespace DddEurope2021.UseCases.Interfaces
{
    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }
    }
}
