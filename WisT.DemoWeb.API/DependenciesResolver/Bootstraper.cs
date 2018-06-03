using Microsoft.Extensions.DependencyInjection;
using WisT.DemoWeb.API.Infrastructure;
using WisT.DemoWeb.API.Services;
using WisT.DemoWeb.Persistence.Control;
using WisT.DemoWeb.Persistence.DataEntities;
using WisT.Recognizer.Contracts;
using System.Data.Entity.Infrastructure;

namespace WisT.DemoWeb.API.DependenciesResolver
{
    public class Bootstraper
    {
        public static void RegisterWisTDependencies(IServiceCollection services)
        {
            services.AddTransient<ILabelStorage, LabelStorage>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IRootDirectoryProvider, RootDirectoryProvider>();
            services.AddTransient<IDbContextFactory<WisTEntities>, WisTContextFactory>();
        }
    }
}
