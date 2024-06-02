using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace MyMarket.Filter
{
    public class MyMarketExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<MyMarketExceptionFilter> _logger;

        public MyMarketExceptionFilter(ILogger<MyMarketExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(0), context.Exception, "An error occured while processing your request.");
        }
    }
}
