using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Title { get; set; }
    public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    public virtual ICollection<Copy> Copies { get; set; }

    public Author()
    {
      this.AuthorBooks = new HashSet<AuthorBook>();
      this.Copies = new HashSet<Copy>();
    }
  }
}