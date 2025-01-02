using Evimden.CoreLayer.Concrete;
using Evimden.CoreLayer.Concrete.CargoEntities;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.CoreLayer.DTOs;
using Evimden.CoreLayer.DTOs.CargoDTOs;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.CoreLayer.DTOs.LocationDTOs;
using Evimden.CoreLayer.DTOs.OrderDTOs;
using Evimden.CoreLayer.DTOs.ProductDTOs;
using Evimden.CoreLayer.DTOs.ProfileDTOs;
using Microsoft.AspNetCore.Identity;

namespace Evimden.BusinessLayer.Mapper
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<BaseEntity, BaseDto>().ReverseMap();

            #region CARGO
            CreateMap<Shipper, ShipperDto>().ReverseMap();
            #endregion

            #region LOCATION
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            #endregion

            #region ORDER
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<ProductCart, ProductCartDto>().ReverseMap();
            #endregion

            #region PRODUCT
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductApproval, ProductApprovalDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();

            CreateMap<Product, ProductWithImagesDto>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src)) //Product entity'sini ProductDto'ya maplemek
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
            #endregion

            #region PROFILE
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<PaymentInformation, PaymentInformationDto>().ReverseMap();
            CreateMap<Phone, PhoneDto>().ReverseMap();
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<SellerApproval, SellerApprovalDto>().ReverseMap();
            #endregion

            #region IDENTITY
            CreateMap<CustomRole, CustomRoleDto>().ReverseMap();
            CreateMap<CustomRoleClaim, CustomRoleClaimDto>().ReverseMap();
            CreateMap<CustomUser, CustomUserDto>().ReverseMap();
            CreateMap<IdentityUser, CustomUserDto>().ReverseMap();
            CreateMap<CustomUserClaim, CustomUserClaimDto>().ReverseMap();
            CreateMap<CustomUserLogin, CustomUserLoginDto>().ReverseMap();
            CreateMap<CustomUserRole, CustomUserRoleDto>().ReverseMap();
            CreateMap<CustomUserToken, CustomUserTokenDto>().ReverseMap();
            #endregion
        }
    }
}
