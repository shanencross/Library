namespace Library.Models
{
  public class AuthorBook
  {
    int AuthorBookId { get; set; }
    int BookId { get; set; }
    int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public virtual Book Book { get; set; }
  }
} 