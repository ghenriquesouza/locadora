using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Business.Models
{
    public class Filme: Entidade
    {
        public string Nome { get; set; }
        public DateTime Lancamento { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public bool Ativo { get; set; }
    }
}
