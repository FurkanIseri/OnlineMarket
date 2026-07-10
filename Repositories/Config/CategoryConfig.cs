using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.CategoryId);
            builder.Property(p => p.CategoryName);
            builder.HasData(
                new { CategoryId = 1, CategoryName = "Book" },
                new { CategoryId = 2, CategoryName = "Sports" },
                new { CategoryId = 3, CategoryName = "Game" },
                new { CategoryId = 4, CategoryName = "Electronic" }
            );
        }
    }
}