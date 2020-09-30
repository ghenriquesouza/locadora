using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Business.Models
{
   public class Locacao: Entidade
    {
        public DateTime Inicio { get; set; }
        public DateTime Devolucao { get; set; }

        public Guid ClienteId { get; set; }
        public Guid FilmeId { get; set; }

        public Cliente Cliente { get; set; }
        public Filme Filme { get; set; }

    }
}
