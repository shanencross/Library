using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller 
    {
        private readonly LibraryContext _db;

        public BooksController(LibraryContext db) 
        {
            _db = db;
        }

        public ActionResult Index()
        {
            IEnumerable<Book> sortedBooks = _db.Books
              .Include(book => book.AuthorBooks)
              .ThenInclude(authorBook => authorBook.Author)
              .OrderBy(book => book.Title)
              .ToList();
            return View(sortedBooks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book, string authorName1, string authorName2, string authorName3, string authorName4, int numberOfCopies)
        {
            _db.Books.Add(book);
            _db.SaveChanges();

            List<string> authorNames = new List<string> { authorName1, authorName2, authorName3, authorName4 };
            
            foreach (string authorName in authorNames)
            {
                if (String.IsNullOrWhiteSpace(authorName) == false)
                {
                    Author author = _db.Authors.FirstOrDefault(model => model.Name == authorName);
                    if (author == null)
                    {
                        author = new Author { Name= authorName };
                        _db.Authors.Add(author);
                        _db.SaveChanges();
                    }

                    AuthorBook authorBook = new AuthorBook { AuthorId=author.AuthorId, BookId=book.BookId };
                    _db.AuthorBooks.Add(authorBook);
                    _db.SaveChanges();    
                }
            }

            for (int i=0; i<numberOfCopies; i++)
            {
                Copy copy = new Copy() { BookId=book.BookId };
                _db.Copies.Add(copy);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Book book = _db.Books.FirstOrDefault(model => model.BookId == id);
            return View(book);
        }
    }
}