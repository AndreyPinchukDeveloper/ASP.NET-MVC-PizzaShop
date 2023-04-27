using PizzaShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Domain.Entities
{
    public class TextField:EntityBase
    {
        [Required]
        public virtual string Title { get; set; }
        [Display(Name = "Name (header)")]
        public virtual string Title { get; set; }
    }
}
