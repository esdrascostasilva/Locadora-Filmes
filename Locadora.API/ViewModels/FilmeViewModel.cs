using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.API.ViewModels
{
    public class FilmeViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid DiretorId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int duracao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataLancamento { get; set; }

        [ScaffoldColumn(false)]
        public string NomeDiretor { get; set; }

    }
}
