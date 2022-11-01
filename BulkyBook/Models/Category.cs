using System.ComponentModel.DataAnnotations;
namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Displayorder { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
