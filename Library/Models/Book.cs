using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

    public Author()
    {
      this.AuthorBooks = new HashSet<AuthorBook>();
    }
  }
}