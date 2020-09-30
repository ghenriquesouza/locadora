using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Business.Models
{
    public class Cliente: Entidade
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public bool Ativo { get; set; }


    }
}
