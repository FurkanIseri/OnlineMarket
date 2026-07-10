using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasData(

            new { ProductId = 1, CategoryId = 4, ProductName = "MacBook Pro M3", Explanation = "16GB RAM, 512GB SSD", Price = 45000, Piece = 10, Origin = "USA", ShowCase = true },
            new { ProductId = 2, CategoryId = 4, ProductName = "Kablosuz Mouse", Explanation = "Ergonomik Tasarım, Bluetooth", Price = 500, Piece = 50, Origin = "China", ShowCase = false },
            new { ProductId = 3, CategoryId = 4, ProductName = "Mekanik Klavye", Explanation = "RGB Aydınlatmalı Red Switch", Price = 1200, Piece = 25, Origin = "China", ShowCase = true },


            new { ProductId = 4, CategoryId = 1, ProductName = "C# ile Programlama", Explanation = "Sıfırdan İleri Seviye C# Rehberi", Price = 250, Piece = 100, Origin = "Turkey", ShowCase = true },
            new { ProductId = 5, CategoryId = 1, ProductName = "Clean Code", Explanation = "Yazılım Mühendisliği Klasiği", Price = 300, Piece = 45, Origin = "USA", ShowCase = false },


            new { ProductId = 6, CategoryId = 2, ProductName = "Futbol Topu", Explanation = "Profesyonel Antrenman Topu", Price = 800, Piece = 30, Origin = "Germany", ShowCase = true },
            new { ProductId = 7, CategoryId = 2, ProductName = "Tenis Raketi", Explanation = "Karbon Fiber Başlangıç Raketi", Price = 1500, Piece = 15, Origin = "France", ShowCase = false },
            new { ProductId = 8, CategoryId = 2, ProductName = "Dambıl Seti", Explanation = "2x5 kg Döküm Dambıl", Price = 700, Piece = 40, Origin = "Turkey", ShowCase = false },


            new { ProductId = 9, CategoryId = 3, ProductName = "Monopoly", Explanation = "Klasik Kutu Oyunu", Price = 400, Piece = 60, Origin = "USA", ShowCase = true },
            new { ProductId = 10, CategoryId = 3, ProductName = "Satranç Takımı", Explanation = "Ahşap El İşçiliği Satranç", Price = 600, Piece = 20, Origin = "Turkey", ShowCase = true }

                    );
        }
    }
}