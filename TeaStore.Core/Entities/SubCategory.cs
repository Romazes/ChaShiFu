using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaStore.Core.Entities
{
    public class SubCategory : BaseEntity
    {
        [Required, Display(Name = "Название под-категории")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
