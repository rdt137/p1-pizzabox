using System.ComponentModel.DataAnnotations;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Attributes
{
  public class UsernameAttribute : ValidationAttribute
  {
    public static readonly UserRepository _up = new UserRepository();
    public override bool IsValid(object value)
    {      
      if(value is null)
        return false;
      return (_up.Get(value.ToString()) != null);
    }
  }
}