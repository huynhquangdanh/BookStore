using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Areas.Admin.Models;
using BookStore.Models;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Title = "The Alchemist",
                Genre = "Novel",
                Price = 20,
                PublishDate = new DateTime(2012, 4, 23)
            });
        }

        public DbSet<BookStore.Areas.Admin.Models.Book> Book { get; set; }

        public DbSet<BookStore.Models.Shirt> Tshirt { get; set; }
    }
}
