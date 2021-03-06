﻿using book_site.Data.Interfaces;
using book_site.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Repository
{
    public class AuthorRepository : IBooksAuthor
    {
        private readonly AppDBContent appDBContent;
        public AuthorRepository(AppDBContent _appDBContent)
        {
            appDBContent = _appDBContent;
        }
        public IEnumerable<Author> AllAuthors => appDBContent.Authors;

        public IEnumerable<Author> Authors(IEnumerable<Book> filter)
        {
            List<Author> _authors = new List<Author>();
            foreach(var item in filter)
            {
                if(!_authors.Contains(item.Author))
                {
                    _authors.Add(item.Author);
                }
            }
            return _authors;
        }

        public void AddAuthor(string nameAuthor)
        {
            appDBContent.Authors.Add(new Author
            {
                NameAuthor = nameAuthor,
                NormalizedNameAuthor = nameAuthor.ToUpper()
            });
            appDBContent.SaveChanges();
        }

        public void RemoveAuthor(Author author)
        {
            appDBContent.Remove(author);
            appDBContent.SaveChanges();
        }

        public void EditAuthor(Author author)
        {
            var _author = appDBContent.Authors.FirstOrDefault(a => a.Id == author.Id);
            appDBContent.Remove(_author);
            appDBContent.Add(author);
            appDBContent.SaveChanges();
        }
    }
}
