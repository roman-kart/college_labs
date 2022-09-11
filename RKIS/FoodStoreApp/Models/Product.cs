using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        [Display(Name = "Тип категории")]
        public int? CategoryId { get; set; }
        [Required]
        [Display(Name = "Название производителя")]
        public int ManufacturerId { get; set; }
        public Category? Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public List<UserFile>? UserFiles { get; set; }
    }
}