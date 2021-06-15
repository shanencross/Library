using System.Collections.Generic;

namespace Library.Models
{
  public class Copy
  {
    public int CopyId { get; set; }
    public int BookId { get; set; }
    public bool IsCheckedOut { get; set; }
    public virtual ICollection<Checkout> Checkouts { get; set; }
    public virtual Book Book { get; set; }
    
    public Copy()
    {
      this.Checkouts = new HashSet<Checkout>();
      this.IsCheckedOut = false;
    }
  }
}