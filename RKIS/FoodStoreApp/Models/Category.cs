using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DisplayName("Название")]
        public string Title { get; set; }
        [DisplayName("Описание")]
        public string? Description { get; set; }
        [DisplayName("Рейтинг")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        public int Rating { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}