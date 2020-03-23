using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class OrderModel
  {
    private static readonly PizzaTypeRepository _ptr = new PizzaTypeRepository();
    private static readonly SizeRepository _sr = new SizeRepository();

    public long OrderId { get; set; }
    public string UserId { get; set; }
    public string Location { get; set; }
    public string OrderDate { get; set; }
    public decimal Cost { get; set; }

  }
}