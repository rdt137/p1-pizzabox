using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository
  {
    private static PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static PizzaBoxDbContext _db = db.Instance;
    public List<User> Get()
    {
      return _db.User.ToList();
    }

    public User Get(string id)
    {
      return _db.User.SingleOrDefault(u => u.UserId == id);
    }

    public User GetP(string password)
    {
      return _db.User.SingleOrDefault(u => u.Password == password);
    }

    public User Check(string userId, string password)
    {
      return _db.User.Where(u => u.UserId == userId).SingleOrDefault(u => u.Password == password);
    }

    public bool Post(User user)
    {
      _db.User.Add(user);
      return _db.SaveChanges() == 1;
    }

    public bool Put(User user)
    {
      User u = Get(user.UserId);

      u = user;
      return _db.SaveChanges() == 1;
    }
  }
}