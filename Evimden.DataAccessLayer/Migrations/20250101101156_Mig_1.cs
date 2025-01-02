using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Evimden.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParrentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInformations",
                columns: table => new
                {
                    PaymentInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpirationMonth = table.Column<int>(type: "int", nullable: false),
                    ExpirationYear = table.Column<int>(type: "int", nullable: false),
                    Cvv = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInformations", x => x.PaymentInformationId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ShipperName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApiUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperId);
                    table.ForeignKey(
                        name: "FK_Shippers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponId);
                    table.ForeignKey(
                        name: "FK_Coupons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    PhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    PaymentInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionStatus = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRefunded = table.Column<bool>(type: "bit", nullable: false),
                    RefundDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "CouponId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentInformations_PaymentInformationId",
                        column: x => x.PaymentInformationId,
                        principalTable: "PaymentInformations",
                        principalColumn: "PaymentInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    AddressText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_Addresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId");
                    table.ForeignKey(
                        name: "FK_Addresses_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "PhoneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    ShopName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tckn = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Vkn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ShopImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                    table.ForeignKey(
                        name: "FK_Sellers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellers_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContainGluten = table.Column<bool>(type: "bit", nullable: false),
                    IsVisiable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerApprovals",
                columns: table => new
                {
                    SellerApprovalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerApprovals", x => x.SellerApprovalId);
                    table.ForeignKey(
                        name: "FK_SellerApprovals_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CargoTrackingCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Orders_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductApprovals",
                columns: table => new
                {
                    ProductApprovalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductApprovals", x => x.ProductApprovalId);
                    table.ForeignKey(
                        name: "FK_ProductApprovals_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCarts",
                columns: table => new
                {
                    ProductCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCarts", x => x.ProductCartId);
                    table.ForeignKey(
                        name: "FK_ProductCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SavedFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CreatedDate", "Description", "IsActive", "ParrentCategoryId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("023da31c-e48b-4324-bd5a-037d284925b6"), "Kuru Baklava", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuru Baklava", false, new Guid("905eb656-34f7-41bf-87e2-0239308d0338"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0787e6e5-960f-4baa-93b2-550032a11523"), "Pekmez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pekmez", false, new Guid("ca26ba03-87e2-448d-a26f-24e65b4099fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("126a19bb-eff3-410a-a8d1-9d979a2443ee"), "Ispanaklı Börek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ispanaklı Börek", false, new Guid("cd77924b-c42f-47d8-b19b-a2ff6eddc7da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("157091b6-59b7-4dbc-82a2-a17c18eae515"), "Domates Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domates Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e1a70be-7db9-4108-a99b-db187757b1bd"), "Silor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silor", false, new Guid("66e027a8-d59d-4165-9542-39042bdbc6c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("201a6fcc-66dd-4515-b93e-149da95b2483"), "İçli Börek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İçli Börek Çeşitleri", false, new Guid("4c5a6c92-f82c-41ab-a748-0be2931a39b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("232eee05-021f-4992-9a45-abae440ba1c3"), "Kayseri Mantısı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kayseri Mantısı", false, new Guid("66e027a8-d59d-4165-9542-39042bdbc6c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2405690d-f3fe-40f6-bc87-59c2406c43f3"), "Sinop Mantısı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinop Mantısı", false, new Guid("66e027a8-d59d-4165-9542-39042bdbc6c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2560c252-c2cb-4772-a9bf-45bea47a3d4c"), "Tepsi Mantısı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tepsi Mantısı", false, new Guid("66e027a8-d59d-4165-9542-39042bdbc6c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2869e35d-2d41-47d7-baa0-0c907072a66f"), "Hingel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hingel", false, new Guid("66e027a8-d59d-4165-9542-39042bdbc6c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b69aab9-4b8b-4f96-ace5-4c51a845db2e"), "Un Kurabiyesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Un Kurabiyesi", false, new Guid("157091b6-59b7-4dbc-82a2-a17c18eae515"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e5b011b-b2ec-4bd9-8361-43f72a8732cb"), "Salça", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salça Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2fa3fc14-ff72-48ad-bad5-9b29ae224002"), "Kayısı Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kayısı Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("332ef17e-1d8d-4d8a-bade-bca401074c95"), "Baklava", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baklava Çeşitleri", false, new Guid("8769f41f-e2fa-4556-94d8-4d112a3c637f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("379263a9-04e1-417c-8e16-61da6321b9bd"), "Çorba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çorba Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("386b808e-4672-468e-bfc6-25579f1b4bb4"), "Mantar Kurabiye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mantar Kurabiye", false, new Guid("157091b6-59b7-4dbc-82a2-a17c18eae515"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3a9c7a2e-a250-409f-a688-3c2a7946ce25"), "Kırmızı Pancar Turşusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kırmızı Pancar Turşusu", false, new Guid("b2921222-70ff-481c-b6b3-fd749a897854"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c01b57f-07ff-496f-8336-63c42aab070b"), "Dut Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dut Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("404a767a-3487-4415-aa66-b4a508180bf3"), "Kıymalı İçli Köfte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kıymalı İçli Köfte", false, new Guid("dcfe5290-ebe9-4527-a848-ea698c0bc2f5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43a92ff0-6e41-4632-b6ba-d57c3e5b9995"), "Böğürtlen Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Böğürtlen Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43b984e4-b549-43a4-8f28-db3767dc47d1"), "İncir Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İncir Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44164eac-6213-462b-8c79-51d9ce1ef36e"), "Dolmalık Biber Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolmalık Biber Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44872bfd-f370-46cf-ae38-13104b6534dd"), "Fıstık Ezmesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fıstık Ezmesi", false, new Guid("ca26ba03-87e2-448d-a26f-24e65b4099fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49e2ca22-2c94-4190-9a7b-20dfcda3d9e3"), "Kornişon Turşusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kornişon Turşusu", false, new Guid("b2921222-70ff-481c-b6b3-fd749a897854"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b0b963c-0d5d-44ee-8cbc-91472ae4579c"), "Mandalina Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mandalina Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c5a6c92-f82c-41ab-a748-0be2931a39b4"), "Hazır Yemek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hazır Yemek Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("54e96dbe-d471-4d08-8681-e85892b51558"), "Kurabiye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kurabiye Çeşitleri", false, new Guid("8769f41f-e2fa-4556-94d8-4d112a3c637f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("586698c8-5a89-4252-b5dd-4f3f237706e4"), "Tarhana Çorbası", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarhana Çorbası", false, new Guid("379263a9-04e1-417c-8e16-61da6321b9bd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59537073-1e9c-4f5c-a2a3-a872a3dc47f4"), "Şeftali Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şeftali Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ffcae76-44b8-4036-a321-2e88d5a6b5d9"), "Vegan İçli Köfte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vegan İçli Köfte", false, new Guid("dcfe5290-ebe9-4527-a848-ea698c0bc2f5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60b5accc-d07e-4583-9c52-187ced2bfdb4"), "Elmalı Kurabiye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elmalı Kurabiye", false, new Guid("157091b6-59b7-4dbc-82a2-a17c18eae515"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), "Kurutulmuş Meyve ve Sebze", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kurutulmuş Meyve ve Sebze Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("66da9a75-b8df-45ec-9dd3-7b6b04fb2a08"), "Ayva Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayva Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("66e027a8-d59d-4165-9542-39042bdbc6c8"), "Mantı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mantı Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6774f570-abb9-4ee4-a21a-794c0910476d"), "Patatesli Börek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patatesli Börek", false, new Guid("cd77924b-c42f-47d8-b19b-a2ff6eddc7da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b513f25-45c0-4675-813d-894642156425"), "İçli Köfte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İçli Köfte Çeşitleri", false, new Guid("4c5a6c92-f82c-41ab-a748-0be2931a39b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), "Reçel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reçel Çeşitleri", false, new Guid("ca26ba03-87e2-448d-a26f-24e65b4099fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ffee8a4-ef4b-4698-b4b4-ec3f6d5f3823"), "Portakal Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portakal Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8769f41f-e2fa-4556-94d8-4d112a3c637f"), "Tatlı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tatlı Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ace12d6-0b29-4cde-94e6-90a1b762cd2f"), "Midye Baklava", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midye Baklava", false, new Guid("905eb656-34f7-41bf-87e2-0239308d0338"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8d908982-14b9-4537-a661-5e1dcd0455ec"), "Limon Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limon Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("905eb656-34f7-41bf-87e2-0239308d0338"), "Ananas Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ananas Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91d568d9-df38-4bde-bcb3-b0afc6ca9d75"), "Yumurtalı Erişte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yumurtalı Erişte", false, new Guid("f41c3adf-6496-4355-a5c7-f918f28df9cf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94a3443a-34fb-40e3-8aa2-e3e3d21cdacd"), "Tam Buğday Erişte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tam Buğday Erişte", false, new Guid("f41c3adf-6496-4355-a5c7-f918f28df9cf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94e7fc08-89f7-49e5-9c78-1c41722849a6"), "Biber Salçası", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biber Salçası", false, new Guid("2e5b011b-b2ec-4bd9-8361-43f72a8732cb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a89e911-d120-40e1-a810-fce844f4f257"), "Fıstıklı Baklava", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fıstıklı Baklava", false, new Guid("905eb656-34f7-41bf-87e2-0239308d0338"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9cbc99ac-4178-4339-a41a-28a560054198"), "Vişne Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vişne Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1bb5e57-0dca-4a4c-ab9b-a5cfbe1aeeee"), "Acur Turşusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acur Turşusu", false, new Guid("b2921222-70ff-481c-b6b3-fd749a897854"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a23d345d-21da-42b2-bab4-89b45faf2147"), "Çilek Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çilek Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2fb3b5d-c3db-4256-b507-1157724efedd"), "Elma Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elma Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a392dccd-b67a-4077-8e9c-98c512ac90c4"), "Kıymalı Börek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kıymalı Börek", false, new Guid("cd77924b-c42f-47d8-b19b-a2ff6eddc7da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad2a7566-12c5-4546-8788-4ee7dd842725"), "Armut Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armut Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aff65537-522e-4a9e-9b9b-e26bfa57dd8c"), "Dolmalık Patlıcan Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolmalık Patlıcan Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2921222-70ff-481c-b6b3-fd749a897854"), "Turşu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turşu Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b50df1d6-9f61-4f2d-818f-6cdd013fcaaa"), "Bazlama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bazlama", false, new Guid("4c5a6c92-f82c-41ab-a748-0be2931a39b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b86b490d-fff1-4a4a-8db2-0a377bbda057"), "Lahana Turşusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lahana Turşusu", false, new Guid("b2921222-70ff-481c-b6b3-fd749a897854"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c3d74613-42e5-4970-9a6c-9e71d9cd3136"), "Kayısı Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kayısı Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8addb22-168e-493a-a7e2-d464d05779d2"), "Gül Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gül Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca26ba03-87e2-448d-a26f-24e65b4099fa"), "Kahvaltılık", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kahvaltılık Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd77924b-c42f-47d8-b19b-a2ff6eddc7da"), "İncir Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İncir Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd937c91-7bc9-40a7-b82c-cb1ffc1561f7"), "Cevizli Baklava", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cevizli Baklava", false, new Guid("905eb656-34f7-41bf-87e2-0239308d0338"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1db3fda-c1e5-4bb5-9a5f-2e917fa6938b"), "Fındık Ezmesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fındık Ezmesi", false, new Guid("ca26ba03-87e2-448d-a26f-24e65b4099fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d4a067e1-59fd-4ba5-89c5-cc5ce70db50b"), "Domates Salçası", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domates Salçası", false, new Guid("2e5b011b-b2ec-4bd9-8361-43f72a8732cb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d8e7e673-dae2-4fda-bc5f-9bd4a4bff051"), "Sebzeli Erişte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sebzeli Erişte", false, new Guid("f41c3adf-6496-4355-a5c7-f918f28df9cf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9132e65-051f-4f55-b9d9-42b670330f67"), "Jalapeno Turşusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jalapeno Turşusu", false, new Guid("b2921222-70ff-481c-b6b3-fd749a897854"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcfe5290-ebe9-4527-a848-ea698c0bc2f5"), "Trabzon Hurması Kurusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trabzon Hurması Kurusu", false, new Guid("628350c8-45b0-4576-bb92-a243e07060e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("df834ca1-0a0e-4006-8c10-3a41b6bbce28"), "Katmer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katmer", false, new Guid("4c5a6c92-f82c-41ab-a748-0be2931a39b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8640b26-265d-437a-802f-76c6f12859b8"), "Biber Turşusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biber Turşusu", false, new Guid("b2921222-70ff-481c-b6b3-fd749a897854"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ecc18ff7-f2a7-4c41-b59e-a3d677b6d627"), "Sarımsak Turşusu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarımsak Turşusu", false, new Guid("b2921222-70ff-481c-b6b3-fd749a897854"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3f7c68e-340d-4686-a127-288f3aa8a4fe"), "Ahududu Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahududu Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f41c3adf-6496-4355-a5c7-f918f28df9cf"), "Erişte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erişte Çeşitleri", false, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f86ff802-3b53-4f25-804f-413505183768"), "Cookie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cookie", false, new Guid("157091b6-59b7-4dbc-82a2-a17c18eae515"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffaa9d6e-0458-4c8a-9e79-1a576c39c0c4"), "Çilek Reçeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çilek Reçeli", false, new Guid("6b8d75fa-0c80-4223-ac47-619f968e04e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[] { 90, "Türkiye" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("435711fc-9d8d-4df6-ac57-6b65317aa7e1"), null, "Admin", "ADMIN" },
                    { new Guid("519ab070-ad4a-49e6-918c-fe501149cd45"), null, "Satıcı", "SATICI" },
                    { new Guid("d9a3861e-6ddf-4eab-b48c-c8fbe86495ad"), null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("66f0fc31-5251-4df3-a2e0-83a8fa5375f2"), 0, "f916ea05-6383-4abc-aa95-f41c0ce4e502", "user@example.com", true, "Hande", "Boz", false, null, "USER@EXAMPLE.COM", "USER", "AQAAAAIAAYagAAAAEH4wYSozEGNOxTcDUPcODYxiSJCI27xNs5deP7X2evCrLptGD3khqjVT87vQxYIBhA==", null, false, "", false, "user" },
                    { new Guid("cd95e03c-da5a-4a4d-965c-a630055b8b3e"), 0, "76d6646c-3e70-4ea0-a892-8d28dcd66aea", "admin@example.com", true, "Admin", "User", false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEJ2gsticCv1Obd1Es9ybKCvqysKhaB52aKnRscmRc8dMpIoFFio7HOx4lNa7wfwj6A==", null, false, "", false, "admin" },
                    { new Guid("f593a9b2-2cac-4844-853c-c4c689b4cbbd"), 0, "6810bb04-892d-41dc-b9b4-03918089ab23", "seller@example.com", true, "Özlem", "Avcı", false, null, "SELLER@EXAMPLE.COM", "SELLER", "AQAAAAIAAYagAAAAEA66ndZMg/fiJx8KfgoFrASXUIwcyjSVapxHcLoHezWdpvhYHTiu8DKW1OrB3L8+3Q==", null, false, "", false, "seller" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[,]
                {
                    { 1, "Adana", 90 },
                    { 2, "Adıyaman", 90 },
                    { 3, "Afyonkarahisar", 90 },
                    { 4, "Ağrı", 90 },
                    { 5, "Amasya", 90 },
                    { 6, "Ankara", 90 },
                    { 7, "Antalya", 90 },
                    { 8, "Artvin", 90 },
                    { 9, "Aydın", 90 },
                    { 10, "Balıkesir", 90 },
                    { 11, "Bilecik", 90 },
                    { 12, "Bingöl", 90 },
                    { 13, "Bitlis", 90 },
                    { 14, "Bolu", 90 },
                    { 15, "Burdur", 90 },
                    { 16, "Bursa", 90 },
                    { 17, "Çanakkale", 90 },
                    { 18, "Çankırı", 90 },
                    { 19, "Çorum", 90 },
                    { 20, "Denizli", 90 },
                    { 21, "Diyarbakır", 90 },
                    { 22, "Edirne", 90 },
                    { 23, "Elâzığ", 90 },
                    { 24, "Erzincan", 90 },
                    { 25, "Erzurum", 90 },
                    { 26, "Eskişehir", 90 },
                    { 27, "Gaziantep", 90 },
                    { 28, "Giresun", 90 },
                    { 29, "Gümüşhane", 90 },
                    { 30, "Hakkâri", 90 },
                    { 31, "Hatay", 90 },
                    { 32, "Isparta", 90 },
                    { 33, "Mersin", 90 },
                    { 34, "İstanbul", 90 },
                    { 35, "İzmir", 90 },
                    { 36, "Kars", 90 },
                    { 37, "Kastamonu", 90 },
                    { 38, "Kayseri", 90 },
                    { 39, "Kırklareli", 90 },
                    { 40, "Kırşehir", 90 },
                    { 41, "Kocaeli", 90 },
                    { 42, "Konya", 90 },
                    { 43, "Kütahya", 90 },
                    { 44, "Malatya", 90 },
                    { 45, "Manisa", 90 },
                    { 46, "Kahramanmaraş", 90 },
                    { 47, "Mardin", 90 },
                    { 48, "Muğla", 90 },
                    { 49, "Muş", 90 },
                    { 50, "Nevşehir", 90 },
                    { 51, "Niğde", 90 },
                    { 52, "Ordu", 90 },
                    { 53, "Rize", 90 },
                    { 54, "Sakarya", 90 },
                    { 55, "Samsun", 90 },
                    { 56, "Siirt", 90 },
                    { 57, "Sinop", 90 },
                    { 58, "Sivas", 90 },
                    { 59, "Tekirdağ", 90 },
                    { 60, "Tokat", 90 },
                    { 61, "Trabzon", 90 },
                    { 62, "Tunceli", 90 },
                    { 63, "Şanlıurfa", 90 },
                    { 64, "Uşak", 90 },
                    { 65, "Van", 90 },
                    { 66, "Yozgat", 90 },
                    { 67, "Zonguldak", 90 },
                    { 68, "Aksaray", 90 },
                    { 69, "Bayburt", 90 },
                    { 70, "Karaman", 90 },
                    { 71, "Kırıkkale", 90 },
                    { 72, "Batman", 90 },
                    { 73, "Şırnak", 90 },
                    { 74, "Bartın", 90 },
                    { 75, "Ardahan", 90 },
                    { 76, "Iğdır", 90 },
                    { 77, "Yalova", 90 },
                    { 78, "Karabük", 90 },
                    { 79, "Kilis", 90 },
                    { 80, "Osmaniye", 90 },
                    { 81, "Düzce", 90 }
                });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "ShipperId", "ApiKey", "ApiUrl", "ContactName", "CountryId", "CreatedDate", "Email", "IsActive", "PhoneNumber", "ShipperName", "UpdatedDate" },
                values: new object[] { new Guid("b842e6ca-26c8-47c5-b99b-02eda17ca5aa"), "API_KEY", "https://api.example.com", "Contact Name", 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shipper@example.com", false, "1234567890", "Example Shipper", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d9a3861e-6ddf-4eab-b48c-c8fbe86495ad"), new Guid("66f0fc31-5251-4df3-a2e0-83a8fa5375f2") },
                    { new Guid("435711fc-9d8d-4df6-ac57-6b65317aa7e1"), new Guid("cd95e03c-da5a-4a4d-965c-a630055b8b3e") },
                    { new Guid("519ab070-ad4a-49e6-918c-fe501149cd45"), new Guid("f593a9b2-2cac-4844-853c-c4c689b4cbbd") }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "DistrictId", "CityId", "CountryId", "DistrictName" },
                values: new object[,]
                {
                    { 1, 1, 90, "Aladağ" },
                    { 2, 1, 90, "Ceyhan" },
                    { 3, 1, 90, "Çukurova" },
                    { 4, 1, 90, "Feke" },
                    { 5, 1, 90, "İmamoğlu" },
                    { 6, 1, 90, "Karaisalı" },
                    { 7, 1, 90, "Karataş" },
                    { 8, 1, 90, "Kozan" },
                    { 9, 1, 90, "Pozantı" },
                    { 10, 1, 90, "Saimbeyli" },
                    { 11, 1, 90, "Sarıçam" },
                    { 12, 1, 90, "Seyhan" },
                    { 13, 1, 90, "Tufanbeyli" },
                    { 14, 1, 90, "Yumurtalık" },
                    { 15, 1, 90, "Yüreğir" },
                    { 16, 2, 90, "Besni" },
                    { 17, 2, 90, "Çelikhan" },
                    { 18, 2, 90, "Gerger" },
                    { 19, 2, 90, "Gölbaşı" },
                    { 20, 2, 90, "Kahta" },
                    { 21, 2, 90, "Merkez" },
                    { 22, 2, 90, "Samsat" },
                    { 23, 2, 90, "Sincik" },
                    { 24, 2, 90, "Tut" },
                    { 25, 3, 90, "Başmakçı" },
                    { 26, 3, 90, "Bayat" },
                    { 27, 3, 90, "Bolvadin" },
                    { 28, 3, 90, "Çay" },
                    { 29, 3, 90, "Çobanlar" },
                    { 30, 3, 90, "Dazkırı" },
                    { 31, 3, 90, "Dinar" },
                    { 32, 3, 90, "Emirdağ" },
                    { 33, 3, 90, "Evciler" },
                    { 34, 3, 90, "Hocalar" },
                    { 35, 3, 90, "İhsaniye" },
                    { 36, 3, 90, "İscehisar" },
                    { 37, 3, 90, "Kızılören" },
                    { 38, 3, 90, "Merkez" },
                    { 39, 3, 90, "Sandıklı" },
                    { 40, 3, 90, "Sinanpaşa" },
                    { 41, 3, 90, "Sultandağı" },
                    { 42, 3, 90, "Şuhut" },
                    { 43, 4, 90, "Diyadin" },
                    { 44, 4, 90, "Doğubayazıt" },
                    { 45, 4, 90, "Eleşkirt" },
                    { 46, 4, 90, "Hamur" },
                    { 47, 4, 90, "Merkez" },
                    { 48, 4, 90, "Patnos" },
                    { 49, 4, 90, "Taşlıçay" },
                    { 50, 4, 90, "Tutak" },
                    { 51, 5, 90, "Ağaçören" },
                    { 52, 5, 90, "Eskil" },
                    { 53, 5, 90, "Gülağaç" },
                    { 54, 5, 90, "Güzelyurt" },
                    { 55, 5, 90, "Merkez" },
                    { 56, 5, 90, "Ortaköy" },
                    { 57, 5, 90, "Sarıyahşi" },
                    { 58, 6, 90, "Göynücek" },
                    { 59, 6, 90, "Gümüşhacıköy" },
                    { 60, 6, 90, "Hamamözü" },
                    { 61, 6, 90, "Merkez" },
                    { 62, 6, 90, "Merzifon" },
                    { 63, 6, 90, "Suluova" },
                    { 64, 6, 90, "Taşova" },
                    { 65, 7, 90, "Akyurt" },
                    { 66, 7, 90, "Altındağ" },
                    { 67, 7, 90, "Ayaş" },
                    { 68, 7, 90, "Bala" },
                    { 69, 7, 90, "Beypazarı" },
                    { 70, 7, 90, "Çamlıdere" },
                    { 71, 7, 90, "Çankaya" },
                    { 72, 7, 90, "Çubuk" },
                    { 73, 7, 90, "Elmadağ" },
                    { 74, 7, 90, "Etimesgut" },
                    { 75, 7, 90, "Evren" },
                    { 76, 7, 90, "Gölbaşı" },
                    { 77, 7, 90, "Güdül" },
                    { 78, 7, 90, "Haymana" },
                    { 79, 7, 90, "Kalecik" },
                    { 80, 7, 90, "Kazan" },
                    { 81, 7, 90, "Keçiören" },
                    { 82, 7, 90, "Kızılcahamam" },
                    { 83, 7, 90, "Mamak" },
                    { 84, 7, 90, "Nallıhan" },
                    { 85, 7, 90, "Polatlı" },
                    { 86, 7, 90, "Pursaklar" },
                    { 87, 7, 90, "Sincan" },
                    { 88, 7, 90, "Şereflikoçhisar" },
                    { 89, 7, 90, "Yenimahalle" },
                    { 90, 8, 90, "Akseki" },
                    { 91, 8, 90, "Aksu" },
                    { 92, 8, 90, "Alanya" },
                    { 93, 8, 90, "Demre" },
                    { 94, 8, 90, "Döşemealtı" },
                    { 95, 8, 90, "Elmalı" },
                    { 96, 8, 90, "Finike" },
                    { 97, 8, 90, "Gazipaşa" },
                    { 98, 8, 90, "Gündoğmuş" },
                    { 99, 8, 90, "İbradı" },
                    { 100, 8, 90, "Kaş" },
                    { 101, 8, 90, "Kemer" },
                    { 102, 8, 90, "Kepez" },
                    { 103, 8, 90, "Konyaaltı" },
                    { 104, 8, 90, "Korkuteli" },
                    { 105, 8, 90, "Kumluca" },
                    { 106, 8, 90, "Manavgat" },
                    { 107, 8, 90, "Muratpaşa" },
                    { 108, 8, 90, "Serik" },
                    { 109, 9, 90, "Çıldır" },
                    { 110, 9, 90, "Damal" },
                    { 111, 9, 90, "Göle" },
                    { 112, 9, 90, "Hanak" },
                    { 113, 9, 90, "Merkez" },
                    { 114, 9, 90, "Posof" },
                    { 115, 10, 90, "Ardanuç" },
                    { 116, 10, 90, "Arhavi" },
                    { 117, 10, 90, "Borçka" },
                    { 118, 10, 90, "Hopa" },
                    { 119, 10, 90, "Merkez" },
                    { 120, 10, 90, "Murgul" },
                    { 121, 10, 90, "Şavşat" },
                    { 122, 10, 90, "Yusufeli" },
                    { 123, 11, 90, "Bozdoğan" },
                    { 124, 11, 90, "Buharkent" },
                    { 125, 11, 90, "Çine" },
                    { 126, 11, 90, "Didim" },
                    { 127, 11, 90, "Efeler" },
                    { 128, 11, 90, "Germencik" },
                    { 129, 11, 90, "İncirliova" },
                    { 130, 11, 90, "Karacasu" },
                    { 131, 11, 90, "Karpuzlu" },
                    { 132, 11, 90, "Koçarlı" },
                    { 133, 11, 90, "Köşk" },
                    { 134, 11, 90, "Kuşadası" },
                    { 135, 11, 90, "Kuyucak" },
                    { 136, 11, 90, "Nazilli" },
                    { 137, 11, 90, "Söke" },
                    { 138, 11, 90, "Sultanhisar" },
                    { 139, 11, 90, "Yenipazar" },
                    { 140, 12, 90, "Altıeylül" },
                    { 141, 12, 90, "Ayvalık" },
                    { 142, 12, 90, "Balya" },
                    { 143, 12, 90, "Bandırma" },
                    { 144, 12, 90, "Bigadiç" },
                    { 145, 12, 90, "Burhaniye" },
                    { 146, 12, 90, "Dursunbey" },
                    { 147, 12, 90, "Edremit" },
                    { 148, 12, 90, "Erdek" },
                    { 149, 12, 90, "Gömeç" },
                    { 150, 12, 90, "Gönen" },
                    { 151, 12, 90, "Havran" },
                    { 152, 12, 90, "İvrindi" },
                    { 153, 12, 90, "Karesi" },
                    { 154, 12, 90, "Kepsut" },
                    { 155, 12, 90, "Manyas" },
                    { 156, 12, 90, "Marmara" },
                    { 157, 12, 90, "Savaştepe" },
                    { 158, 12, 90, "Sındırgı" },
                    { 159, 12, 90, "Susurluk" },
                    { 160, 13, 90, "Amasra" },
                    { 161, 13, 90, "Kurucaşile" },
                    { 162, 13, 90, "Merkez" },
                    { 163, 13, 90, "Ulus" },
                    { 164, 14, 90, "Beşiri" },
                    { 165, 14, 90, "Gercüş" },
                    { 166, 14, 90, "Hasankeyf" },
                    { 167, 14, 90, "Kozluk" },
                    { 168, 14, 90, "Merkez" },
                    { 169, 14, 90, "Sason" },
                    { 170, 15, 90, "Aydıntepe" },
                    { 171, 15, 90, "Demirözü" },
                    { 172, 15, 90, "Merkez" },
                    { 173, 16, 90, "Bozüyük" },
                    { 174, 16, 90, "Gölpazarı" },
                    { 175, 16, 90, "İnhisar" },
                    { 176, 16, 90, "Merkez" },
                    { 177, 16, 90, "Osmaneli" },
                    { 178, 16, 90, "Pazaryeri" },
                    { 179, 16, 90, "Söğüt" },
                    { 180, 16, 90, "Yenipazar" },
                    { 181, 17, 90, "Adaklı" },
                    { 182, 17, 90, "Genç" },
                    { 183, 17, 90, "Karlıova" },
                    { 184, 17, 90, "Kiğı" },
                    { 185, 17, 90, "Merkez" },
                    { 186, 17, 90, "Solhan" },
                    { 187, 17, 90, "Yayladere" },
                    { 188, 17, 90, "Yedisu" },
                    { 189, 18, 90, "Adilcevaz" },
                    { 190, 18, 90, "Ahlat" },
                    { 191, 18, 90, "Güroymak" },
                    { 192, 18, 90, "Hizan" },
                    { 193, 18, 90, "Merkez" },
                    { 194, 18, 90, "Mutki" },
                    { 195, 18, 90, "Tatvan" },
                    { 196, 19, 90, "Dörtdivan" },
                    { 197, 19, 90, "Gerede" },
                    { 198, 19, 90, "Göynük" },
                    { 199, 19, 90, "Kıbrıscık" },
                    { 200, 19, 90, "Mengen" },
                    { 201, 19, 90, "Merkez" },
                    { 202, 19, 90, "Mudurnu" },
                    { 203, 19, 90, "Seben" },
                    { 204, 19, 90, "Yeniçağa" },
                    { 205, 20, 90, "Ağlasun" },
                    { 206, 20, 90, "Altınyayla" },
                    { 207, 20, 90, "Bucak" },
                    { 208, 20, 90, "Çavdır" },
                    { 209, 20, 90, "Çeltikçi" },
                    { 210, 20, 90, "Gölhisar" },
                    { 211, 20, 90, "Karamanlı" },
                    { 212, 20, 90, "Kemer" },
                    { 213, 20, 90, "Merkez" },
                    { 214, 20, 90, "Tefenni" },
                    { 215, 20, 90, "Yeşilova" },
                    { 216, 21, 90, "Büyükorhan" },
                    { 217, 21, 90, "Gemlik" },
                    { 218, 21, 90, "Gürsu" },
                    { 219, 21, 90, "Harmancık" },
                    { 220, 21, 90, "İnegöl" },
                    { 221, 21, 90, "İznik" },
                    { 222, 21, 90, "Karacabey" },
                    { 223, 21, 90, "Keles" },
                    { 224, 21, 90, "Kestel" },
                    { 225, 21, 90, "Mudanya" },
                    { 226, 21, 90, "Mustafakemalpaşa" },
                    { 227, 21, 90, "Nilüfer" },
                    { 228, 21, 90, "Orhaneli" },
                    { 229, 21, 90, "Orhangazi" },
                    { 230, 21, 90, "Osmangazi" },
                    { 231, 21, 90, "Yenişehir" },
                    { 232, 21, 90, "Yıldırım" },
                    { 233, 22, 90, "Ayvacık" },
                    { 234, 22, 90, "Bayramiç" },
                    { 235, 22, 90, "Biga" },
                    { 236, 22, 90, "Bozcaada" },
                    { 237, 22, 90, "Çan" },
                    { 238, 22, 90, "Eceabat" },
                    { 239, 22, 90, "Ezine" },
                    { 240, 22, 90, "Gelibolu" },
                    { 241, 22, 90, "Gökçeada" },
                    { 242, 22, 90, "Lapseki" },
                    { 243, 22, 90, "Merkez" },
                    { 244, 22, 90, "Yenice" },
                    { 245, 23, 90, "Atkaracalar" },
                    { 246, 23, 90, "Bayramören" },
                    { 247, 23, 90, "Çerkeş" },
                    { 248, 23, 90, "Eldivan" },
                    { 249, 23, 90, "Ilgaz" },
                    { 250, 23, 90, "Kızılırmak" },
                    { 251, 23, 90, "Korgun" },
                    { 252, 23, 90, "Kurşunlu" },
                    { 253, 23, 90, "Merkez" },
                    { 254, 23, 90, "Orta" },
                    { 255, 23, 90, "Şabanözü" },
                    { 256, 23, 90, "Yapraklı" },
                    { 257, 24, 90, "Alaca" },
                    { 258, 24, 90, "Bayat" },
                    { 259, 24, 90, "Boğazkale" },
                    { 260, 24, 90, "Dodurga" },
                    { 261, 24, 90, "İskilip" },
                    { 262, 24, 90, "Kargı" },
                    { 263, 24, 90, "Laçin" },
                    { 264, 24, 90, "Mecitözü" },
                    { 265, 24, 90, "Merkez" },
                    { 266, 24, 90, "Oğuzlar" },
                    { 267, 24, 90, "Ortaköy" },
                    { 268, 24, 90, "Osmancık" },
                    { 269, 24, 90, "Sungurlu" },
                    { 270, 24, 90, "Uğurludağ" },
                    { 271, 25, 90, "Acıpayam" },
                    { 272, 25, 90, "Babadağ" },
                    { 273, 25, 90, "Baklan" },
                    { 274, 25, 90, "Bekilli" },
                    { 275, 25, 90, "Beyağaç" },
                    { 276, 25, 90, "Bozkurt" },
                    { 277, 25, 90, "Buldan" },
                    { 278, 25, 90, "Çal" },
                    { 279, 25, 90, "Çameli" },
                    { 280, 25, 90, "Çardak" },
                    { 281, 25, 90, "Çivril" },
                    { 282, 25, 90, "Güney" },
                    { 283, 25, 90, "Honaz" },
                    { 284, 25, 90, "Kale" },
                    { 285, 25, 90, "Merkezefendi" },
                    { 286, 25, 90, "Pamukkale" },
                    { 287, 25, 90, "Sarayköy" },
                    { 288, 25, 90, "Serinhisar" },
                    { 289, 25, 90, "Tavas" },
                    { 290, 26, 90, "Bağlar" },
                    { 291, 26, 90, "Bismil" },
                    { 292, 26, 90, "Çermik" },
                    { 293, 26, 90, "Çınar" },
                    { 294, 26, 90, "Çüngüş" },
                    { 295, 26, 90, "Dicle" },
                    { 296, 26, 90, "Eğil" },
                    { 297, 26, 90, "Ergani" },
                    { 298, 26, 90, "Hani" },
                    { 299, 26, 90, "Hazro" },
                    { 300, 26, 90, "Kayapınar" },
                    { 301, 26, 90, "Kocaköy" },
                    { 302, 26, 90, "Kulp" },
                    { 303, 26, 90, "Lice" },
                    { 304, 26, 90, "Silvan" },
                    { 305, 26, 90, "Sur" },
                    { 306, 26, 90, "Yenişehir" },
                    { 307, 27, 90, "Akçakoca" },
                    { 308, 27, 90, "Cumayeri" },
                    { 309, 27, 90, "Çilimli" },
                    { 310, 27, 90, "Gölyaka" },
                    { 311, 27, 90, "Gümüşova" },
                    { 312, 27, 90, "Kaynaşlı" },
                    { 313, 27, 90, "Merkez" },
                    { 314, 27, 90, "Yığılca" },
                    { 315, 28, 90, "Enez" },
                    { 316, 28, 90, "Havsa" },
                    { 317, 28, 90, "İpsala" },
                    { 318, 28, 90, "Keşan" },
                    { 319, 28, 90, "Lalapaşa" },
                    { 320, 28, 90, "Meriç" },
                    { 321, 28, 90, "Merkez" },
                    { 322, 28, 90, "Süloğlu" },
                    { 323, 28, 90, "Uzunköprü" },
                    { 324, 29, 90, "Ağın" },
                    { 325, 29, 90, "Alacakaya" },
                    { 326, 29, 90, "Arıcak" },
                    { 327, 29, 90, "Baskil" },
                    { 328, 29, 90, "Karakoçan" },
                    { 329, 29, 90, "Keban" },
                    { 330, 29, 90, "Kovancılar" },
                    { 331, 29, 90, "Maden" },
                    { 332, 29, 90, "Merkez" },
                    { 333, 29, 90, "Palu" },
                    { 334, 29, 90, "Sivrice" },
                    { 335, 30, 90, "Çayırlı" },
                    { 336, 30, 90, "İliç" },
                    { 337, 30, 90, "Kemah" },
                    { 338, 30, 90, "Kemaliye" },
                    { 339, 30, 90, "Merkez" },
                    { 340, 30, 90, "Otlukbeli" },
                    { 341, 30, 90, "Refahiye" },
                    { 342, 30, 90, "Tercan" },
                    { 343, 30, 90, "Üzümlü" },
                    { 344, 31, 90, "Aşkale" },
                    { 345, 31, 90, "Aziziye" },
                    { 346, 31, 90, "Çat" },
                    { 347, 31, 90, "Hınıs" },
                    { 348, 31, 90, "Horasan" },
                    { 349, 31, 90, "İspir" },
                    { 350, 31, 90, "Karaçoban" },
                    { 351, 31, 90, "Karayazı" },
                    { 352, 31, 90, "Köprüköy" },
                    { 353, 31, 90, "Narman" },
                    { 354, 31, 90, "Oltu" },
                    { 355, 31, 90, "Olur" },
                    { 356, 31, 90, "Palandöken" },
                    { 357, 31, 90, "Pasinler" },
                    { 358, 31, 90, "Pazaryolu" },
                    { 359, 31, 90, "Şenkaya" },
                    { 360, 31, 90, "Tekman" },
                    { 361, 31, 90, "Tortum" },
                    { 362, 31, 90, "Uzundere" },
                    { 363, 31, 90, "Yakutiye" },
                    { 364, 32, 90, "Alpu" },
                    { 365, 32, 90, "Beylikova" },
                    { 366, 32, 90, "Çifteler" },
                    { 367, 32, 90, "Günyüzü" },
                    { 368, 32, 90, "Han" },
                    { 369, 32, 90, "İnönü" },
                    { 370, 32, 90, "Mahmudiye" },
                    { 371, 32, 90, "Mihalgazi" },
                    { 372, 32, 90, "Mihalıççık" },
                    { 373, 32, 90, "Odunpazarı" },
                    { 374, 32, 90, "Sarıcakaya" },
                    { 375, 32, 90, "Seyitgazi" },
                    { 376, 32, 90, "Sivrihisar" },
                    { 377, 32, 90, "Tepebaşı" },
                    { 378, 33, 90, "Araban" },
                    { 379, 33, 90, "İslahiye" },
                    { 380, 33, 90, "Karkamış" },
                    { 381, 33, 90, "Nizip" },
                    { 382, 33, 90, "Nurdağı" },
                    { 383, 33, 90, "Oğuzeli" },
                    { 384, 33, 90, "Şahinbey" },
                    { 385, 33, 90, "Şehitkamil" },
                    { 386, 33, 90, "Yavuzeli" },
                    { 387, 34, 90, "Alucra" },
                    { 388, 34, 90, "Bulancak" },
                    { 389, 34, 90, "Çamoluk" },
                    { 390, 34, 90, "Çanakçı" },
                    { 391, 34, 90, "Dereli" },
                    { 392, 34, 90, "Doğankent" },
                    { 393, 34, 90, "Espiye" },
                    { 394, 34, 90, "Eynesil" },
                    { 395, 34, 90, "Görele" },
                    { 396, 34, 90, "Güce" },
                    { 397, 34, 90, "Keşap" },
                    { 398, 34, 90, "Merkez" },
                    { 399, 34, 90, "Piraziz" },
                    { 400, 34, 90, "Şebinkarahisar" },
                    { 401, 34, 90, "Tirebolu" },
                    { 402, 34, 90, "Yağlıdere" },
                    { 403, 35, 90, "Kelkit" },
                    { 404, 35, 90, "Köse" },
                    { 405, 35, 90, "Kürtün" },
                    { 406, 35, 90, "Merkez" },
                    { 407, 35, 90, "Şiran" },
                    { 408, 35, 90, "Torul" },
                    { 409, 36, 90, "Çukurca" },
                    { 410, 36, 90, "Merkez" },
                    { 411, 36, 90, "Şemdinli" },
                    { 412, 36, 90, "Yüksekova" },
                    { 413, 37, 90, "Altınözü" },
                    { 414, 37, 90, "Antakya" },
                    { 415, 37, 90, "Arsuz" },
                    { 416, 37, 90, "Belen" },
                    { 417, 37, 90, "Defne" },
                    { 418, 37, 90, "Dörtyol" },
                    { 419, 37, 90, "Erzin" },
                    { 420, 37, 90, "Hassa" },
                    { 421, 37, 90, "İskenderun" },
                    { 422, 37, 90, "Kırıkhan" },
                    { 423, 37, 90, "Kumlu" },
                    { 424, 37, 90, "Payas" },
                    { 425, 37, 90, "Reyhanlı" },
                    { 426, 37, 90, "Samandağ" },
                    { 427, 37, 90, "Yayladağı" },
                    { 428, 38, 90, "Aralık" },
                    { 429, 38, 90, "Karakoyunlu" },
                    { 430, 38, 90, "Merkez" },
                    { 431, 38, 90, "Tuzluca" },
                    { 432, 39, 90, "Aksu" },
                    { 433, 39, 90, "Atabey" },
                    { 434, 39, 90, "Eğirdir" },
                    { 435, 39, 90, "Gelendost" },
                    { 436, 39, 90, "Gönen" },
                    { 437, 39, 90, "Keçiborlu" },
                    { 438, 39, 90, "Merkez" },
                    { 439, 39, 90, "Senirkent" },
                    { 440, 39, 90, "Sütçüler" },
                    { 441, 39, 90, "Şarkikaraağaç" },
                    { 442, 39, 90, "Uluborlu" },
                    { 443, 39, 90, "Yalvaç" },
                    { 444, 39, 90, "Yenişarbademli" },
                    { 445, 40, 90, "Adalar" },
                    { 446, 40, 90, "Arnavutköy" },
                    { 447, 40, 90, "Ataşehir" },
                    { 448, 40, 90, "Avcılar" },
                    { 449, 40, 90, "Bağcılar" },
                    { 450, 40, 90, "Bahçelievler" },
                    { 451, 40, 90, "Bakırköy" },
                    { 452, 40, 90, "Başakşehir" },
                    { 453, 40, 90, "Bayrampaşa" },
                    { 454, 40, 90, "Beşiktaş" },
                    { 455, 40, 90, "Beykoz" },
                    { 456, 40, 90, "Beylikdüzü" },
                    { 457, 40, 90, "Beyoğlu" },
                    { 458, 40, 90, "Büyükçekmece" },
                    { 459, 40, 90, "Çatalca" },
                    { 460, 40, 90, "Çekmeköy" },
                    { 461, 40, 90, "Esenler" },
                    { 462, 40, 90, "Esenyurt" },
                    { 463, 40, 90, "Eyüp" },
                    { 464, 40, 90, "Fatih" },
                    { 465, 40, 90, "Gaziosmanpaşa" },
                    { 466, 40, 90, "Güngören" },
                    { 467, 40, 90, "Kadıköy" },
                    { 468, 40, 90, "Kağıthane" },
                    { 469, 40, 90, "Kartal" },
                    { 470, 40, 90, "Küçükçekmece" },
                    { 471, 40, 90, "Maltepe" },
                    { 472, 40, 90, "Pendik" },
                    { 473, 40, 90, "Sancaktepe" },
                    { 474, 40, 90, "Sarıyer" },
                    { 475, 40, 90, "Silivri" },
                    { 476, 40, 90, "Sultanbeyli" },
                    { 477, 40, 90, "Sultangazi" },
                    { 478, 40, 90, "Şile" },
                    { 479, 40, 90, "Şişli" },
                    { 480, 40, 90, "Tuzla" },
                    { 481, 40, 90, "Ümraniye" },
                    { 482, 40, 90, "Üsküdar" },
                    { 483, 40, 90, "Zeytinburnu" },
                    { 484, 41, 90, "Aliağa" },
                    { 485, 41, 90, "Balçova" },
                    { 486, 41, 90, "Bayındır" },
                    { 487, 41, 90, "Bayraklı" },
                    { 488, 41, 90, "Bergama" },
                    { 489, 41, 90, "Beydağ" },
                    { 490, 41, 90, "Bornova" },
                    { 491, 41, 90, "Buca" },
                    { 492, 41, 90, "Çeşme" },
                    { 493, 41, 90, "Çiğli" },
                    { 494, 41, 90, "Dikili" },
                    { 495, 41, 90, "Foça" },
                    { 496, 41, 90, "Gaziemir" },
                    { 497, 41, 90, "Güzelbahçe" },
                    { 498, 41, 90, "Karabağlar" },
                    { 499, 41, 90, "Karaburun" },
                    { 500, 41, 90, "Karşıyaka" },
                    { 501, 41, 90, "Kemalpaşa" },
                    { 502, 41, 90, "Kınık" },
                    { 503, 41, 90, "Kiraz" },
                    { 504, 41, 90, "Konak" },
                    { 505, 41, 90, "Menderes" },
                    { 506, 41, 90, "Menemen" },
                    { 507, 41, 90, "Narlıdere" },
                    { 508, 41, 90, "Ödemiş" },
                    { 509, 41, 90, "Seferihisar" },
                    { 510, 41, 90, "Selçuk" },
                    { 511, 41, 90, "Tire" },
                    { 512, 41, 90, "Torbalı" },
                    { 513, 41, 90, "Urla" },
                    { 514, 42, 90, "Afşin" },
                    { 515, 42, 90, "Andırın" },
                    { 516, 42, 90, "Çağlayancerit" },
                    { 517, 42, 90, "Dulkadiroğlu" },
                    { 518, 42, 90, "Ekinözü" },
                    { 519, 42, 90, "Elbistan" },
                    { 520, 42, 90, "Göksun" },
                    { 521, 42, 90, "Nurhak" },
                    { 522, 42, 90, "Onikişubat" },
                    { 523, 42, 90, "Pazarcık" },
                    { 524, 42, 90, "Türkoğlu" },
                    { 525, 43, 90, "Eflani" },
                    { 526, 43, 90, "Eskipazar" },
                    { 527, 43, 90, "Merkez" },
                    { 528, 43, 90, "Ovacık" },
                    { 529, 43, 90, "Safranbolu" },
                    { 530, 43, 90, "Yenice" },
                    { 531, 44, 90, "Ayrancı" },
                    { 532, 44, 90, "Başyayla" },
                    { 533, 44, 90, "Ermenek" },
                    { 534, 44, 90, "Kazımkarabekir" },
                    { 535, 44, 90, "Merkez" },
                    { 536, 44, 90, "Sarıveliler" },
                    { 537, 45, 90, "Akyaka" },
                    { 538, 45, 90, "Arpaçay" },
                    { 539, 45, 90, "Digor" },
                    { 540, 45, 90, "Kağızman" },
                    { 541, 45, 90, "Merkez" },
                    { 542, 45, 90, "Sarıkamış" },
                    { 543, 45, 90, "Selim" },
                    { 544, 45, 90, "Susuz" },
                    { 545, 46, 90, "Abana" },
                    { 546, 46, 90, "Ağlı" },
                    { 547, 46, 90, "Araç" },
                    { 548, 46, 90, "Azdavay" },
                    { 549, 46, 90, "Bozkurt" },
                    { 550, 46, 90, "Cide" },
                    { 551, 46, 90, "Çatalzeytin" },
                    { 552, 46, 90, "Daday" },
                    { 553, 46, 90, "Devrekani" },
                    { 554, 46, 90, "Doğanyurt" },
                    { 555, 46, 90, "Hanönü" },
                    { 556, 46, 90, "İhsangazi" },
                    { 557, 46, 90, "İnebolu" },
                    { 558, 46, 90, "Küre" },
                    { 559, 46, 90, "Merkez" },
                    { 560, 46, 90, "Pınarbaşı" },
                    { 561, 46, 90, "Seydiler" },
                    { 562, 46, 90, "Şenpazar" },
                    { 563, 46, 90, "Taşköprü" },
                    { 564, 46, 90, "Tosya" },
                    { 565, 47, 90, "Akkışla" },
                    { 566, 47, 90, "Bünyan" },
                    { 567, 47, 90, "Develi" },
                    { 568, 47, 90, "Felahiye" },
                    { 569, 47, 90, "Hacılar" },
                    { 570, 47, 90, "İncesu" },
                    { 571, 47, 90, "Kocasinan" },
                    { 572, 47, 90, "Melikgazi" },
                    { 573, 47, 90, "Özvatan" },
                    { 574, 47, 90, "Pınarbaşı" },
                    { 575, 47, 90, "Sarıoğlan" },
                    { 576, 47, 90, "Sarız" },
                    { 577, 47, 90, "Talas" },
                    { 578, 47, 90, "Tomarza" },
                    { 579, 47, 90, "Yahyalı" },
                    { 580, 47, 90, "Yeşilhisar" },
                    { 581, 48, 90, "Bahşili" },
                    { 582, 48, 90, "Balışeyh" },
                    { 583, 48, 90, "Çelebi" },
                    { 584, 48, 90, "Delice" },
                    { 585, 48, 90, "Karakeçili" },
                    { 586, 48, 90, "Keskin" },
                    { 587, 48, 90, "Merkez" },
                    { 588, 48, 90, "Sulakyurt" },
                    { 589, 48, 90, "Yahşihan" },
                    { 590, 49, 90, "Babaeski" },
                    { 591, 49, 90, "Demirköy" },
                    { 592, 49, 90, "Kofçaz" },
                    { 593, 49, 90, "Lüleburgaz" },
                    { 594, 49, 90, "Merkez" },
                    { 595, 49, 90, "Pehlivanköy" },
                    { 596, 49, 90, "Pınarhisar" },
                    { 597, 49, 90, "Vize" },
                    { 598, 50, 90, "Akçakent" },
                    { 599, 50, 90, "Akpınar" },
                    { 600, 50, 90, "Boztepe" },
                    { 601, 50, 90, "Çiçekdağı" },
                    { 602, 50, 90, "Kaman" },
                    { 603, 50, 90, "Merkez" },
                    { 604, 50, 90, "Mucur" },
                    { 605, 51, 90, "Elbeyli" },
                    { 606, 51, 90, "Merkez" },
                    { 607, 51, 90, "Musabeyli" },
                    { 608, 51, 90, "Polateli" },
                    { 609, 52, 90, "Başiskele" },
                    { 610, 52, 90, "Çayırova" },
                    { 611, 52, 90, "Darıca" },
                    { 612, 52, 90, "Derince" },
                    { 613, 52, 90, "Dilovası" },
                    { 614, 52, 90, "Gebze" },
                    { 615, 52, 90, "Gölcük" },
                    { 616, 52, 90, "İzmit" },
                    { 617, 52, 90, "Kandıra" },
                    { 618, 52, 90, "Karamürsel" },
                    { 619, 52, 90, "Kartepe" },
                    { 620, 52, 90, "Körfez" },
                    { 621, 53, 90, "Ahırlı" },
                    { 622, 53, 90, "Akören" },
                    { 623, 53, 90, "Akşehir" },
                    { 624, 53, 90, "Altınekin" },
                    { 625, 53, 90, "Beyşehir" },
                    { 626, 53, 90, "Bozkır" },
                    { 627, 53, 90, "Cihanbeyli" },
                    { 628, 53, 90, "Çeltik" },
                    { 629, 53, 90, "Çumra" },
                    { 630, 53, 90, "Derbent" },
                    { 631, 53, 90, "Derebucak" },
                    { 632, 53, 90, "Doğanhisar" },
                    { 633, 53, 90, "Emirgazi" },
                    { 634, 53, 90, "Ereğli" },
                    { 635, 53, 90, "Güneysınır" },
                    { 636, 53, 90, "Hadim" },
                    { 637, 53, 90, "Halkapınar" },
                    { 638, 53, 90, "Hüyük" },
                    { 639, 53, 90, "Ilgın" },
                    { 640, 53, 90, "Kadınhanı" },
                    { 641, 53, 90, "Karapınar" },
                    { 642, 53, 90, "Karatay" },
                    { 643, 53, 90, "Kulu" },
                    { 644, 53, 90, "Meram" },
                    { 645, 53, 90, "Sarayönü" },
                    { 646, 53, 90, "Selçuklu" },
                    { 647, 53, 90, "Seydişehir" },
                    { 648, 53, 90, "Taşkent" },
                    { 649, 53, 90, "Tuzlukçu" },
                    { 650, 53, 90, "Yalıhüyük" },
                    { 651, 53, 90, "Yunak" },
                    { 652, 54, 90, "Altıntaş" },
                    { 653, 54, 90, "Aslanapa" },
                    { 654, 54, 90, "Çavdarhisar" },
                    { 655, 54, 90, "Domaniç" },
                    { 656, 54, 90, "Dumlupınar" },
                    { 657, 54, 90, "Emet" },
                    { 658, 54, 90, "Gediz" },
                    { 659, 54, 90, "Hisarcık" },
                    { 660, 54, 90, "Merkez" },
                    { 661, 54, 90, "Pazarlar" },
                    { 662, 54, 90, "Simav" },
                    { 663, 54, 90, "Şaphane" },
                    { 664, 54, 90, "Tavşanlı" },
                    { 665, 55, 90, "Akçadağ" },
                    { 666, 55, 90, "Arapgir" },
                    { 667, 55, 90, "Arguvan" },
                    { 668, 55, 90, "Battalgazi" },
                    { 669, 55, 90, "Darende" },
                    { 670, 55, 90, "Doğanşehir" },
                    { 671, 55, 90, "Doğanyol" },
                    { 672, 55, 90, "Hekimhan" },
                    { 673, 55, 90, "Kale" },
                    { 674, 55, 90, "Kuluncak" },
                    { 675, 55, 90, "Pütürge" },
                    { 676, 55, 90, "Yazıhan" },
                    { 677, 55, 90, "Yeşilyurt" },
                    { 678, 56, 90, "Ahmetli" },
                    { 679, 56, 90, "Akhisar" },
                    { 680, 56, 90, "Alaşehir" },
                    { 681, 56, 90, "Demirci" },
                    { 682, 56, 90, "Gölmarmara" },
                    { 683, 56, 90, "Gördes" },
                    { 684, 56, 90, "Kırkağaç" },
                    { 685, 56, 90, "Köprübaşı" },
                    { 686, 56, 90, "Kula" },
                    { 687, 56, 90, "Salihli" },
                    { 688, 56, 90, "Sarıgöl" },
                    { 689, 56, 90, "Saruhanlı" },
                    { 690, 56, 90, "Selendi" },
                    { 691, 56, 90, "Soma" },
                    { 692, 56, 90, "Şehzadeler" },
                    { 693, 56, 90, "Turgutlu" },
                    { 694, 56, 90, "Yunusemre" },
                    { 695, 57, 90, "Artuklu" },
                    { 696, 57, 90, "Dargeçit" },
                    { 697, 57, 90, "Derik" },
                    { 698, 57, 90, "Kızıltepe" },
                    { 699, 57, 90, "Mazıdağı" },
                    { 700, 57, 90, "Midyat" },
                    { 701, 57, 90, "Nusaybin" },
                    { 702, 57, 90, "Ömerli" },
                    { 703, 57, 90, "Savur" },
                    { 704, 57, 90, "Yeşilli" },
                    { 705, 58, 90, "Akdeniz" },
                    { 706, 58, 90, "Anamur" },
                    { 707, 58, 90, "Aydıncık" },
                    { 708, 58, 90, "Bozyazı" },
                    { 709, 58, 90, "Çamlıyayla" },
                    { 710, 58, 90, "Erdemli" },
                    { 711, 58, 90, "Gülnar" },
                    { 712, 58, 90, "Mezitli" },
                    { 713, 58, 90, "Mut" },
                    { 714, 58, 90, "Silifke" },
                    { 715, 58, 90, "Tarsus" },
                    { 716, 58, 90, "Toroslar" },
                    { 717, 58, 90, "Yenişehir" },
                    { 718, 59, 90, "Bodrum" },
                    { 719, 59, 90, "Dalaman" },
                    { 720, 59, 90, "Datça" },
                    { 721, 59, 90, "Fethiye" },
                    { 722, 59, 90, "Kavaklıdere" },
                    { 723, 59, 90, "Köyceğiz" },
                    { 724, 59, 90, "Marmaris" },
                    { 725, 59, 90, "Menteşe" },
                    { 726, 59, 90, "Milas" },
                    { 727, 59, 90, "Ortaca" },
                    { 728, 59, 90, "Seydikemer" },
                    { 729, 59, 90, "Ula" },
                    { 730, 59, 90, "Yatağan" },
                    { 731, 60, 90, "Bulanık" },
                    { 732, 60, 90, "Hasköy" },
                    { 733, 60, 90, "Korkut" },
                    { 734, 60, 90, "Malazgirt" },
                    { 735, 60, 90, "Merkez" },
                    { 736, 60, 90, "Varto" },
                    { 737, 61, 90, "Acıgöl" },
                    { 738, 61, 90, "Avanos" },
                    { 739, 61, 90, "Derinkuyu" },
                    { 740, 61, 90, "Gülşehir" },
                    { 741, 61, 90, "Hacıbektaş" },
                    { 742, 61, 90, "Kozaklı" },
                    { 743, 61, 90, "Merkez" },
                    { 744, 61, 90, "Ürgüp" },
                    { 745, 62, 90, "Altunhisar" },
                    { 746, 62, 90, "Bor" },
                    { 747, 62, 90, "Çamardı" },
                    { 748, 62, 90, "Çiftlik" },
                    { 749, 62, 90, "Merkez" },
                    { 750, 62, 90, "Ulukışla" },
                    { 751, 63, 90, "Akkuş" },
                    { 752, 63, 90, "Altınordu" },
                    { 753, 63, 90, "Aybastı" },
                    { 754, 63, 90, "Çamaş" },
                    { 755, 63, 90, "Çatalpınar" },
                    { 756, 63, 90, "Çaybaşı" },
                    { 757, 63, 90, "Fatsa" },
                    { 758, 63, 90, "Gölköy" },
                    { 759, 63, 90, "Gülyalı" },
                    { 760, 63, 90, "Gürgentepe" },
                    { 761, 63, 90, "İkizce" },
                    { 762, 63, 90, "Kabadüz" },
                    { 763, 63, 90, "Kabataş" },
                    { 764, 63, 90, "Korgan" },
                    { 765, 63, 90, "Kumru" },
                    { 766, 63, 90, "Mesudiye" },
                    { 767, 63, 90, "Perşembe" },
                    { 768, 63, 90, "Ulubey" },
                    { 769, 63, 90, "Ünye" },
                    { 770, 64, 90, "Bahçe" },
                    { 771, 64, 90, "Düziçi" },
                    { 772, 64, 90, "Hasanbeyli" },
                    { 773, 64, 90, "Kadirli" },
                    { 774, 64, 90, "Merkez" },
                    { 775, 64, 90, "Sumbas" },
                    { 776, 64, 90, "Toprakkale" },
                    { 777, 65, 90, "Ardeşen" },
                    { 778, 65, 90, "Çamlıhemşin" },
                    { 779, 65, 90, "Çayeli" },
                    { 780, 65, 90, "Derepazarı" },
                    { 781, 65, 90, "Fındıklı" },
                    { 782, 65, 90, "Güneysu" },
                    { 783, 65, 90, "Hemşin" },
                    { 784, 65, 90, "İkizdere" },
                    { 785, 65, 90, "İyidere" },
                    { 786, 65, 90, "Kalkandere" },
                    { 787, 65, 90, "Merkez" },
                    { 788, 65, 90, "Pazar" },
                    { 789, 66, 90, "Adapazarı" },
                    { 790, 66, 90, "Akyazı" },
                    { 791, 66, 90, "Arifiye" },
                    { 792, 66, 90, "Erenler" },
                    { 793, 66, 90, "Ferizli" },
                    { 794, 66, 90, "Geyve" },
                    { 795, 66, 90, "Hendek" },
                    { 796, 66, 90, "Karapürçek" },
                    { 797, 66, 90, "Karasu" },
                    { 798, 66, 90, "Kaynarca" },
                    { 799, 66, 90, "Kocaali" },
                    { 800, 66, 90, "Pamukova" },
                    { 801, 66, 90, "Sapanca" },
                    { 802, 66, 90, "Serdivan" },
                    { 803, 66, 90, "Söğütlü" },
                    { 804, 66, 90, "Taraklı" },
                    { 805, 67, 90, "45796" },
                    { 806, 67, 90, "Alaçam" },
                    { 807, 67, 90, "Asarcık" },
                    { 808, 67, 90, "Atakum" },
                    { 809, 67, 90, "Ayvacık" },
                    { 810, 67, 90, "Bafra" },
                    { 811, 67, 90, "Canik" },
                    { 812, 67, 90, "Çarşamba" },
                    { 813, 67, 90, "Havza" },
                    { 814, 67, 90, "İlkadım" },
                    { 815, 67, 90, "Kavak" },
                    { 816, 67, 90, "Ladik" },
                    { 817, 67, 90, "Salıpazarı" },
                    { 818, 67, 90, "Tekkeköy" },
                    { 819, 67, 90, "Terme" },
                    { 820, 67, 90, "Vezirköprü" },
                    { 821, 67, 90, "Yakakent" },
                    { 822, 68, 90, "Baykan" },
                    { 823, 68, 90, "Eruh" },
                    { 824, 68, 90, "Kurtalan" },
                    { 825, 68, 90, "Merkez" },
                    { 826, 68, 90, "Pervari" },
                    { 827, 68, 90, "Şirvan" },
                    { 828, 68, 90, "Tillo" },
                    { 829, 69, 90, "Ayancık" },
                    { 830, 69, 90, "Boyabat" },
                    { 831, 69, 90, "Dikmen" },
                    { 832, 69, 90, "Durağan" },
                    { 833, 69, 90, "Erfelek" },
                    { 834, 69, 90, "Gerze" },
                    { 835, 69, 90, "Merkez" },
                    { 836, 69, 90, "Saraydüzü" },
                    { 837, 69, 90, "Türkeli" },
                    { 838, 70, 90, "Akıncılar" },
                    { 839, 70, 90, "Altınyayla" },
                    { 840, 70, 90, "Divriği" },
                    { 841, 70, 90, "Doğanşar" },
                    { 842, 70, 90, "Gemerek" },
                    { 843, 70, 90, "Gölova" },
                    { 844, 70, 90, "Gürün" },
                    { 845, 70, 90, "Hafik" },
                    { 846, 70, 90, "İmranlı" },
                    { 847, 70, 90, "Kangal" },
                    { 848, 70, 90, "Koyulhisar" },
                    { 849, 70, 90, "Merkez" },
                    { 850, 70, 90, "Suşehri" },
                    { 851, 70, 90, "Şarkışla" },
                    { 852, 70, 90, "Ulaş" },
                    { 853, 70, 90, "Yıldızeli" },
                    { 854, 70, 90, "Zara" },
                    { 855, 71, 90, "Akçakale" },
                    { 856, 71, 90, "Birecik" },
                    { 857, 71, 90, "Bozova" },
                    { 858, 71, 90, "Ceylanpınar" },
                    { 859, 71, 90, "Eyyübiye" },
                    { 860, 71, 90, "Halfeti" },
                    { 861, 71, 90, "Haliliye" },
                    { 862, 71, 90, "Harran" },
                    { 863, 71, 90, "Hilvan" },
                    { 864, 71, 90, "Karaköprü" },
                    { 865, 71, 90, "Siverek" },
                    { 866, 71, 90, "Suruç" },
                    { 867, 71, 90, "Viranşehir" },
                    { 868, 72, 90, "Beytüşşebap" },
                    { 869, 72, 90, "Cizre" },
                    { 870, 72, 90, "Güçlükonak" },
                    { 871, 72, 90, "İdil" },
                    { 872, 72, 90, "Merkez" },
                    { 873, 72, 90, "Silopi" },
                    { 874, 72, 90, "Uludere" },
                    { 875, 73, 90, "Çerkezköy" },
                    { 876, 73, 90, "Çorlu" },
                    { 877, 73, 90, "Ergene" },
                    { 878, 73, 90, "Hayrabolu" },
                    { 879, 73, 90, "Kapaklı" },
                    { 880, 73, 90, "Malkara" },
                    { 881, 73, 90, "Marmaraereğlisi" },
                    { 882, 73, 90, "Muratlı" },
                    { 883, 73, 90, "Saray" },
                    { 884, 73, 90, "Süleymanpaşa" },
                    { 885, 73, 90, "Şarköy" },
                    { 886, 74, 90, "Almus" },
                    { 887, 74, 90, "Artova" },
                    { 888, 74, 90, "Başçiftlik" },
                    { 889, 74, 90, "Erbaa" },
                    { 890, 74, 90, "Merkez" },
                    { 891, 74, 90, "Niksar" },
                    { 892, 74, 90, "Pazar" },
                    { 893, 74, 90, "Reşadiye" },
                    { 894, 74, 90, "Sulusaray" },
                    { 895, 74, 90, "Turhal" },
                    { 896, 74, 90, "Yeşilyurt" },
                    { 897, 74, 90, "Zile" },
                    { 898, 75, 90, "Akçaabat" },
                    { 899, 75, 90, "Araklı" },
                    { 900, 75, 90, "Arsin" },
                    { 901, 75, 90, "Beşikdüzü" },
                    { 902, 75, 90, "Çarşıbaşı" },
                    { 903, 75, 90, "Çaykara" },
                    { 904, 75, 90, "Dernekpazarı" },
                    { 905, 75, 90, "Düzköy" },
                    { 906, 75, 90, "Hayrat" },
                    { 907, 75, 90, "Köprübaşı" },
                    { 908, 75, 90, "Maçka" },
                    { 909, 75, 90, "Of" },
                    { 910, 75, 90, "Ortahisar" },
                    { 911, 75, 90, "Sürmene" },
                    { 912, 75, 90, "Şalpazarı" },
                    { 913, 75, 90, "Tonya" },
                    { 914, 75, 90, "Vakfıkebir" },
                    { 915, 75, 90, "Yomra" },
                    { 916, 76, 90, "Çemişgezek" },
                    { 917, 76, 90, "Hozat" },
                    { 918, 76, 90, "Mazgirt" },
                    { 919, 76, 90, "Merkez" },
                    { 920, 76, 90, "Nazımiye" },
                    { 921, 76, 90, "Ovacık" },
                    { 922, 76, 90, "Pertek" },
                    { 923, 76, 90, "Pülümür" },
                    { 924, 77, 90, "Banaz" },
                    { 925, 77, 90, "Eşme" },
                    { 926, 77, 90, "Karahallı" },
                    { 927, 77, 90, "Merkez" },
                    { 928, 77, 90, "Sivaslı" },
                    { 929, 77, 90, "Ulubey" },
                    { 930, 78, 90, "Bahçesaray" },
                    { 931, 78, 90, "Başkale" },
                    { 932, 78, 90, "Çaldıran" },
                    { 933, 78, 90, "Çatak" },
                    { 934, 78, 90, "Edremit" },
                    { 935, 78, 90, "Erciş" },
                    { 936, 78, 90, "Gevaş" },
                    { 937, 78, 90, "Gürpınar" },
                    { 938, 78, 90, "İpekyolu" },
                    { 939, 78, 90, "Muradiye" },
                    { 940, 78, 90, "Özalp" },
                    { 941, 78, 90, "Saray" },
                    { 942, 78, 90, "Tuşba" },
                    { 943, 79, 90, "Altınova" },
                    { 944, 79, 90, "Armutlu" },
                    { 945, 79, 90, "Çınarcık" },
                    { 946, 79, 90, "Çiftlikköy" },
                    { 947, 79, 90, "Merkez" },
                    { 948, 79, 90, "Termal" },
                    { 949, 80, 90, "Akdağmadeni" },
                    { 950, 80, 90, "Aydıncık" },
                    { 951, 80, 90, "Boğazlıyan" },
                    { 952, 80, 90, "Çandır" },
                    { 953, 80, 90, "Çayıralan" },
                    { 954, 80, 90, "Çekerek" },
                    { 955, 80, 90, "Kadışehri" },
                    { 956, 80, 90, "Merkez" },
                    { 957, 80, 90, "Saraykent" },
                    { 958, 80, 90, "Sarıkaya" },
                    { 959, 80, 90, "Sorgun" },
                    { 960, 80, 90, "Şefaatli" },
                    { 961, 80, 90, "Yenifakılı" },
                    { 962, 80, 90, "Yerköy" },
                    { 963, 81, 90, "Alaplı" },
                    { 964, 81, 90, "Çaycuma" },
                    { 965, 81, 90, "Devrek" },
                    { 966, 81, 90, "Ereğli" },
                    { 967, 81, 90, "Gökçebey" },
                    { 968, 81, 90, "Kilimli" },
                    { 969, 81, 90, "Kozlu" },
                    { 970, 81, 90, "Merkez" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerId", "About", "CityId", "CountryId", "CreatedDate", "DistrictId", "IsActive", "IsApproved", "ShopImagePath", "ShopName", "Tckn", "UpdatedDate", "UserId", "Vkn" },
                values: new object[] { new Guid("c8172635-8b0b-492b-b5f9-2751ddb29867"), "Evimden mağazasının yetkili satıcısıdır.", 34, 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 467, false, true, "path/to/image", "Evimden Mağaza", "12345678901", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f593a9b2-2cac-4844-853c-c4c689b4cbbd"), "1234567890" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ContainGluten", "CreatedDate", "Description", "DiscountRate", "IsActive", "IsApproved", "IsVisiable", "Price", "ProductName", "SellerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("92995580-5c66-42ef-aa9b-92c434c71dd4"), new Guid("94a3443a-34fb-40e3-8aa2-e3e3d21cdacd"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sağlıklı ve lezzetli tam buğday erişte. Pakette 500g.", 0m, false, true, true, 20.0m, "Tam Buğday Erişte", new Guid("c8172635-8b0b-492b-b5f9-2751ddb29867"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("93f2272c-7e3d-475b-b260-c5e13165ab88"), new Guid("2405690d-f3fe-40f6-bc87-59c2406c43f3"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Geleneksel Kayseri mantısı. Pakette 1kg", 0m, false, true, true, 50.0m, "Kayseri Mantısı", new Guid("c8172635-8b0b-492b-b5f9-2751ddb29867"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1bd7d22-26fc-4879-a864-44e85f107232"), new Guid("cd77924b-c42f-47d8-b19b-a2ff6eddc7da"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lezzetli ve çıtır patatesli börek. Posriyonda 6 Adet", 0m, false, true, true, 40.0m, "Patatesli Börek", new Guid("c8172635-8b0b-492b-b5f9-2751ddb29867"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b729f5d3-20ff-4255-baa8-ca643b091cd9"), new Guid("ffaa9d6e-0458-4c8a-9e79-1a576c39c0c4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doğal ve taze çilek reçeli. Kavanozda 400g.", 0m, false, true, true, 25.0m, "Çilek Reçeli ", new Guid("c8172635-8b0b-492b-b5f9-2751ddb29867"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c463f79e-57e6-496f-b8a4-dfc858831899"), new Guid("b50df1d6-9f61-4f2d-818f-6cdd013fcaaa"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ev yapımı doğal domates salçası. Kavanozda 700g.", 0m, false, true, true, 30.0m, "Domates Salçası", new Guid("c8172635-8b0b-492b-b5f9-2751ddb29867"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "CreatedDate", "ImagePath", "IsActive", "ProductId", "SavedFileName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3c51e676-4f39-4e3a-b9fe-856333cad8ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/products/tam_bugday_eriste.jpg", false, new Guid("92995580-5c66-42ef-aa9b-92c434c71dd4"), "tam_bugday_eriste.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("88f1426c-ddd1-4791-a867-52e364ddc89b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/products/domates_salcası.jpg", false, new Guid("c463f79e-57e6-496f-b8a4-dfc858831899"), "domates_salcası.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9cc2f104-5804-4d96-b322-f83c035457a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/products/kayseri_mantisi.jpg", false, new Guid("93f2272c-7e3d-475b-b260-c5e13165ab88"), "kayseri_mantisi.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b087290c-9616-438a-9ee4-fc4cb772cdc7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/products/cilek_receli.jpg", false, new Guid("b729f5d3-20ff-4255-baa8-ca643b091cd9"), "cilek_receli.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6afdab5-f804-4f13-a064-e441491044d9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/products/patatesli_borek.jpg", false, new Guid("b1bd7d22-26fc-4879-a864-44e85f107232"), "patatesli_borek.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PhoneId",
                table: "Addresses",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UserId",
                table: "Coupons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SellerId",
                table: "Orders",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CouponId",
                table: "Payments",
                column: "CouponId",
                unique: true,
                filter: "[CouponId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentInformationId",
                table: "Payments",
                column: "PaymentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductApprovals_ProductId",
                table: "ProductApprovals",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_CartId",
                table: "ProductCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarts_ProductId",
                table: "ProductCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SellerApprovals_SellerId",
                table: "SellerApprovals",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_CityId",
                table: "Sellers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_CountryId",
                table: "Sellers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_DistrictId",
                table: "Sellers",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shippers_CountryId",
                table: "Shippers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductApprovals");

            migrationBuilder.DropTable(
                name: "ProductCarts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SellerApprovals");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "PaymentInformations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
