using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaTypeRepository
  {
    private static readonly PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static PizzaBoxDbContext _db = db.Instance;
    public List<PizzaType> Get()
    {
      return _db.PizzaType.ToList();
    }

    public PizzaType Get(long id)
    {
      return _db.PizzaType.SingleOrDefault(pt => pt.TypeId == id);
    }

    public PizzaType Get(string pizzaT)
    {
      return _db.PizzaType.SingleOrDefault(pt => pt.Name == pizzaT);
    }

    public bool Post(PizzaType pizzaType)
    {
      _db.PizzaType.Add(pizzaType);
      return _db.SaveChanges() == 1;
    }

    public bool Put(PizzaType pizzaType)
    {
      PizzaType pt = Get(pizzaType.TypeId);

      pt = pizzaType;
      return _db.SaveChanges() == 1;
    }
  }
}