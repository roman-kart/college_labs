using FoodStoreApp.Models;
using Microsoft.EntityFrameworkCore;
namespace FoodStoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
        DbContextOptions< ApplicationDbContext> options) : base(options){}
        public DbSet<Category> Category { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }
    }
}