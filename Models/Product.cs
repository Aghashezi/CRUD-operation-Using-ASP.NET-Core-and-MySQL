using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Using_MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public required string ProductName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Tags { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }

        [NotMapped]
        public required List<int> SelectedCategories { get; set; }
    }
}
