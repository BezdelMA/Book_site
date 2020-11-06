using book_site.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent appDBContent)
        {
            if (!appDBContent.Genres.Any())
            {
                appDBContent.AddRange(Genres.Select(obj => obj.Value));
            }

            if (!appDBContent.Authors.Any())
            {
                appDBContent.AddRange(Authors.Select(obj => obj.Value));
            }
            
            if (!appDBContent.Books.Any())
            {
                appDBContent.AddRange(Books.Select(obj => obj.Value));
            }

            appDBContent.SaveChanges();
        }

        private static Dictionary<string, Genre> genre;
        public static Dictionary<string, Genre> Genres
        {
            get
            {
                if (genre == null)
                {
                    var list = new Genre[] {
                        new Genre { NameGenre = "Комедия" },
                        new Genre { NameGenre = "Роман" },
                        new Genre { NameGenre = "Драма" },
                        new Genre { NameGenre = "О войне" },
                        new Genre { NameGenre = "Исторические" }
                    };
                    genre = new Dictionary<string, Genre>();
                    foreach (var item in list)
                    {
                        genre.Add(item.NameGenre, item);
                    }
                }
                return genre;
            }
        }

        private static Dictionary<string, Author> author;
        public static Dictionary<string, Author> Authors
        {
            get
            {
                if (author == null)
                {
                    var list = new Author[]
                    {
                        new Author{NameAuthor="1"},
                        new Author{NameAuthor="2"},
                        new Author{NameAuthor="3"},
                        new Author{NameAuthor="4"},
                        new Author{NameAuthor="5"}
                    };
                    author = new Dictionary<string, Author>();
                    foreach(var item in list)
                    {
                        author.Add(item.NameAuthor, item);
                    }
                }
                return author;
            }
        }

        private static Dictionary<string, Book> book;

        public static Dictionary<string, Book> Books
        {
            get
            {
                if (book == null)
                {
                    var list = new Book[]
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
                            Genre = genre["Комедия"],
                            Author = author["1"]
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
                            Genre = genre["Роман"],
                            Author = author["2"]
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
                            Genre = genre["Драма"],
                            Author = author["3"]
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
                            Genre = genre["О войне"],
                            Author = author["4"]
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
                            Genre = genre["Исторические"],
                            Author = author["5"]
                        }
                    };
                    book = new Dictionary<string, Book>();
                    foreach (var item in list)
                    {
                        book.Add(item.NameBook, item);
                    }
                }
                return book;
            }
        }
    }
}
