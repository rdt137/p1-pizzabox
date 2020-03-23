using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class StoreSales
  {
    public string Name { get; set; }
    public decimal CostPerStore { get; set; }
  }
}