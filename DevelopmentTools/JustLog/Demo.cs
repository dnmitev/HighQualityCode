namespace JustLog
{
    using System;
    using System.Linq;
    using log4net;
    using log4net.Config;
    
    internal class Demo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Demo));

        private static void Main()
        {
            BasicConfigurator.Configure();

            log.Info("Info message!");
            log.Error("Error message!");
            log.Warn("Warning message!");
        }
    }
}