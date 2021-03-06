﻿using book_site.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Interfaces
{
    public interface IBooks
    {
        IEnumerable<Book> AllBooks { get; }
        IEnumerable<Book> GetFavoriteBooks { get; }
        IEnumerable<Book> GetStockBooks { get; }
        IEnumerable<Book> GetNewBooks { get; }
        Book GetBookById(int bookId);
        void CreateBook(Book book);
        string UpLoadFile(IFormFile file);
        void EditBook(Book book);
        void DeleteBook(Book book);
    }
}
