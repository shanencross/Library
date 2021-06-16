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
  public class CheckoutsController : Controller
  {
    private readonly LibraryContext _db;

    private readonly UserManager<ApplicationUser> _userManager;

    public CheckoutsController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userCheckouts = _db.Checkouts.Where(entry => entry.Patron.Name == currentUser.UserName).ToList();
      return View(userCheckouts);
    }

    [HttpPost]
    public async Task<ActionResult> Create(int bookId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      Book book = _db.Books.FirstOrDefault(book => book.BookId == bookId);

      Copy copyToCheckout = null;
      foreach (Copy copy in book.Copies)
      { 
        if (copy.IsCheckedOut == false )
        {
          copyToCheckout = copy;
          break;
        }
      }
      copyToCheckout.IsCheckedOut = true;
      _db.Entry(copyToCheckout).State = EntityState.Modified;
      _db.SaveChanges();

      Patron patron = _db.Patrons.FirstOrDefault(patron => patron.Name == currentUser.UserName);
      Checkout newCheckout = new Checkout() { PatronId=patron.PatronId, CopyId=copyToCheckout.CopyId};
      int numberOfDaysDue = 14;
      newCheckout.DueDate = DateTime.Today.AddDays(numberOfDaysDue);

      _db.Checkouts.Add(newCheckout);
      _db.SaveChanges();

      return RedirectToAction("Details", "Books", new { id=book.BookId } );
    } 
  }
}
