using RecipeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Context
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> opt ) : base (opt)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasOne(r => r.Chef).WithMany(c => c.Recipes).HasForeignKey(r => r.ChefId).HasConstraintName("ForeignKey_Recipe_Chef").OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Chef>().HasMany(c => c.Recipes);
            modelBuilder.Entity<Recipe>().Navigation(r => r.Chef);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Chef>  Chefs { get; set; }
    }
}
