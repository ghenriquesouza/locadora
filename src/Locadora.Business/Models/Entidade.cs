using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Business.Models
{
    public abstract class Entidade
    {
      
            protected Entidade()
            {
                Id = Guid.NewGuid();
            }

            public Guid Id { get; set; }
        }
}
