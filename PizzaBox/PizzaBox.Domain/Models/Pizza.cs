using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    public long PizzaId { get; set; }    
    public decimal Cost { get; set; }

    #region Navigational Properties
    public PizzaType PizzaType { get; set; }
    public Order Order { get; set; }
    public Size Size { get; set; }

    #endregion

    public override string ToString()
    {      
      return $"{PizzaId} {PizzaType.Name ?? "n/a"} {Cost} {Size.Name ?? "n/a"}";
    }

    public string ToCost()
    {
      return $"{Cost}";
    }
  }
}