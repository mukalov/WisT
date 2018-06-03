using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WisT.DemoWeb.API.Infrastructure
{
    public class ExceptionFilter : IExceptionFilter
    {
        private ILoggerFactory _loggerFactory;

        public ExceptionFilter(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void OnException(ExceptionContext context)
        {
            _loggerFactory.CreateLogger("Errors").LogError(context.Exception, "Error");
        }
    }
}
