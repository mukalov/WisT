using Microsoft.Extensions.Configuration;
using System;
using System.Data.Entity.Infrastructure;

namespace WisT.DemoWeb.Persistence.DataEntities
{
    public class WisTContextFactory : IDbContextFactory<WisTEntities>
    {
        public WisTEntities Create()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var basePath = AppContext.BaseDirectory;

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            return new WisTEntities(configuration.GetConnectionString("WisTEntities"));
        }
    }
}
