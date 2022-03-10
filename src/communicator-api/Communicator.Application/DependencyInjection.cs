using AutoMapper;
using Communicator.Application.Mapper;
using Communicator.Application.PipelineBehaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Communicator.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            /* 
             * aşağıdaki sıralamaya göre intercepterlar  sırasıyla ayağa kalkıp  çalışırlar   yeni eklenen pipeline behavivourda bu sıralamaya dikkat ederek 
               eklemek ve karar vermek gerekir.

            */
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            var config = new MapperConfiguration(cfg =>
           {
               cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
               cfg.AddProfile<PersonMappingProfile>();
               cfg.AddProfile<ChatMappingProfile>();
           });
            var mapper = config.CreateMapper();

            return services;
        }
    }
}