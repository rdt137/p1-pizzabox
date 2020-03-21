using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public long OrderId { get; set; }
    public decimal Cost { get; set; }
    public DateTime OrderDate { get; set; }
    public Store Location { get; set; }    
    public User User { get; set; }
    public List<Pizza> Pizzas { get; set; }    

    public override string ToString()
    {
      return $"{"OrderId:"} {OrderId} {"Cost:"} {Cost} {"Order Date:"} {OrderDate.ToString("MM/dd/yyyy h:mm tt")} {"Location:"} {Location}";
    }

    public DateTime GetDate()
    {
      return OrderDate;
    }

    public string GetLocation()
    {
      return $"{Location}";
    }
  }
}