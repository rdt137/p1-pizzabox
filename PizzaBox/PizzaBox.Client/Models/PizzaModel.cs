using System.Collections.Generic;
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
    public string size { get; set; }
    public string pizzaType { get; set; }
    public decimal Cost { get; set; }

    public PizzaModel()
    {
      SizeList = _sr.Get().ToList();
      PizzaList = _ptr.Get().ToList();
    }
  }
}