using Microsoft.AspNetCore.Hosting;
using WisT.DemoWeb.FilePersistence;

namespace WisT.DemoWeb.API.Infrastructure
{
    public class RootDirectoryProvider : IRootDirectoryProvider
    {
        private IHostingEnvironment _hostingEnvironment;

        public RootDirectoryProvider(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string RootDirectory => _hostingEnvironment.ContentRootPath;
    }
}
