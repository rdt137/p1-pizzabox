using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  
  public class LocationModel
  {
    private static readonly StoreRepository _sp = new StoreRepository();
    
    public List<Store> Locations { get; set; }
    
    [Required(ErrorMessage = "Please enter a location")]
    public string Location { get; set; }

    public LocationModel()
    {
      Locations = _sp.Get().ToList();
    }
  }
}