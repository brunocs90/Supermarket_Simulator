using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class CartItemMapping : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable(nameof(CartItem));

            builder
                .HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(ci => ci.ProductId)
                .IsRequired();

            builder.Property(ci => ci.Quantity)
                .IsRequired();

            // Relationship mapping with Product
            builder.HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .IsRequired();
        }
    }
}