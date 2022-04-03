using System.ComponentModel.DataAnnotations;

namespace NetCore_Docker_Easy.Models
{
    public class Film
    {
        [Required]
        public int ReleaseYear { get; set; } = 1970;

        [Required]
        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Movie name cannot exceed 50 characters.")]
        public string MovieName { get; set; } = string.Empty;
    }
}