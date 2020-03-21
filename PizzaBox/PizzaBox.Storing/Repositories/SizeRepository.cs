using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
  public class SizeRepository
  {
    private static PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static PizzaBoxDbContext _db = db.Instance;
    public List<Size> Get()
    {
      return _db.Size.ToList();
    }

    public Size Get(long id)
    {
      return _db.Size.SingleOrDefault(s => s.SizeId == id);
    }

    public Size Get(string size)
    {
      return _db.Size.SingleOrDefault(s => s.Name == size);
    }

    public bool Post(Size size)
    {
      _db.Size.Add(size);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Size size)
    {
      Size s = Get(size.SizeId);

      s = size;
      return _db.SaveChanges() == 1;
    }
  }
}