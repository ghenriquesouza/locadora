﻿using Locadora.Business.Interfaces;
using Locadora.Business.Models;
using Locadora.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Data.Repository
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(MeuDBContext context) : base(context) { }

    }
}
