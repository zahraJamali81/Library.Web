using Microsoft.EntityFrameworkCore;
using Library.DataBase.Models.Configurations;

namespace Library.DataBase.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> db) : base(db) { }

            public DbSet<PersonModel> Persons { get; set; }
            public DbSet<BookModel> Books { get; set; }
            public DbSet<BorrowModel> Borrows { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new BorrowConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());

            //modelBuilder.ApplyConfigurationsFromAssembly();

        }
    }
    }


