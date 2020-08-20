using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeaStore.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required, StringLength(15, MinimumLength = 3)]
        [Display(Name = "Название категории")]
        public string Name { get; set; }
    }
}
