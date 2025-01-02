using Evimden.BusinessLayer.Interfaces.ProductInterfaces;
using Evimden.BusinessLayer.Interfaces.ProfileInterfaces;
using Evimden.CoreLayer.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Evimden.UI.Web.Controllers
{
    /// <summary>
    /// Satıcı ve Admin rolleri için ürün işlemleri yapılır.
    /// Satıcıya ait SELLERID : ClaimTypes.PostalCode
    /// </summary>
    [Authorize(Roles = "Admin, Satıcı")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductApprovalService _productApprovalService;
        private readonly ISellerService _sellerService;

        public ProductController(IProductService productService, IProductImageService productImageService, IProductApprovalService productApprovalService, ISellerService sellerService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _productApprovalService = productApprovalService;
            _sellerService = sellerService;
        }

        /// <summary>
        /// Satıcıya ait ürünleri ve resimlerini getirir.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            //Admin tüm ürünleri görebilir.
            if (User.IsInRole("Admin"))
            {
                var productWithImages = await _productService.GetAllProductsWithImagesAsync();
                return View(productWithImages);
            }
            //Satıcı sadece kendi ürünlerini görebilir.
            else if (User.IsInRole("Satıcı"))
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                var sellerId = Guid.Parse(userIdClaim.Value);
                var productWithImages = await _productService.GetProductsWithImagesBySellerIdAsync(sellerId);
                return View(productWithImages);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// SADECE ADMIN İÇİN
        /// Satıcı Id'sine göre ürünleri ve resimlerini getirir.
        /// </summary>
        /// <param name="sellerId"></param>
        /// <returns></returns>
        public async Task<IActionResult> SellerProduct(Guid sellerId)
        {
            if (User.IsInRole("Admin"))
            {
                var productWithImages = await _productService.GetProductsWithImagesBySellerIdAsync(sellerId);
                return View(productWithImages);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Ürün ekleme sayfası.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(new ProductWithImagesDto());
        }

        /// <summary>
        /// Ürün ekleme işlemi.
        /// </summary>
        /// <param name="productWithImagesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductWithImagesDto productWithImagesDto)
        {
            try
            {
                Guid sellerId = Guid.Empty;
                //Admin ise satıcı ID'si alınır.
                if (User.IsInRole("Admin"))
                {
                    //Adminin satıcı ID'si yoksa oluşturulur.
                    sellerId = await _sellerService.GetSellerIdByUserIdAsync(Guid.Parse(ClaimTypes.NameIdentifier));
                    if (sellerId == Guid.Empty)
                    {
                        var adminShop = await _sellerService.CreateShopForAdmin(Guid.Parse(ClaimTypes.NameIdentifier));
                        sellerId = adminShop.SellerId;
                    }
                }
                else if (User.IsInRole("Satıcı"))
                {
                    sellerId = Guid.Parse(ClaimTypes.PostalCode);
                }
                productWithImagesDto.Product.SellerId = sellerId;

                //Ürün ekleniyor.
                productWithImagesDto.Product = await _productService.AddAsync(productWithImagesDto.Product);

                //Ürün ekleme talebi oluşturuluyor.
                await _productApprovalService.AddAsync(new ProductApprovalDto()
                {
                    ProductId = productWithImagesDto.Product.ProductId,
                    SellerId = productWithImagesDto.Product.SellerId
                });

                //Ürün görselleri ekleniyor.
                foreach (var image in productWithImagesDto.Images)
                {
                    image.ProductId = productWithImagesDto.Product.ProductId;
                    await _productImageService.AddProductImageAsync(image, productWithImagesDto.Product.SellerId);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ürün güncelleme sayfası.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var myProduct = await _productService.IsMyProduct(id, Guid.Parse(ClaimTypes.PostalCode));
            if ((User.IsInRole("Satıcı") && myProduct) || (User.IsInRole("Admin")))
            {
                var product = await _productService.GetProductWithImagesAsync(id);
                return View(product);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ürün güncelleme işlemi.
        /// </summary>
        /// <param name="productWithImagesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductWithImagesDto productWithImagesDto)
        {
            try
            {
                var myProduct = await _productService.IsMyProduct(productWithImagesDto.Product.ProductId, Guid.Parse(ClaimTypes.PostalCode));
                if ((User.IsInRole("Satıcı") && myProduct) || (User.IsInRole("Admin")))
                {
                    productWithImagesDto.Product.IsApproved = false;
                    productWithImagesDto.Product.IsVisiable = false;
                    //Ürün güncelleniyor.
                    await _productService.UpdateAsync(productWithImagesDto.Product);

                    //Ürün güncelleme talebi oluşturuluyor.
                    await _productApprovalService.AddAsync(new ProductApprovalDto()
                    {
                        ProductId = productWithImagesDto.Product.ProductId,
                        SellerId = productWithImagesDto.Product.SellerId,
                    });

                    //Ürün görselleri kontrol edilerek ekleniyor.
                    foreach (var image in productWithImagesDto.Images)
                    {
                        bool isExist = await _productImageService.IsExist(image.ImagePath);
                        if (!isExist)
                        {
                            image.ProductId = productWithImagesDto.Product.ProductId;
                            await _productImageService.AddProductImageAsync(image, productWithImagesDto.Product.SellerId);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ürün silme işlemi.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                //Satıcı kendi ürününü silebilir veya Admin silebilir.
                var myProduct = await _productService.IsMyProduct(id, Guid.Parse(ClaimTypes.PostalCode));
                if ((User.IsInRole("Satıcı") && myProduct) || (User.IsInRole("Admin")))
                {
                    await _productService.DeleteAsync(id);
                    await _productImageService.DeleteImagesByProductId(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ürün resmi silme işlemi.
        /// </summary>
        /// <param name="productImageId"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteImage(Guid productImageId)
        {
            try
            {
                //Satıcı kendi ürününün resmini silebilir veya Admin silebilir.
                var productImage = await _productImageService.GetByIdAsync(productImageId);
                var myProduct = await _productService.IsMyProduct(productImage.ProductId, Guid.Parse(ClaimTypes.PostalCode));
                if ((User.IsInRole("Satıcı") && myProduct) || (User.IsInRole("Admin")))
                {
                    await _productImageService.DeleteImageById(productImageId);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ürün detay sayfası.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetProduct(Guid id)
        {
            try
            {
                var myProduct = await _productService.IsMyProduct(id, Guid.Parse(ClaimTypes.PostalCode));
                if ((User.IsInRole("Satıcı") && myProduct) || (User.IsInRole("Admin")))
                {
                    var product = await _productService.GetProductWithImagesAsync(id);
                    return View(product);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}