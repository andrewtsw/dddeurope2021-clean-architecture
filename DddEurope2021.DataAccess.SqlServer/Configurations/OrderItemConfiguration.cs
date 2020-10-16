using DddEurope2021.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DddEurope2021.DataAccess.SqlServer.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(orderItem => orderItem.Product)
                .WithMany(product => product.OrderItems)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.Property(orderItem => orderItem.UnitPrice)
            //    .HasColumnType("decimal(18, 6)");

            //builder.Property(orderItem => orderItem.Discount)
            //    .HasColumnType("decimal(18, 6)");
        }
    }
}
