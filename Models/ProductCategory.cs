using System.ComponentModel.DataAnnotations;

namespace CRUD_Using_MVC.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
