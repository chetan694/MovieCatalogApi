using System.ComponentModel.DataAnnotations;

namespace MovieCatalogApi.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}