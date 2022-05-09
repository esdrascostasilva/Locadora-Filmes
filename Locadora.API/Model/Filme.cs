using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.API.Model
{
    public class Filme : Entity
    {
        [ForeignKey("Diretor")]
        public Guid DiretorId { get; set; }
        // EF Relations
        public virtual Diretor Diretor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int duracao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataLancamento { get; set; }

        
    }
}
