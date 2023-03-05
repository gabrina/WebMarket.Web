using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Models
{
    public class Category
    {
        [Key]//this is a data annotation
        public int ID { get; set; }
        [Required(ErrorMessage ="عنوان دسته اجباری است")]//this is a data annotation, to customize error messages
        [DisplayName("عنوان دسته")]//change label
        public string Name { get; set; }
        [Required(ErrorMessage = "ترتیب اجباری است")]//this is a data annotation, to customize error messages
        [DisplayName("ترتیب نمایش")]
        [Range(1,100,ErrorMessage ="ترتیب نمایش باید در محدوده باشد")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
