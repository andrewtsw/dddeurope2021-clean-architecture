using System.Collections.Generic;

namespace DddEurope2021.UseCases.Interfaces
{
    public class CreateOrderDto
    {
        public string Comment { get; set; }

        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}
