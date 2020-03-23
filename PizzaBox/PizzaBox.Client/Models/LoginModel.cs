using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Models
{
  public class LoginModel
  {
    [Required(ErrorMessage = "Please enter a username")]
    [DataType(DataType.Text)]
    public string Username { get; set; }

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Text)]
    public string Password { get; set; }
  }
}