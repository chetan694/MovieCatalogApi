using System.ComponentModel.DataAnnotations;

namespace MovieCatalogApi.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public int DirectorId { get; set; }

        public Director? Director { get; set; }
    }
}