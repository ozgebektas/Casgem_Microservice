using CasgemMicroservice.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Catalog.Dtos.ProductDtos;
using CasgemMicroservice.Shared.Dtos;

namespace CasgemMicroservice.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDto>>> GetProductAsync();
        Task<Response<ResultProductDto>> GetProductByIDAsync(string id);
        Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto createProductDto);
        Task<Response<UpdateProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteProductAsync(string id);
        Task<Response<List<ResultProductDto>>> GetProductListWithCategoryAsync();
    }
}
