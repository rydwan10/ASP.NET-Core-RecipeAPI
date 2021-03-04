﻿using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
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
