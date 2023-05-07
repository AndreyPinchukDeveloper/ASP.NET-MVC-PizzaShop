using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Identity.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]//this field is mandatory
        [DataType(DataType.Password)]//this field would be show as ***
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
