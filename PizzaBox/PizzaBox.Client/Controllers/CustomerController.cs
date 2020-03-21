using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class CustomerController : Controller
  {    
    [HttpGet]
    public IActionResult CustHome()
    {
      return View();
    }
    
    [HttpGet]
    public IActionResult CustHistory()
    {
      return View();
    }

    [HttpGet]
    public IActionResult CustOrder()
    {
      return View();
    }
  }
}