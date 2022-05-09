using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.API.Model
{
    public class Filme : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int duracao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataLancamento { get; set; }

        // EF Relations
        public Diretor Diretor { get; set; }
    }
}
