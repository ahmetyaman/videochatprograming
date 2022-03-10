using Communicator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Communicator.ApiServer.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var dbcontext = scope.ServiceProvider.GetRequiredService<CommunicatorContext>();

                    if (dbcontext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        dbcontext.Database.Migrate();
                    }
                    CommunicatorContextSeed.SeedAsync(dbcontext).Wait();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }

            return host;
        }
    }
}