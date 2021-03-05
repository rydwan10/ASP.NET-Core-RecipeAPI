using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace RecipeAPI.Models
{
    public class Chef
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(230)]
        public string Name { get; set; }

        [Required]
        public string Specialist { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
