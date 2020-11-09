using FernandoJose.CodeFirst.Application.Cliente.AppServices;
using FernandoJose.CodeFirst.Application.Cliente.Interfaces;
using FernandoJose.CodeFirst.Domain.Cliente.Commands;
using FernandoJose.CodeFirst.Domain.Cliente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Share.Pipelines;
using FernandoJose.CodeFirst.SqlServer.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FernandoJose.CodeFirst.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Sql Server Repository
            services.AddTransient<IClienteSqlServerRepository, ClienteSqlServerRepository>();

            // Application
            services.AddTransient<IClienteAppService, ClienteAppService>();

            // Command e Handler
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidacaoPipeline<,>));
            services.AddMediatR(typeof(ClienteAdicionarCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ClienteAtualizarCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ClienteDeletarCommand).GetTypeInfo().Assembly);
        }
    }
}