using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public IFormFileCollection? Images { get; set; }
        [Display(Name = "Тип категории")]
        public int? CategoryId { get; set; }
        [Required]
        [Display(Name = "Название производителя")]
        public int ManufacturerId { get; set; }
        /// <summary>
        /// Преобразует в класс Product без добавления файлов и объектов Category и Manufacturer.
        /// </summary>
        /// <returns></returns>
        public Product ToProduct()
        {
            return new Product()
            {
                ProductId = this.Id,
                Name = this.Name,
                Description = this.Description,
                Price = Convert.ToDouble(this.Price),
                CategoryId = this.CategoryId,
                ManufacturerId = this.ManufacturerId
            };
        }
        public static ProductViewModel FromProduct(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = Convert.ToDecimal(product.Price),
                CategoryId = product.CategoryId,
                ManufacturerId = product.ManufacturerId
            };
        }
    }
}