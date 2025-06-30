using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataBase.Models.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.ToTable("Books", "dbo");

            builder.HasKey(x => x.BookId);
            builder.Property(d => d.BookId).ValueGeneratedOnAdd();

            builder.Property(d => d.Title)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(d => d.Subject)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(d => d.Author)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(d => d.Status)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
        }
    }
}
