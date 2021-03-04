using RecipeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeAPI.Data
{
    public interface IRecipeRepo
    {
        Task<IEnumerable<Recipe>> GetAllRecipes();
        Task<Recipe> GetRecipeById(int id);
        Task CreateRecipe(Recipe recipe);
        Task<bool> SaveChanges();
        void DeleteRecipe(Recipe recipe);
        void UpdateRecipePut(Recipe recipe);

    }
}
