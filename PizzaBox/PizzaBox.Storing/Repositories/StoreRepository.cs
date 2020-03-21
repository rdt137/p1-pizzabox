using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository
  {
    private static PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static PizzaBoxDbContext _db = db.Instance;
    public List<Store> Get()
    {
      return _db.Store.ToList();
    }

    public Store Get(string id)
    {
      return _db.Store.SingleOrDefault(s => s.Location == id);
    }

    public bool Post(Store store)
    {
      _db.Store.Add(store);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Store store)
    {
      Store s = Get(store.Location);

      s = store;
      return _db.SaveChanges() == 1;
    }
  }
}