using System.Collections.Generic;
using cAlgo.API;
using Logging.Core.Enums;
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