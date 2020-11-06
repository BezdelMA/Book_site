using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_site.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace book_site.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookBasket> BookBaskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
