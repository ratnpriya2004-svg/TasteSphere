using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasteSphere.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(1000)]
        public string? CommentText { get; set; }

        public DateTime? ReviewDate { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }
    }
}