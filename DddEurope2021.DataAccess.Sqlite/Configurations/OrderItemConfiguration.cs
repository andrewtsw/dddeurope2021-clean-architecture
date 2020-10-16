using DddEurope2021.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DddEurope2021.DataAccess.Sqlite.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(orderItem => orderItem.Product)
                .WithMany(product => product.OrderItems)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
