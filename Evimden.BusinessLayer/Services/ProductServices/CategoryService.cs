using AutoMapper;
using Evimden.BusinessLayer.Interfaces.ProductInterfaces;
using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.DTOs.ProductDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.ProductServices
{
    public class CategoryService : Service<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Category> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
