using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Dtos
{
    public class RecipeUpdateDto
    {
        [Required]
        [MaxLength(240)]
        public string Name { get; set; }
        [Required]
        public string Ingredient { get; set; }
        [Required]
        public string Description { get; set; }
        public string Time { get; set; }
    }
}
