using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Entites
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]

        [StringLength(255)]
        public string CategoryName { get; set; }
    }
}
