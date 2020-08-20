using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeaStore.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required, StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
