using DddEurope2021.Domain;
using Microsoft.EntityFrameworkCore;

namespace DddEurope2021.UseCases.Interfaces
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; }

        DbSet<OrderItem> OrderItems { get; }

        DbSet<Product> Products { get; }
    }
}
