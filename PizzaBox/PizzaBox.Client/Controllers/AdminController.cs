using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;
using System.Collections.Generic;
using System.Linq;


namespace PizzaBox.Client.Controllers
{
  public class AdminController : Controller
  {
    public static PizzaBoxDbContext db = new PizzaBoxDbContext();
    static readonly PizzaBoxDbContext _db = db.Instance;
    
    [HttpGet]
    public IActionResult OrderHistory()
    {
      var orders = from o in _db.Order
                  select new {o.OrderId, o.User, o.Cost, o.OrderDate, o.Location};
                  
      List<OrderModel> od = new List<OrderModel>();
      foreach (var item in orders)
      {
        var o = new OrderModel();
        o.OrderId = item.OrderId;
        o.UserId = item.User.ToString();
        o.Cost = item.Cost;
        o.OrderDate = item.OrderDate.ToString("MM/dd/yyyy h:mm tt");
        o.Location = item.Location.ToString();
        od.Add(o);
      }
      return View(od);
    }

    [HttpGet]
    public IActionResult Sales()
    {
      // var pizza = from p in _db.Pizza
      //             select new {p.PizzaType, p.Cost}
      //             group by p.PizzaType;
                  
      // List<string> od = new List<string>();
      // foreach (var item in orders)
      // {
      //   od.Add(item.ToString());
      // }
      // return View(od);
      return View();
    }
  }
}