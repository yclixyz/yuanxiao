using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gugubao.Award.Infrastructure
{
    public class SerilogLogger
    {
        public SerilogLogger()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        }

        public void Infomation(string msg)
        {
            Log.Logger.Information(msg);
        }

        public void Error(Exception ex, string msg)
        {
            Log.Logger.Error(ex, msg);
        }
    }
}
