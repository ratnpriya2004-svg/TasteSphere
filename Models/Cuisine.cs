using System.ComponentModel.DataAnnotations;

namespace TasteSphere.Models
{
    public class Cuisine
    {
        [Key]
        public int CuisineId { get; set; }

        [Required]
        [StringLength(100)]
        public string CuisineName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CountryName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}