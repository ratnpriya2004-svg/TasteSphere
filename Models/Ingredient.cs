using System.ComponentModel.DataAnnotations;

namespace TasteSphere.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        [Required]
        [StringLength(100)]
        public string IngredientName { get; set; } = string.Empty;

        [StringLength(30)]
        public string? Unit { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
            = new List<RecipeIngredient>();
    }
}