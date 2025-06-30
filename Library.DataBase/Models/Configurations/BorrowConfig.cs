using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataBase.Models.Configurations
{
    public class BorrowConfig : IEntityTypeConfiguration<BorrowModel>
    {
        public void Configure(EntityTypeBuilder<BorrowModel> builder)
        {
            builder.ToTable("Borrows", "dbo");

            builder.HasKey(d => new { d.PersonId, d.BookId });

            builder.Property(d => d.BorrowDate)
                .IsRequired()
                .HasColumnType("date");


            builder.Property(d => d.ReternDate)
                .IsRequired(false)
                .HasColumnType("date");

            builder.HasOne(d=> d.Person)
                .WithMany(w=> w.Borrows)
                .HasForeignKey(d=> d.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(d => d.Book)
                .WithMany(w => w.Borrows)
                .HasForeignKey(d => d.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
