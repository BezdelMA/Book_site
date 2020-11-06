using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class ShopBasket
    {
        private readonly AppDBContent appDBContent;
        
        public ShopBasket(AppDBContent _appDBContent)
        {
            appDBContent = _appDBContent;
        }

        public string BasketBookId { get; set; }
        public List<BookBasket> ListBookBasket { get; set; }

        public int AllPrice
        {
            get
            {
                int sum = 0;
                if(ListBookBasket.Count>0)
                {
                    foreach (var item in ListBookBasket)
                        sum += item.Price;
                }
                return sum;
            }
        }

        public int Counter
        {
            get
            {
                int count = 0;
                foreach (var item in ListBookBasket)
                {
                    count += item.Counter;
                }

                return count;
            }
        }
        public static ShopBasket GetBasket(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string basketBookId = session.GetString("BasketId") ?? Guid.NewGuid().ToString();

            session.SetString("BasketId", basketBookId);
            return new ShopBasket(context)
            {
                BasketBookId = basketBookId
            };
        }

        public static void CloseSession(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            session.Clear();
        }

        public void AddToBasket(Book book)
        {
            var items = appDBContent.BookBaskets.Where(obj => obj.BasketBookId == BasketBookId);
            bool flag = false;
            foreach(var item in items)
            {
                if(item.Book == book)
                {
                    item.Counter += 1;
                    flag = true;
                }
            }

            if (!flag)
            {
                this.appDBContent.BookBaskets.Add(new BookBasket
                {
                    BasketBookId = BasketBookId,
                    Book = book,
                    Price = book.Price,
                    Counter = 1
                });
            }
            appDBContent.SaveChanges();
            flag = false;
        }

        public List<BookBasket> GetBookBasket()
        {
            return appDBContent.BookBaskets.Where(obj => obj.BasketBookId == BasketBookId).Include(obj => obj.Book).ToList();
        }
    }
}
