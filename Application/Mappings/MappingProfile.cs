using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.ViewModel;
using Application.Features.Products.Commands.CreateProduct;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Category Mappings
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, CategoryViewModel>();
            #endregion
            #region Product Mappings
            CreateMap<CreateProductCommand, Product>();
            #endregion
        }
    }
}
