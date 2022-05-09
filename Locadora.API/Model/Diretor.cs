using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locadora.API.Model
{
    public class Diretor : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DataNascimento { get; set; }

        public Sexo Sexo { get; set; }

        // EF Relations
        public virtual IEnumerable<Filme> Filmes { get; set; }

    }
}
