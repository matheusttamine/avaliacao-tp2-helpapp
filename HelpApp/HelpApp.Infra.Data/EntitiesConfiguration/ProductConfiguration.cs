using HelpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpApp.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Caderno",
                    Description = "Caderno de 10 matérias",
                    Price = 9.99m,
                    Stock = 50,
                    Image = "Caderno.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Teclado",
                    Description = "Teclado mecânico",
                    Price = 179.99m,
                    Stock = 50,
                    Image = "Teclado.jpg",
                    CategoryId = 2
                }



            );
        }
    }
}
