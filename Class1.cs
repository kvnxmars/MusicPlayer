using System.ComponentModel.DataAnnotations;

namespace MusicWebAPI
{
    public class TrackDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2–100 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Artist is required.")]
        public string Artist { get; set; }
        [Required(ErrorMessage = "Album is reuiqured.")]
        public string Album { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than zero.")]
        public int Duration { get; set; } // Duration in seconds

        [Required(ErrorMessage = "Genre is reuquired!")]
        public string Genre { get; set; }

    }
    
}
