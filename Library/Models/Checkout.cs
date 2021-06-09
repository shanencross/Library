using System;
using System.Collections.Generic;

namespace Library.Models
{
  public class Checkout
  {
    public int CheckoutId { get; set; }
    public int CopyId { get; set; }
    public int PatronId { get; set; }
    public DateTime DueDate { get; set; }
    public virtual Patron Patron { get; set; }
    public virtual Copy Copies { get; set; }
  }
}