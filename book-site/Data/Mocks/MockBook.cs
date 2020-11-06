using book_site.Data.Interfaces;
using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Mocks
{
    public class MockBook : IBooks
    {
        private readonly IBooksGenre _booksGenre = new MockGenre();
        private readonly IBooksAuthor _booksAuthor = new MockAuthor();
        public IEnumerable<Book> AllBooks
        {
            get
            {
                return new List<Book>
                {
                    new Book {
                        NameBook="Внутри убийцы",
                        Annotation = "",
                        Img = "../img/catalog/1.jpg",
                        Price = 460,
                        Year = 2020,
                        IsNew = true,
                        IsFavorite = true,
                        IsStock = true,
                        Genre = _booksGenre.AllGenres.FirstOrDefault(obj => obj.NameGenre == "Комедия"),
                        Author = _booksAuthor.AllAuthors.FirstOrDefault(obj => obj.NameAuthor == "1")
                    },
                    new Book {
                        NameBook="В метре друг от друга",
                        Annotation = "",
                        Img = "../img/catalog/2.jpg",
                        Price = 800,
                        Year = 2020,
                        IsNew = true,
                        IsFavorite = true,
                        IsStock = true,
                        Genre = _booksGenre.AllGenres.FirstOrDefault(obj => obj.NameGenre == "Роман"),
                        Author = _booksAuthor.AllAuthors.FirstOrDefault(obj => obj.NameAuthor == "2")
                    },
                    new Book {
                        NameBook="1984",
                        Annotation = "",
                        Img = "../img/catalog/3.jpg",
                        Price = 950,
                        Year = 2020,
                        IsNew = true,
                        IsFavorite = true,
                        IsStock = true,
                        Genre = _booksGenre.AllGenres.FirstOrDefault(obj => obj.NameGenre == "Драма"),
                        Author = _booksAuthor.AllAuthors.FirstOrDefault(obj => obj.NameAuthor == "3")
                    },
                    new Book {
                        NameBook="«В» - значит выпечка",
                        Annotation = "",
                        Img = "../img/catalog/4.jpg",
                        Price = 1130,
                        Year = 2020,
                        IsNew = true,
                        IsFavorite = true,
                        IsStock = true,
                        Genre = _booksGenre.AllGenres.FirstOrDefault(obj => obj.NameGenre == "О войне"),
                        Author = _booksAuthor.AllAuthors.FirstOrDefault(obj => obj.NameAuthor == "4")
                    },
                    new Book {
                        NameBook="Найди свою волну",
                        Annotation = "",
                        Img = "../img/catalog/5.jpg",
                        Price = 740,
                        Year = 2020,
                        IsNew = true,
                        IsFavorite = true,
                        IsStock = true,
                        Genre = _booksGenre.AllGenres.FirstOrDefault(obj => obj.NameGenre == "Исторические"),
                        Author = _booksAuthor.AllAuthors.FirstOrDefault(obj => obj.NameAuthor == "5")
                    }
                };
            }
        }
        public IEnumerable<Book> GetFavoriteBooks {
            get
            {
                return AllBooks.Where(obj => obj.IsFavorite == true);
            }
            set { } }
        public IEnumerable<Book> GetStockBooks { 
            get
            {
                return AllBooks.Where(obj => obj.IsStock == true);
            }
            set { }
        }
        public IEnumerable<Book> GetNewBooks { 
            get
            {
                return AllBooks.Where(obj => obj.IsNew == true);
            }
            set { }
        }

        public Book GetBookById(int bookId)
        {
            return AllBooks.FirstOrDefault(obj => obj.Id == bookId);
        }
    }
}
