using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class PizzaSizeSales
  {
    public string Name { get; set; }
    public decimal CostPerSize { get; set; }
  }
}