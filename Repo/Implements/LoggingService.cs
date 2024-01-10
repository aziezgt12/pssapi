using Dapper;
using System.Data;

namespace krodect.api.Repo.Implements
{
    public class LoggingService
    {
        private readonly ILogger<LoggingService> _logger;
        private readonly IDbConnection _context;

        public LoggingService(ILogger<LoggingService> logger, IDbConnection dbConnection)
        {
            _logger = logger;
            _context = dbConnection;
        }

        public async void LogToDatabase(LogLevel logLevel, string message, string classNmae, string methodName)
        {
            var sql = "INSERT INTO log (log_level, log_message, log_timestamp, log_by, method_name, class_name) VALUES (@logLevel, @logMessage, @logTimestamp, @logBy, @methodName, @className)";

            await _context.ExecuteAsync(sql,
                new
                {
                    LogLevel = logLevel.ToString(),
                    LogMessage = message,
                    LogTimestamp = DateTime.UtcNow,
                    logBy = message,
                    methodName = message,
                    className = message,
                });
        }


        public void LogInformation(string message, string method)
        {
            //LogToDatabase(LogLevel.Information, message, method);
            _logger.LogInformation(message);
        }
        public void LogError(string message, string method)
        {
            //LogToDatabase(LogLevel.Error, message, method);
            _logger.LogInformation(message);
        }

    }
}
