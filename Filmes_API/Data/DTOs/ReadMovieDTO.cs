using Movies_API.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Movies_API.Data.DTOs
{
    public class ReadMovieDTO
    {
        public required String Title { get; set; }
        public required String Synopsis { get; set; }
        public required String Gender { get; set; }
        public int Duraction { get; set; }
        public int Launch_year { get; set; }
        public DateTime Date_read { get; set; } = DateTime.Now;
    }
}
