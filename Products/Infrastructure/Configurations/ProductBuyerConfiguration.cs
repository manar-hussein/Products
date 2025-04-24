using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Models;

namespace Products.Infrastructure.Configurations
{
    public class ProductBuyerConfiguration : IEntityTypeConfiguration<ProductBuyer>
    {
        public void Configure(EntityTypeBuilder<ProductBuyer> builder)
        {
            builder.OwnsOne(e => e.Address, a =>
            {
                a.Property(p => p.Street).HasColumnName("ShippingStreet");
                a.Property(p => p.City).HasColumnName("ShippingCity");
                a.Property(p => p.ZIPCode).HasColumnName("ShippingZipCode");
                a.Property(p => p.Country).HasColumnName("ShippingCountry");
            });

            builder.OwnsOne(e => e.BankCard, b =>
            {
                b.Property(c => c.NameonCard).HasColumnName("NameonCard");
                b.Property(c => c.CardNumber).HasColumnName("CardNumber");
                b.Property(c => c.CVV).HasColumnName("CVV");
                b.Property(c => c.ExpiryDate).HasColumnName("ExpiryDate");
            });
        }
    }
}
