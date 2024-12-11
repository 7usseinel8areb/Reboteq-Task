using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReboteqTask.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.TotalPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(o => o.TotalPriceAfterDiscount)
            .HasPrecision(18, 2)
            .IsRequired();

        /*builder.HasOne(o => o.Coupon)
            .WithMany()
            .HasForeignKey(o => o.CouponId)
            .OnDelete(DeleteBehavior.SetNull);*/

        builder.HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}