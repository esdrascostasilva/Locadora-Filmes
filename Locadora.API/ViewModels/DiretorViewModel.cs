using Locadora.API.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locadora.API.ViewModels
{
    public class DiretorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DataNascimento { get; set; }
        public int Sexo { get; set; }
        public IEnumerable<Filme> Filmes { get; set; }
    }
}
