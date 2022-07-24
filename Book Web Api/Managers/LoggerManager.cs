using Book_Web_Api.Managers.Intrefaces;
using NLog;
using System;

namespace Book_Web_Api.Managers
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            logger.Debug(message);
            Console.WriteLine(message);
        }
        public void LogError(string message) {

            logger.Error(message);
            Console.WriteLine(message);

        } 
        public void LogInfo(string message) {

            logger.Info(message);
            Console.WriteLine(message);

        } 
        public void LogWarn(string message) {

            logger.Warn(message);
            Console.WriteLine(message);

        }
    }
}
