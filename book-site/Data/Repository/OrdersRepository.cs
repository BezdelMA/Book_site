using book_site.Data.Interfaces;
using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopBasket _shopBasket;

        public OrdersRepository(AppDBContent appDBContent, ShopBasket shopBasket)
        {
            _appDBContent = appDBContent;
            _shopBasket = shopBasket;
        }

        public void CreateOrder(Order order)
        {
            order.DateOrder = DateTime.Now;
            order.Status = "Новый";
            _appDBContent.Orders.Add(order);
            _appDBContent.SaveChanges();

            var items = _shopBasket.ListBookBasket;

            foreach(var item in items)
            {
                OrderDetails orderDetails = new OrderDetails()
                {
                    BookId = item.Book.Id,
                    OrderId = order.Id,
                    Price = item.Book.Price,
                    Counter = item.Counter
                };
                _appDBContent.OrderDetails.Add(orderDetails);
            }
            _appDBContent.SaveChanges();
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                IEnumerable<Order> obj = _appDBContent.Orders
                    .Include(o => o.Adress);
                return obj;
            }
        }

        public IEnumerable<OrderDetails> OrderDetails(int Id)
        {
            return _appDBContent.OrderDetails.Where(obj => obj.OrderId == Id);
        }
    }
}
