using RecipeAPI.Models;
using System.Collections.Generic;
namespace RecipeAPI.Dtos
{
    public class RecipeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredient { get; set; }
        public string Description { get; set; }
        public Chef Chef { get; set; }
        // Time will not displayed when retrieved from Database
        // public string Time { get; set; }
    }
}
