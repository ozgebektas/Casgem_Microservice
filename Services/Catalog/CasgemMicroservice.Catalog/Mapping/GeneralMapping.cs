using AutoMapper;
using CasgemMicroservice.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Catalog.Dtos.ProductDtos;
using CasgemMicroservice.Catalog.Models;

namespace CasgemMicroservice.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
