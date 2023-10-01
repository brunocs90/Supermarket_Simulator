using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
