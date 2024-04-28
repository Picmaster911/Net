using System.ComponentModel.DataAnnotations;

namespace Application.Requests
{
    public class UpsertMovieRequest
    {
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
