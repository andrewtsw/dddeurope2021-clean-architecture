using DddEurope2021.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DddEurope2021.DataAccess.Sqlite.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(order => order.OrderItems)
                .WithOne(orderItem => orderItem.Order)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(order => order.Comment)
                .HasMaxLength(250);
        }
    }
}
