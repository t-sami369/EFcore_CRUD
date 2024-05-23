using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcore_CRUD.Models
{
    public class Product
    {
        [Key]
        [Required]
        [Column("product_id", Order = 0)]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        [Required]
        public double Price { get; set; }

        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

    }
}

    

