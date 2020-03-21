using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository
  {
    private static PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static PizzaBoxDbContext _db = db.Instance;
    public List<Pizza> Get()
    {
      return _db.Pizza.ToList();
    }

    public Pizza Get(long id)
    {
      return _db.Pizza.SingleOrDefault(p => p.PizzaId == id);
    }

    public bool Update(Pizza pizza)
    {
      _db.Pizza.Add(pizza);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Pizza pizza)
    {
      Pizza p = Get(pizza.PizzaId);

      p = pizza;
      return _db.SaveChanges() == 1;
    }
  }
}