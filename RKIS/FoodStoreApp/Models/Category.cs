using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [DisplayName("��������")]
        public string Title { get; set; }
        [DisplayName("��������")]
        public string? Description { get; set; }
        [DisplayName("�������")]
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [Range(1, int.MaxValue, ErrorMessage = "�������� ������ ���� ������ ����")]
        public int Rating { get; set; }
        public List<Product>? Products { get; set; }
    }
}