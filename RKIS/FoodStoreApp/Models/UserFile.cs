using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models
{
    public class UserFile
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DisplayName("Название")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DisplayName("Содержимое")]
        public byte[] Content { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DisplayName("Тип")]
        public string Type { get; set; }
        public string? OtherJsonData { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}