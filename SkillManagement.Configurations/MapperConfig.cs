using AutoMapper;
using SkillManagement.Data.Models;
using SkillManagement.Domain.DTOs.Categories;
using SkillManagement.Domain.DTOs.Practices;
using SkillManagement.Domain.DTOs.ProficiencyLevel;
using SkillManagement.Domain.DTOs.TechnologyStack;
using SkillManagement.Domain.DTOs.SkillsMatrix;

namespace SkillManagement.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {   
       

            CreateMap<Practices, GetPracticesDto>();
            CreateMap<Categories, GetCategoriesDto>();
            CreateMap<TechnologyStack, GetTechnologyStackDto>();

            CreateMap<ProficiencyLevel, GetProficiencyLevelDto>();

            
            CreateMap<SkillsMatrixResults, GetSkillsMatrixResultsDto>();
            CreateMap<SkillsMatrix, CreateSkillsMatrixDto>().ReverseMap();

            //CreateMap<SkillsMatrix, CreateSkillsMatrix>();

            //CreateMap<Category, GetCategoryProductsDto>()
            //    .AfterMap((src, dest) =>
            //    {
            //        dest.Products.ForEach(x => x.Price -= src.CategoryDiscount);
            //    });

            //CreateMap<Product, ProductDto>()
            //    .ForMember(
            //        dest => dest.Price,
            //        opt => opt.MapFrom((src, dest, member, context) => src.Price - src.Category.CategoryDiscount));


            //CreateMap<Category, GetCategoryProductsDto>()
            //    .ConvertUsing<CategoryProductsMapper>();
            //CreateMap<Category, List<ProductDto>>().ReverseMap();



            //CreateMap<Product, ProductDto>()
            //    .ForMember(dest => dest.Price, source => source.MapFrom<GetProductDiscount>())
            //    .ForMember(dest => dest.CategoryName, source => source.MapFrom(s => s.Category.CategoryName));


        }
    }
}
