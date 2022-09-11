using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [DisplayName("��������")]
        public string Title { get; set; }
        [DisplayName("��������")]
        public string? Description { get; set; }
        [DisplayName("�������")]
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [Range(1, int.MaxValue, ErrorMessage = "�������� ������ ���� ������ ����")]
        public int Rating { get; set; }
        public string? OtherJsonData { get; set; }
        public List<Product>? Products { get; set; }
    }
}