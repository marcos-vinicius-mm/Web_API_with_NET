using Movies_API.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Movies_API.Models
{
    public class Movie
    {
        private const String error_message = "Informação Obrigatória!";
        private const String error_length = "Tamanho Máximo Atingido!";
        private const String error_value = "Valor Inválido!";


        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = error_message)]
        [MaxLength(100, ErrorMessage = error_length)]
        public required String Title { get; set; }

        [Required(ErrorMessage = error_message)]
        [MaxLength(500, ErrorMessage = error_length)]
        public required String Synopsis { get; set; }

        [Required(ErrorMessage = error_message)]
        [MaxLength(30, ErrorMessage = error_length)]
        public required String Gender { get; set; }

        [Required(ErrorMessage = error_message)]
        [Range(50, 600, ErrorMessage = error_value)]
        public int Duraction { get; set; }

        [Required(ErrorMessage = error_message)]
        [CurrentYear]
        public int Launch_year { get; set; }
    }
}
