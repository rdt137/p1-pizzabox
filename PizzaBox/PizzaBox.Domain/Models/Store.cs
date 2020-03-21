using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Store
  {  
    public string Location { get; set; }
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return $"{Location ?? "N/A"}";
    }
  }
}