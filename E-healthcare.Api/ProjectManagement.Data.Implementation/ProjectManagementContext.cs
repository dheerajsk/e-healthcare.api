using EHealthcare.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions options) : base(options)
        {

        }

        public void SeedInitialData()
        {
            User testUser1 = new User
            {
                FirstName = "Test",
                LastName = "User1",
                Password = "Password1",
                Email = "testuser1@test.com",
            };
            User adminUser = new User
            {
                FirstName = "Admin",
                LastName = "",
                Password = "Password1",
                Email = "admin@test.com",
                IsAdmin = true
            };

            User.Add(testUser1);
            User.Add(adminUser);

            Category cat = new Category
            {
                Name = "Capsules"
            };
            Category cat2 = new Category
            {
                Name = "Injections"
            };
            Category cat3 = new Category
            {
                Name = "Fitness"
            };

            Category.Add(cat);
            Category.Add(cat2);
            Category.Add(cat3);

            Product testProduct1 = new Product { IsActive = true, CategoryID = 1, Name = "Nutriosys Isabgol", Detail = "Nutriosys Isabgol 500mg - 90 Veg Capsules", Price = 525, ImgSrc = "https://m.media-amazon.com/images/I/51inZITDWAL._AC_UL320_.jpg" };
            Product testProduct2 = new Product { IsActive = true, CategoryID = 1, Name = "Herbocalm Capsules", Detail = "DR. VAIDYA'S Herbocalm Capsules Ayurvedic Medicine for Relief from Stress and Anxiety 30 Capsules Each (Pack of 2)", Price = 374, ImgSrc = "https://m.media-amazon.com/images/I/614040xGJKL._AC_UL320_.jpg" };
            Product testProduct3 = new Product { IsActive = true, CategoryID = 1, Name = "Becosules Capsule 20'S", Detail = "ASCORBIC ACID(VIT C)+BIOTIN+Calcium Pantothenate+Cyanocobalamin(Vit B12)+FOLIC ACID+Niacinamide(Nicotinamide/Vit B3)+Pyridoxine Hydrochloride(Vit B6)+RIBOFLAVIN(VIT B2)+Thiamine Hydrochloride", Price = 33, ImgSrc = "https://www.netmeds.com/images/product-v1/600x600/341517/becosules_capsule_20_s_0.jpg" };
            Product testProduct4 = new Product { IsActive = true, CategoryID = 2, Name = "Optineuron Injection 3ml ", Detail = "CYANOCOBALAMIN 1000 MCG+Thiamine Hydrochloride(Vit B1) 100 MG+Pyridoxine Hydrochloride(Vit B6) 100 MG+CYANOCOBALAMIN 1000MCG+Riboflavin Sodium Phosphate 5 MG+D PANTHENOL 50", Price = 8, ImgSrc = "https://www.netmeds.com/images/product-v1/600x600/305127/optineuron_injection_3ml_0.jpg" };
            Product testProduct5 = new Product { IsActive = true, CategoryID = 2, Name = "Lacarnit Injection 5ml", Detail = "Lacarnit Injection 5ml", Price = 110, ImgSrc = "https://www.netmeds.com/images/product-v1/600x600/347820/lacarnit_injection_5ml_0.jpg" };
            Product testProduct6 = new Product { IsActive = true, CategoryID = 2, Name = "Methycobal Injection 1ml", Detail = "MECOBALAMIN(METHYLCOBALAMIN) 500 MCG", Price = 90, ImgSrc = "https://www.netmeds.com/images/product-v1/600x600/330110/methycobal_injection_1ml_0.jpg" };
            Product testProduct7 = new Product { IsActive = true, CategoryID = 3, Name = "Nutritional Powder ", Detail = "Pro360 Dry Fruits Nutritional Powder 250 gm", Price = 314, ImgSrc = "https://www.netmeds.com/images/product-v1/600x600/889029/pro360_dry_fruits_nutritional_powder_250_gm_0.jpg" };
            Product testProduct8 = new Product { IsActive = true, CategoryID = 3, Name = "Weight Gainer", Detail = "Pro360 Adult Weight Gainer Nutritional Powder - Chocolate Flavour 250 gm", Price = 369, ImgSrc = "https://www.netmeds.com/images/product-v1/600x600/889022/pro360_weight_gainer_nutritional_powder_chocolate_flavour_250_gm_0.jpg" };
            Product testProduct9 = new Product { IsActive = true, CategoryID = 3, Name = "Nutritional Powder", Detail = "Pro360 Slim Nutritional Powder - Choco Vanilla Flavour 500 gm", Price = 548, ImgSrc = "https://www.netmeds.com/images/product-v1/600x600/889017/pro360_slim_nutritional_powder_choco_vanilla_flavour_500_gm_0.jpg" };

            Product.Add(testProduct1);
            Product.Add(testProduct2);
            Product.Add(testProduct3);
            Product.Add(testProduct4);
            Product.Add(testProduct5);
            Product.Add(testProduct6);
            Product.Add(testProduct7);
            Product.Add(testProduct8);
            Product.Add(testProduct9);
            this.SaveChanges();
        }

        public DbSet<User> User { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
