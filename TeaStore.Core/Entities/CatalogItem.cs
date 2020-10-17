using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeaStore.Core.Entities.WeightAggregate;

namespace TeaStore.Core.Entities
{
    public class CatalogItem : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0.99, 9999999999999999.99, ErrorMessage = "Цена должна быть больше 0")]
        public decimal Price { get; set; }

        public string PictureUri { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Под категория")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public List<WeightCatalogItem> WeightMenuItems { get; set; }
    }
}
