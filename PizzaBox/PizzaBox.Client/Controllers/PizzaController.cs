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


    [HttpGet]
    public IActionResult Create()
    {
      return View(new PizzaModel());
    }

    [HttpPost]
    public IActionResult Create(PizzaModel pizzaModel)
    {
      //Pizza p = new Pizza();
      // Order o = new Order();
      
      // p.PizzaType = pizzaModel.pizzaType;
      // p.Size = pizzaModel.size;

      // ViewData["pizzatype"] = pizzaModel.pizzaType;
      // ViewData["size"] = pizzaModel.size;
      

      _pm.Add(pizzaModel);

      foreach (var item in _pm)
      {
        item.Cost = (_ptr.Get(item.pizzaType)).Cost + (_sr.Get(item.size)).Cost;
      }

      return View("OrderDetails", _pm);
    }
  }
}