using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using book_site.Data.Models;
using book_site.Data;
using book_site.Areas.Admin.ViewModel;
using book_site.Data.Interfaces;
using System.Net;
using OfficeOpenXml;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace book_site.Areas.Admin.Controllers
{
    [Area(Role.Admin), Authorize(Roles = Role.Admin)]
    public class HomeController : Controller
    {
        private readonly AppDBContent _appDBContent;
        private readonly IBooks _books;
        private readonly IBooksAuthor _author;
        private readonly IBooksGenre _genre;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(AppDBContent appDBContent, IBooks books, IBooksAuthor author, IBooksGenre genre, IWebHostEnvironment webHostEnvironment)
        {
            _appDBContent = appDBContent;
            _books = books;
            _author = author;
            _genre = genre;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadEksmo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoadEksmo(FileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            else
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                List<Author> authors = new List<Author>();
                List<Book> books = new List<Book>();
                string fileName = "wwwroot/file/" + UpLoadFile(model.FileName);

                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(fileName)))
                {
                    ExcelWorksheet sheet = excelPackage.Workbook.Worksheets[0];
                    for (int i = 18; i <= sheet.Dimension.Rows; i++)
                    {
                        authors.Add(new Author()
                        {
                            NameAuthor = sheet.Cells[i, 7].Value.ToString(),
                            NormalizedNameAuthor = sheet.Cells[i, 7].Value.ToString().ToUpper()
                        });
                    }

                    int index = 0;
                    authors.Sort(Compare);
                    while (index < authors.Count - 1)
                    {
                        if (authors[index].NormalizedNameAuthor == authors[index + 1].NormalizedNameAuthor)
                            authors.RemoveAt(index);
                        else
                        {
                            if (!_author.AllAuthors.Any(a => a.NormalizedNameAuthor == authors[index].NormalizedNameAuthor))
                            {
                                _author.AddAuthor(authors[index].NameAuthor);
                            }
                            index++;
                        }
                    }
                    for (int i = 18; i <= sheet.Dimension.Rows; i++)
                    {
                        Console.Write(i + " ");
                        string filter = sheet.Cells[i, 14].Value.ToString();
                        if (filter.Contains("Книга") || filter.Contains("Комплект"))
                        {
                            double test = 0;
                            int test_2 = 0;
                            if (filter.Contains("Комплект"))
                            {
                                test = Double.Parse(sheet.Cells[i, 5].Value.ToString()) * 0.85 + 500;
                                test = Math.Round(test);
                                test_2 = Int32.Parse(test.ToString());
                            }

                            else
                            {
                                test = Double.Parse(sheet.Cells[i, 5].Value.ToString()) * 0.85 + 200;
                                test = Math.Round(test);
                                test_2 = Int32.Parse(test.ToString());
                            }

                            string url = sheet.Cells[i, 9].Value.ToString();
                            string file = null;
                            using (WebClient client = new WebClient())
                            {
                                file = "../../../../book-site/wwwroot/img/catalog/" + DateTime.Now.DayOfYear + "_" + i + ".jpg";
                                try
                                {
                                    client.DownloadFile(url, file);
                                }
                                catch
                                {
                                    continue;
                                }
                            }

                            books.Add(new Book()
                            {
                                NameBook = sheet.Cells[i, 6].Value.ToString(),
                                NormalizedNameBook = sheet.Cells[i, 6].Value.ToString().ToUpper(),
                                PublishingHouse = "Эксмо",
                                Price = test_2,
                                Img = file
                            });
                        }
                    }
                }
                return View();
            }
        }

        private static int Compare(Author a, Author b)
        {
            return String.Compare(a.NormalizedNameAuthor, b.NormalizedNameAuthor);
        }

        private string UpLoadFile(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "file");
                fileName = file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}