using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReboteqTask.Infrastructure.Configurations;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Discount)
            .HasPrecision(18, 2)
            .IsRequired();
    }
}