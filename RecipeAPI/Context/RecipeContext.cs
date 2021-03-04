using RecipeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Context
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> opt ) : base (opt)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Chef>  Chefs { get; set; }
    }
}
