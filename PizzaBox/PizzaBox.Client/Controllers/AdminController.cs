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
    public IActionResult AHome()
    {
      return View("AdminHome");
    }
    
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
    public IActionResult PizzaTypeSales()
    {
      var pizza = new PizzaModel();
      List<PizzaTypeSales> pi = new List<PizzaTypeSales>();
      foreach (var item in pizza.PizzaList)
      {
        var pizzaT = from p in _db.Pizza
                    where p.PizzaType.Name == item.ToString()
                    select new{p.PizzaId, p.PizzaType, p.Size, p.Cost};
        
        var pt = new PizzaTypeSales();
        foreach (var ite in pizzaT)
        {          
          pt.CostPerType += ite.Cost;          
        }

        pt.Name = item.Name;
        pi.Add(pt);
      }

      return View(pi);
    }

    public IActionResult PizzaSizeSales()
    {
      var pizza = new PizzaModel();
      List<PizzaSizeSales> si = new List<PizzaSizeSales>();

      foreach (var item in pizza.SizeList)
      {
        var pizzaS = from p in _db.Pizza
                    where p.Size.Name == item.ToString()
                    select new{p.PizzaId, p.PizzaType, p.Size, p.Cost};
        
        var ps = new PizzaSizeSales();
        foreach (var ite in pizzaS)
        {                 
          ps.CostPerSize += ite.Cost;          
        }

        ps.Name = item.Name;
        si.Add(ps);
      }

      return View(si);
    }

    [HttpGet]
    public IActionResult StoreSales()
    {      
      var loc = new LocationModel();
      List<StoreSales> sti = new List<StoreSales>();
      foreach (var item in loc.Locations)
      {
        var orderL = from o in _db.Order
                    where o.Location == item
                    select new{o.OrderId, o.Location, o.Cost, o.User};
        
        var st = new StoreSales();
        foreach (var ite in orderL)
        {          
          st.CostPerStore += ite.Cost;          
        }

        st.Name = item.Location;
        sti.Add(st);
      }
      
      return View(sti);
    }
  }
}