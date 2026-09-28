using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasteSphere.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        [StringLength(150)]
        public string RecipeName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public int? CuisineId { get; set; }

        public int? PrepTime { get; set; }

        public int? CookTime { get; set; }

        [StringLength(30)]
        public string? Difficulty { get; set; }

        public int? Servings { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [ForeignKey("CuisineId")]
        public Cuisine? Cuisine { get; set; }
    }
}