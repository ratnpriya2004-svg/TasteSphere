using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasteSphere.Models
{
    public class RecipeStep
    {
        [Key]
        public int StepId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int StepNumber { get; set; }

        [Required]
        [StringLength(1000)]
        public string Instruction { get; set; } = string.Empty;

        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }
    }
}