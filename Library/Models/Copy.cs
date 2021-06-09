using System.Collections.Generic;

namespace Library.Models
{
  public class Copy
  {
    public int CopyId { get; set; }
    public int BookId { get; set; }
    public virtual ICollection<Checkout> Checkouts { get; set; }
    
    public Patrons()
    {
      this.Checkouts = new HashSet<Checkout>();
    }
  }
}