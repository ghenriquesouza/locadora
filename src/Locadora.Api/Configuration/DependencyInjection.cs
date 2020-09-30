using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Business.Interfaces;
using Locadora.Data.Context;
using Locadora.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Locadora.Business.Services;


namespace Locadora.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDBContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<ILocacaoRepository, LocacaoRepository>();

            services.AddScoped<IFilmeRepository, FilmeRepository>();

            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFilmeService, FilmeService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



            return services;
        }

    }
}
