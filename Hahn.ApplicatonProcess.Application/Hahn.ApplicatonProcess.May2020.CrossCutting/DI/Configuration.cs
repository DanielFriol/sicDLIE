using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.CrossCutting.DI
{
    public static class Configuration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            registerMediatr(services);
            registerData(services);

        }

        private static void registerMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "Hahn.ApplicatonProcess.May2020.Domain";
            var assembly = System.AppDomain.CurrentDomain.Load(applicationAssemblyName);

            FluentValidation.AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(Domain.Mediator.FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);
        }

        private static void registerData(IServiceCollection services)
        {
            services.AddScoped<Data.EF.ApplicationProjectDataContext>();
            services.AddTransient<Domain.Contracts.Infra.Data.IUnitOfWork, Data.EF.UnitOfWorkEF>();

            services.AddTransient<Domain.Contracts.Repositories.IPersonReadRepository, Data.EF.Repositories.PersonReadRespository>();
            services.AddTransient<Domain.Contracts.Repositories.IPersonWriteRepository, Data.EF.Repositories.PersonWriteRespository>();

        }



    }
}
