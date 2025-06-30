using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataBase.Models.Configurations
{
    public class PersonConfig : IEntityTypeConfiguration<PersonModel>
    {
        public void Configure(EntityTypeBuilder<PersonModel> builder)
        {
            builder.ToTable("Persons", "dbo");

            builder.HasKey(d=> d.PersonId);
            builder.Property(d => d.PersonId)
                .ValueGeneratedOnAdd();

            builder.Property(d => d.FirstName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(d => d.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);


            builder.Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.Email)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(d => d.Address)
                .IsRequired(false)
                .IsUnicode();
        }
    }
}
