using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string? OtherJsonData { get; set; }
    }
}