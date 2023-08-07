using AutoMapper;
using CasgemMicroservice.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Catalog.Models;
using CasgemMicroservice.Catalog.Settings.Abstract;
using CasgemMicroservice.Shared.Dtos;
using MongoDB.Driver;

namespace CasgemMicroservice.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        }

        public async Task<Response<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
           var value=_mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);

            return Response<CreateCategoryDto>.Success(_mapper.Map<CreateCategoryDto>(value), 200);
        }

        public async Task<Response<NoContent>> DeleteCategoryAsync(string id)
        {
            var value=await _categoryCollection.DeleteOneAsync(x=>x.CategoryID==id);
            if(value.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);

            }
            else
            {
                return Response<NoContent>.Fail("Silinecek kategori bulunamadı", 404);
            }
        }

        public async Task<Response<List<ResultCategoryDto>>> GetCategoryAsync()
        {
            var values=await _categoryCollection.Find(x=>true).ToListAsync();
            return Response<List<ResultCategoryDto>>.Success(_mapper.Map<List<ResultCategoryDto>>(values),200);
        }

        public async Task<Response<ResultCategoryDto>> GetCategoryByIDAsync(string id)
        {
            var value=await _categoryCollection.Find<Category>(x=>x.CategoryID==id).FirstOrDefaultAsync();
            if(value == null)
            {
                return Response<ResultCategoryDto>.Fail("Böyle bir ID Bulunamadı !", 404);

            }
            else
            {
                return Response<ResultCategoryDto>.Success(_mapper.Map<ResultCategoryDto>(value),200);
            }
        }

        public async Task<Response<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
           var value=_mapper.Map<Category>(updateCategoryDto);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, value);
            if(result == null)
            {
                return Response<UpdateCategoryDto>.Fail("Güncellenecek veri bulunamadı", 404);
            }
            else
            {
                return Response<UpdateCategoryDto>.Success(204);
            }
        }
    }
}
