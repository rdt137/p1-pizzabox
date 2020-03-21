using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using System;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private static PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static PizzaBoxDbContext _db = db.Instance;
    public List<Order> Get()
    {
      return _db.Order.ToList();
    }

    public Order Get(long id)
    {
      return _db.Order.SingleOrDefault(o => o.OrderId == id);
    }

    public Order Get(User user)
    {
      try
      {
        return _db.Order.ToArray().LastOrDefault(o => o.User == user);
      }
      catch(Exception)
      {
        Console.WriteLine("Error");
        return _db.Order.FirstOrDefault(o => o.User == user);
      }
    }

    public bool Update(Order order)
    {      
      _db.Order.Add(order);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Order order)
    {
      Order o = Get(order.OrderId);

      o = order;
      return _db.SaveChanges() == 1;
    }
  }
}