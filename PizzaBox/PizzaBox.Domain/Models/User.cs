using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    public string UserId { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; }
    
    public List<Order> Orders { get; set; }

    public override string ToString()
    {
      return $"{UserId}";
    }
  }
}