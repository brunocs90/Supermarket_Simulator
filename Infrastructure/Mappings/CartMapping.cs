using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class CartMapping : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable(nameof(Cart));

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            // Relationship mapping between Cart and CartItem
            builder.HasMany(c => c.Items)
                .WithOne()
                .HasForeignKey(c => c.CartId) // Foreign key name
                .IsRequired();
        }
    }
}