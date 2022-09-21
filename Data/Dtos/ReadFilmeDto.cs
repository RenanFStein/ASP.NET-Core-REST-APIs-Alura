using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required(ErrorMessage = "O campo {0} é Obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é Obrigatório.")] // Campo Obrigatório
        [StringLength(5, ErrorMessage = "O {0} não pode exceder {1} caracteres. ")] // Caracteres Máximo.
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "Valor da {0} deve estar entre {1} e {2}")] // Valor deve estar entre.
        public int Duracao { get; set; }

        //Retornando Dados Extras que não estão salvo no Banco de Dados
        public DateTime HoraDaConsulta { get; set; }
    }
}