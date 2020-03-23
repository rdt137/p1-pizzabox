using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class PizzaModel
  {
    private static readonly PizzaTypeRepository _ptr = new PizzaTypeRepository();
    private static readonly SizeRepository _sr = new SizeRepository();

    public List<PizzaType> PizzaList { get; set; }
    public List<Size> SizeList { get; set; }  
    [Required(ErrorMessage = "Please enter a size")]
    public string size { get; set; }
    [Required(ErrorMessage = "Please enter a pizza type")]
    public string pizzaType { get; set; }
    public decimal Cost { get; set; }

    public PizzaModel()
    {
      SizeList = _sr.Get().ToList();
      PizzaList = _ptr.Get().ToList();
    }
  }
}