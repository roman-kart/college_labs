using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models
{
    public class UserFile
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [DisplayName("��������")]
        public string Title { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [DisplayName("����������")]
        public byte[] Content { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [DisplayName("���")]
        public string Type { get; set; }
        public string? OtherJsonData { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}