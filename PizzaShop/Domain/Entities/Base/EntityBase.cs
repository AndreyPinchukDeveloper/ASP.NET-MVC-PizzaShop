using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }//primary key

        [Display(Name = "Name (header)")]
        public virtual string Title { get; set; }

        [Display(Name = "Short Description")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Full description")]
        public virtual string Text { get; set; }

        [Display(Name = "Title image")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO metatag title")]
        public virtual string MetaTitle { get; set; }

        [Display(Name = "SEO metatag description")]
        public virtual string MetaDescription { get; set; }

        [Display(Name = "SEO metatag Keywords")]
        public virtual string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}