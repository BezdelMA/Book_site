using book_site.Data.Interfaces;
using book_site.Data.Models;
using System;
using System.Collections.Generic;
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
            _appDBContent.Orders.Add(order);
            _appDBContent.SaveChanges();

            var items = _shopBasket.ListBookBasket;

            foreach(var item in items)
            {
                OrderDetails orderDetails = new OrderDetails()
                {
                    BookId = item.Book.Id,
                    OrderId = order.Id,
                    Price = item.Book.Price
                };
                _appDBContent.OrderDetails.Add(orderDetails);
            }
            _appDBContent.SaveChanges();
        }
    }
}
