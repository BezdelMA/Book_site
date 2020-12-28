using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_site.Data.Models;
using Microsoft.EntityFrameworkCore;
using book_site.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using book_site.ViewModel;

namespace book_site.Data
{
    public class AppDBContent : IdentityDbContext<User, Role, string>
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
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<book_site.ViewModel.UserInfoViewModel> UserInfoViewModel { get; set; }
        public DbSet<book_site.ViewModel.OrderViewModel> OrderViewModel { get; set; }
    }
}
