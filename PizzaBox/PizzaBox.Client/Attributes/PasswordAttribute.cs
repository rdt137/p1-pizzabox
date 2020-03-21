// using System.ComponentModel.DataAnnotations;
// using PizzaBox.Storing.Repositories;

// namespace PizzaBox.Client2.Attributes
// {
//   public class PasswordAttribute : ValidationAttribute
//   {
//     public static readonly UserRepository _up = new UserRepository();
//     public override bool IsValid(object value)
//     {      
//       if(value is null)
//         return false;
//       return (_up.GetP(value.ToString()) != null);
//     }
//   }
// }