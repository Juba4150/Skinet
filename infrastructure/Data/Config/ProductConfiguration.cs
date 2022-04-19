using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
    public class ProductConfguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p=>p.Price).HasColumnType("dicimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.HasOne(p=>p.ProductBrand).WithMany().HasForeignKey(b=>b.ProductBrandId);
            builder.HasOne(p=>p.ProductType).WithMany().HasForeignKey(p=>p.ProductTypeId);
        }
    }
}