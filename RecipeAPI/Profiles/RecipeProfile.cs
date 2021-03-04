using AutoMapper;
using RecipeAPI.Dtos;
using RecipeAPI.Models;

namespace RecipeAPI.Profiles
{
    public class RecipeProfile : Profile
    {
        // Source -> Target
        // Source akan di map sesuai dengan DTO 
        public RecipeProfile(){
            CreateMap<Recipe, RecipeReadDto>();
            CreateMap<RecipeCreateDto, Recipe>();
            CreateMap<RecipeUpdateDto, Recipe>();
            CreateMap<Recipe, RecipeUpdateDto>();
            
        }
    }
}
