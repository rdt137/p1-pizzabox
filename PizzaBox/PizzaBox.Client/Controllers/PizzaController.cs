using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  
  public class PizzaController : Controller
  {
    private static List<PizzaModel> _pm = new List<PizzaModel>();
    private static PizzaTypeRepository _ptr = new PizzaTypeRepository();
    private static SizeRepository _sr = new SizeRepository();
    private static StoreRepository _str = new StoreRepository();
    private static UserRepository _ur = new UserRepository();
    private static OrderRepository _or = new OrderRepository();
    private static PizzaRepository _pr = new PizzaRepository();


    [HttpGet]
    public IActionResult PizzaHome()
    {
      _pm.Clear();
      return View("CustHome");
    }

    [HttpGet]
    public IActionResult Location()
    {
      return View(new LocationModel());
    }

    [HttpPost]
    public IActionResult Location(LocationModel loc)
    {
      if(ModelState.IsValid)
      {
        TempData["location"] = loc.Location;
        return View("Create", new PizzaModel());
      }
      return View(loc);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
      return View(new PizzaModel());
    }

    [HttpPost]
    public IActionResult Create(PizzaModel pizzaModel)
    {      
      if(ModelState.IsValid)
      {
        _pm.Add(pizzaModel);

        foreach (var item in _pm)
        {
          item.Cost = (_ptr.Get(item.pizzaType)).Cost + (_sr.Get(item.size)).Cost;
        }

        return View("OrderDetails", _pm);
      }

      return View(new PizzaModel());
    }

    [HttpGet]
    public IActionResult Remove()
    {
    
     int count = 0;
     int.TryParse(TempData["count"].ToString(), out count);
      _pm.RemoveAt(count - 1);
      return View("OrderDetails", _pm);
    }

    [HttpGet]
    public IActionResult Checkout()
    {
      Order o = new Order();
      var user = TempData["user"];
      o.Location = _str.Get(TempData["location"].ToString());
      o.User = _ur.Get(user.ToString());
      TempData["user"] = user;
      o.OrderDate = DateTime.Now;  

      decimal totalCost = 0;
      foreach (var item in _pm)
      {
        totalCost += item.Cost;
      }    
      o.Cost = totalCost;

      _or.Update(o);

      bool worked = false;

      foreach (var item in _pm)
      {
        var p = new Pizza();

        var pizzaType = _ptr.Get(item.pizzaType.ToString());
        var size = _sr.Get(item.size.ToString());        

        // pizzaType.Pizzas = new List<Pizza> { p }; // p.crust = *crustId
        // size.Pizzas = new List<Pizza> { p };

        p.PizzaType = pizzaType;
        p.Size = size;
        p.Cost = item.Cost;
        p.Order = o;

        worked = _pr.Update(p);
      }
      
      if(worked)
        return View();
      
      return View("OrderDetails");
    }
  }
}