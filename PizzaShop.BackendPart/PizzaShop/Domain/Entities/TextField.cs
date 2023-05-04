using PizzaShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Domain.Entities
{
    public class TextField:EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Name (header)")]
        public override string Title { get; set; } = "Informational page";

        [Display(Name = "Full description")]
        public virtual string Text { get; set; } = "That field only for Admin";
    }
}
