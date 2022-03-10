using Communicator.Domain.Repositories.Base;
using Communicator.Infrastructure.Data;
using Communicator.Infrastructure.Repositories;
using Communicator.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Communicator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<CommunicatorContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
            //    ServiceLifetime.Transient, ServiceLifetime.Transient);


            services.AddDbContext<CommunicatorContext>(opt =>
               opt.UseSqlServer(
                   configuration.GetConnectionString("CommunicatorConnection"),
                   c => c.MigrationsAssembly(typeof(CommunicatorContext).Assembly.FullName)), ServiceLifetime.Transient );




            //Repositories

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IChatRepository, ChatRepository>(); 

            return services;
        }
    }
}