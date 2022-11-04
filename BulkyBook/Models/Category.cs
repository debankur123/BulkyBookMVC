using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,50,ErrorMessage ="Order should be within 1 to 50")]
        public int Displayorder { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
