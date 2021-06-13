using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
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
        public ActionResult Create(Book book, string authorName)
        {
            Author author = new Author { Name=authorName };
            _db.Books.Add(book);
            _db.SaveChanges();
            _db.Authors.Add(author);
            _db.SaveChanges();

            AuthorBook authorBook = new AuthorBook { AuthorId=author.AuthorId, BookId=book.BookId };
            _db.AuthorBooks.Add(authorBook);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}