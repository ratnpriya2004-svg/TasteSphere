using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasteSphere.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        public DateTime? AddedDate { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }
    }
}