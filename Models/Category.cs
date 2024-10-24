using System.ComponentModel.DataAnnotations;

namespace CRUD_Using_MVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        //for the many-to-many relationship
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
