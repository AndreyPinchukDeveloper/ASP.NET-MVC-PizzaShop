using PizzaShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Domain.Entities
{
    /// <summary>
    /// Any service on the web page
    /// </summary>
    public class ServiceItem:EntityBase
    {
        [Required(ErrorMessage = "Pleaase, fill name of the service")]//this atrribute means that field is mandatory
        [Display(Name = "Name (header)")]
        public override string Title { get; set; }

        [Display(Name = "Full description")]
        public override string Text { get; set; }

        [Display(Name = "Short Description")]
        public override string Subtitle { get; set; }
    }
}
