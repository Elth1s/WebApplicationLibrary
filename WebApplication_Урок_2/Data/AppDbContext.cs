using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Урок_2.Data.Models;

namespace WebApplication_Урок_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }
        public DbSet<Log> Logs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Log>().HasKey(n => n.Id);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Books)
                .HasForeignKey(bi => bi.AuthorId);
        }

    }
}
