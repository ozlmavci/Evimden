using Evimden.CoreLayer.Concrete.CargoEntities;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.DataAccessLayer.Seeds.LocationSeeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Evimden.DataAccessLayer.Concrete
{
    public class EvimdenDbContext : IdentityDbContext<CustomUser, CustomRole, Guid, CustomUserClaim, CustomUserRole, CustomUserLogin, CustomRoleClaim, CustomUserToken>
    {
        public EvimdenDbContext(DbContextOptions<EvimdenDbContext> options) : base(options)
        {
        }

        #region CARGO
        public DbSet<Shipper> Shippers { get; set; }
        #endregion

        #region LOCATION
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        #endregion

        #region ORDER
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        #endregion

        #region PRODUCT
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductApproval> ProductApprovals { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        #endregion

        #region PROFILE
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PaymentInformation> PaymentInformations { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerApproval> SellerApprovals { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed data for CustomRole
            var adminRoleId = Guid.NewGuid();
            var sellerRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            modelBuilder.Entity<CustomRole>().HasData(
                new CustomRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new CustomRole { Id = sellerRoleId, Name = "Satıcı", NormalizedName = "SATICI" },
                new CustomRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
            );

            // Seed data for CustomUser
            var adminUserId = Guid.NewGuid();
            var sellerUserId = Guid.NewGuid();
            var userUserId = Guid.NewGuid();

            var hasher = new PasswordHasher<CustomUser>();

            modelBuilder.Entity<CustomUser>().HasData(
                new CustomUser
                {
                    Id = adminUserId,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"),
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "User",
                    PhoneNumber = "905559998877",
                    PhoneNumberConfirmed = true
                },
                new CustomUser
                {
                    Id = sellerUserId,
                    UserName = "seller",
                    NormalizedUserName = "SELLER",
                    Email = "seller@example.com",
                    NormalizedEmail = "SELLER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Seller123!"),
                    SecurityStamp = string.Empty,
                    FirstName = "Özlem",
                    LastName = "Avcı",
                    PhoneNumber = "905551112233",
                    PhoneNumberConfirmed = true
                },
                new CustomUser
                {
                    Id = userUserId,
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User123!"),
                    SecurityStamp = string.Empty,
                    FirstName = "Hande",
                    LastName = "Boz",
                    PhoneNumber = "905556665544",
                    PhoneNumberConfirmed = true
                }
            );

            // Seed data for CustomUserRole
            modelBuilder.Entity<CustomUserRole>().HasData(
                new CustomUserRole { UserId = adminUserId, RoleId = adminRoleId },
                new CustomUserRole { UserId = sellerUserId, RoleId = sellerRoleId },
                new CustomUserRole { UserId = userUserId, RoleId = userRoleId }
            );

            // Seed data for Country
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 90, CountryName = "Türkiye" }
            );

            // Seed data for City
            modelBuilder.Entity<City>().HasData(CitySeed.GetCitiesSeeds());

            // Seed data for District
            modelBuilder.Entity<District>().HasData(DistrictSeed.GetDistrictsSeeds());

            // Seed data for Seller
            var sellerId = Guid.NewGuid();
            modelBuilder.Entity<Seller>().HasData(
                new Seller
                {
                    SellerId = sellerId,
                    UserId = sellerUserId,
                    CountryId = 90,
                    CityId = 34, //İstanbul
                    DistrictId = 467, //Kadıköy
                    ShopName = "Evimden Mağaza",
                    Tckn = "12345678901",
                    Vkn = "1234567890",
                    ShopImagePath = "path/to/image",
                    About = "Evimden mağazasının yetkili satıcısıdır.",
                    IsApproved = true,
                    IsBanned = false
                }
            );

            // Seed data for Category and Subcategories
            var categories = new List<Category>
            {
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Erişte", Description = "Erişte Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Mantı", Description = "Mantı Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Kahvaltılık", Description = "Kahvaltılık Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Turşu", Description = "Turşu Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Hazır Yemek", Description = "Hazır Yemek Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Salça", Description = "Salça Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Tatlı", Description = "Tatlı Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Çorba", Description = "Çorba Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = Guid.Empty, CategoryName = "Kurutulmuş Meyve ve Sebze", Description = "Kurutulmuş Meyve ve Sebze Çeşitleri" }
            };

            var subcategories = new List<Category>
            {
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[0].CategoryId, CategoryName = "Tam Buğday Erişte", Description = "Tam Buğday Erişte" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[0].CategoryId, CategoryName = "Yumurtalı Erişte", Description = "Yumurtalı Erişte" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[0].CategoryId, CategoryName = "Sebzeli Erişte", Description = "Sebzeli Erişte" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[1].CategoryId, CategoryName = "Kayseri Mantısı", Description = "Kayseri Mantısı" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[1].CategoryId, CategoryName = "Sinop Mantısı", Description = "Sinop Mantısı" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[1].CategoryId, CategoryName = "Tepsi Mantısı", Description = "Tepsi Mantısı" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[1].CategoryId, CategoryName = "Hingel", Description = "Hingel" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[1].CategoryId, CategoryName = "Silor", Description = "Silor" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[2].CategoryId, CategoryName = "Reçel", Description = "Reçel Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[2].CategoryId, CategoryName = "Pekmez", Description = "Pekmez" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[2].CategoryId, CategoryName = "Fındık Ezmesi", Description = "Fındık Ezmesi" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[2].CategoryId, CategoryName = "Fıstık Ezmesi", Description = "Fıstık Ezmesi" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[3].CategoryId, CategoryName = "Biber Turşusu", Description = "Biber Turşusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[3].CategoryId, CategoryName = "Kornişon Turşusu", Description = "Kornişon Turşusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[3].CategoryId, CategoryName = "Jalapeno Turşusu", Description = "Jalapeno Turşusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[3].CategoryId, CategoryName = "Acur Turşusu", Description = "Acur Turşusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[3].CategoryId, CategoryName = "Lahana Turşusu", Description = "Lahana Turşusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[3].CategoryId, CategoryName = "Sarımsak Turşusu", Description = "Sarımsak Turşusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[3].CategoryId, CategoryName = "Kırmızı Pancar Turşusu", Description = "Kırmızı Pancar Turşusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[4].CategoryId, CategoryName = "İçli Köfte", Description = "İçli Köfte Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[4].CategoryId, CategoryName = "Bazlama", Description = "Bazlama" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[4].CategoryId, CategoryName = "İçli Börek", Description = "İçli Börek Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[4].CategoryId, CategoryName = "Katmer", Description = "Katmer" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[5].CategoryId, CategoryName = "Domates Salçası", Description = "Domates Salçası" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[5].CategoryId, CategoryName = "Biber Salçası", Description = "Biber Salçası" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[6].CategoryId, CategoryName = "Kurabiye", Description = "Kurabiye Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[6].CategoryId, CategoryName = "Baklava", Description = "Baklava Çeşitleri" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[7].CategoryId, CategoryName = "Tarhana Çorbası", Description = "Tarhana Çorbası" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Mandalina Kurusu", Description = "Mandalina Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Portakal Kurusu", Description = "Portakal Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Elma Kurusu", Description = "Elma Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Limon Kurusu", Description = "Limon Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Armut Kurusu", Description = "Armut Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Trabzon Hurması Kurusu", Description = "Trabzon Hurması Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Çilek Kurusu", Description = "Çilek Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "İncir Kurusu", Description = "İncir Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Kayısı Kurusu", Description = "Kayısı Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Dut Kurusu", Description = "Dut Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Domates Kurusu", Description = "Domates Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Ananas Kurusu", Description = "Ananas Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Dolmalık Patlıcan Kurusu", Description = "Dolmalık Patlıcan Kurusu" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = categories[8].CategoryId, CategoryName = "Dolmalık Biber Kurusu", Description = "Dolmalık Biber Kurusu" }
            };

            var subsubcategories = new List<Category>
            {
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "Çilek Reçeli", Description = "Çilek Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "Kayısı Reçeli", Description = "Kayısı Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "Vişne Reçeli", Description = "Vişne Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "Ahududu Reçeli", Description = "Ahududu Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "Ayva Reçeli", Description = "Ayva Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "Şeftali Reçeli", Description = "Şeftali Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "İncir Reçeli", Description = "İncir Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "Böğürtlen Reçeli", Description = "Böğürtlen Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[8].CategoryId, CategoryName = "Gül Reçeli", Description = "Gül Reçeli" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[33].CategoryId, CategoryName = "Kıymalı İçli Köfte", Description = "Kıymalı İçli Köfte" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[33].CategoryId, CategoryName = "Vegan İçli Köfte", Description = "Vegan İçli Köfte" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[35].CategoryId, CategoryName = "Patatesli Börek", Description = "Patatesli Börek" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[35].CategoryId, CategoryName = "Ispanaklı Börek", Description = "Ispanaklı Börek" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[35].CategoryId, CategoryName = "Kıymalı Börek", Description = "Kıymalı Börek" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[38].CategoryId, CategoryName = "Un Kurabiyesi", Description = "Un Kurabiyesi" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[38].CategoryId, CategoryName = "Mantar Kurabiye", Description = "Mantar Kurabiye" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[38].CategoryId, CategoryName = "Elmalı Kurabiye", Description = "Elmalı Kurabiye" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[38].CategoryId, CategoryName = "Cookie", Description = "Cookie" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[39].CategoryId, CategoryName = "Fıstıklı Baklava", Description = "Fıstıklı Baklava" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[39].CategoryId, CategoryName = "Cevizli Baklava", Description = "Cevizli Baklava" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[39].CategoryId, CategoryName = "Kuru Baklava", Description = "Kuru Baklava" },
                new Category { CategoryId = Guid.NewGuid(), ParrentCategoryId = subcategories[39].CategoryId, CategoryName = "Midye Baklava", Description = "Midye Baklava" },
            };
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Category>().HasData(subcategories);
            modelBuilder.Entity<Category>().HasData(subsubcategories);

            // Seed data for Product
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    CategoryId = subcategories[0].CategoryId, // Tam Buğday Erişte
                    SellerId = sellerId,
                    ProductName = "Tam Buğday Erişte",
                    Description = "Sağlıklı ve lezzetli tam buğday erişte. Pakette 500g.",
                    Price = 20.0m,
                    DiscountRate = 0m,
                    ContainGluten = true,
                    IsVisiable = true,
                    IsApproved = true
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    CategoryId = subcategories[4].CategoryId, // Kayseri Mantısı
                    SellerId = sellerId,
                    ProductName = "Kayseri Mantısı",
                    Description = "Geleneksel Kayseri mantısı. Pakette 1kg",
                    Price = 50.0m,
                    DiscountRate = 0m,
                    ContainGluten = true,
                    IsVisiable = true,
                    IsApproved = true
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    CategoryId = subsubcategories[0].CategoryId, // Çilek Reçeli
                    SellerId = sellerId,
                    ProductName = "Çilek Reçeli ",
                    Description = "Doğal ve taze çilek reçeli. Kavanozda 400g.",
                    Price = 25.0m,
                    DiscountRate = 0m,
                    ContainGluten = false,
                    IsVisiable = true,
                    IsApproved = true
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    CategoryId = subcategories[20].CategoryId, // Domates Salçası
                    SellerId = sellerId,
                    ProductName = "Domates Salçası",
                    Description = "Ev yapımı doğal domates salçası. Kavanozda 700g.",
                    Price = 30.0m,
                    DiscountRate = 0m,
                    ContainGluten = false,
                    IsVisiable = true,
                    IsApproved = true
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    CategoryId = subcategories[35].CategoryId, // Patatesli Börek
                    SellerId = sellerId,
                    ProductName = "Patatesli Börek",
                    Description = "Lezzetli ve çıtır patatesli börek. Posriyonda 6 Adet",
                    Price = 40.0m,
                    DiscountRate = 0m,
                    ContainGluten = true,
                    IsVisiable = true,
                    IsApproved = true
                }
            };
            modelBuilder.Entity<Product>().HasData(products);

            // Seed data for ProductImage
            var productImages = new List<ProductImage>
            {
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid(),
                    ProductId = products[0].ProductId,
                    ImagePath = "images/products/tam_bugday_eriste.jpg",
                    SavedFileName = "tam_bugday_eriste.jpg"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid(),
                    ProductId = products[1].ProductId,
                    ImagePath = "images/products/kayseri_mantisi.jpg",
                    SavedFileName = "kayseri_mantisi.jpg"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid(),
                    ProductId = products[2].ProductId,
                    ImagePath = "images/products/cilek_receli.jpg",
                    SavedFileName = "cilek_receli.jpg"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid(),
                    ProductId = products[3].ProductId,
                    ImagePath = "images/products/domates_salcası.jpg",
                    SavedFileName = "domates_salcası.jpg"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid(),
                    ProductId = products[4].ProductId,
                    ImagePath = "images/products/patatesli_borek.jpg",
                    SavedFileName = "patatesli_borek.jpg"
                }
            };
            modelBuilder.Entity<ProductImage>().HasData(productImages);

            // Seed data for Shipper
            var shipperId = Guid.NewGuid();
            modelBuilder.Entity<Shipper>().HasData(
                new Shipper
                {
                    ShipperId = shipperId,
                    CountryId = 90,
                    ShipperName = "Example Shipper",
                    ContactName = "Contact Name",
                    PhoneNumber = "1234567890",
                    Email = "shipper@example.com",
                    ApiUrl = "https://api.example.com",
                    ApiKey = "API_KEY"
                }
            );
        }
    }
}
