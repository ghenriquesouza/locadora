using Locadora.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Tests
{
    public class ConnectionFactory
    {

        public MeuDBContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<MeuDBContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new MeuDBContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

       
    }
}
