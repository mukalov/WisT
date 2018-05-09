using Microsoft.Extensions.DependencyInjection;
using WisT.DemoWeb.API.Services;
using WisT.DemoWeb.FilePersistence;
using WisT.Recognizer.Contracts;

namespace WisT.DemoWeb.API.DependenciesResolver
{
    public class Bootstraper
    {
        public static void RegisterWisTDependencies(IServiceCollection services)
        {
            services.AddTransient<ILabelStorage, LabelStorage>();
            services.AddTransient<IImageStorage, ImageStorage>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}
