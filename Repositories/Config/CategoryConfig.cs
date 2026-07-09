using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Entities;

namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.CategoryId);
            builder.Property(p => p.CategoryName);
            builder.HasData(
                new Category(){CategoryId = 1,CategoryName = "Book"},
                new Category(){CategoryId = 2,CategoryName = "Sports"},
                new Category(){CategoryId = 3,CategoryName = "Game"},
                new Category(){CategoryId = 4,CategoryName = "Electronic"}
            );
        }
    }
}