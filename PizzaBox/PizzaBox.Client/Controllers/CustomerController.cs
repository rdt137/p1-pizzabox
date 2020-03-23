using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class CustomerController : Controller
  {    
    public static PizzaBoxDbContext db = new PizzaBoxDbContext();
    private static readonly UserRepository _ur = new UserRepository();
    static readonly PizzaBoxDbContext _db = db.Instance;

    [HttpGet]
    public IActionResult CustHome()
    {
      return View();
    }
    
    [HttpGet]
    public IActionResult CustHistory()
    {
      var user = TempData["user"];          
      var orders = from o in _db.Order
                  where o.User == _ur.Get(user.ToString())
                  select new {o.OrderId, o.Cost, o.OrderDate, o.Location};
      TempData["user"] = user;          
      
      List<OrderModel> od = new List<OrderModel>();
      foreach (var item in orders)
      {
        var o = new OrderModel();
        o.OrderId = item.OrderId;
        o.Cost = item.Cost;
        o.OrderDate = item.OrderDate.ToString("MM/dd/yyyy h:mm tt");
        o.Location = item.Location.ToString();
        od.Add(o);
      }
      return View(od);
    }
  }
}