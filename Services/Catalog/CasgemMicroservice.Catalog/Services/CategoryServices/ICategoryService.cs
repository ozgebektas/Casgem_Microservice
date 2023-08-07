using CasgemMicroservice.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Shared.Dtos;

namespace CasgemMicroservice.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDto>>> GetCategoryAsync();
        Task<Response<ResultCategoryDto>> GetCategoryByIDAsync(string id);
        Task<Response<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<Response<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<Response<NoContent>> DeleteCategoryAsync(string id);
    }
}
