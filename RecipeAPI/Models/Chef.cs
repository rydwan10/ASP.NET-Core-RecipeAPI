using System.ComponentModel.DataAnnotations;
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
        public string Position { get; set; }
    }
}
