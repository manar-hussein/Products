using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Models;

namespace Products.Infrastructure.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.Buyers).WithMany(b => b.products).UsingEntity("ProductBuyer");
            builder.HasOne(p => p.Seller).WithMany(s => s.SalesProducts);
            builder.Property(p => p.SellerId)
                   .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.HasOne<ApplicationUser>(p => p.Seller)
                   .WithMany(s => s.SalesProducts)
                   .HasForeignKey(p => p.SellerId);
        }
    }
}
