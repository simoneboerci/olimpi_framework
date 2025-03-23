using System.Collections.Generic;
using cAlgo.API;
using Logging.Core.Enums;
using Logging.Core.Factories;
using Logging.Core.Interfaces;
using Logging.Core.Models;
using Logging.Data.Formatters;
using Logging.Data.Providers;
using Logging.Services;

namespace cAlgo.Robots
{
    [Robot(AccessRights = AccessRights.FullAccess, AddIndicators = true)]
    public class OlimpiFramework : Robot
    {
        [Parameter(DefaultValue = "Hello world!")]
        public string Message { get; set; }

        Logger logger;

        protected override void OnStart()
        {
            ISystemConsoleFactory consoleFactory = new SystemConsoleFactory();
            ISystemConsole console = consoleFactory.Create();

            var providers = new List<ILogProvider>
            {
                new ConsoleLogProvider(new PlainTextLogFormatter(), console)
            };
            logger = new Logger(providers);
            logger.Log(new LogEntry(LogLevel.Debug, "Hello world!"));
        }

        protected override void OnTick()
        {
            
        }

        protected override void OnStop()
        {
            // Handle cBot stop here
        }
    }
}