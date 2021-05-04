using HawesAndCurtis.Core.Logging;
using Microsoft.Extensions.Logging;

namespace HawesAndCurtis.Infrastructure.Logging
{
    public class HawesAndCurtisLogger<T> : IHawesAndCurtisLogger<T>
    {
        private readonly ILogger<T> _logger;

        public HawesAndCurtisLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
    }
}
