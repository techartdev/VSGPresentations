using NLog.Targets;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingConsole.Extensions
{
    [Target("NLogCustomTarget")]
    public class NLogCustomTarget : Target
    {
        protected override void Write(LogEventInfo logEvent)
        {
            // Custom logic for handling log events
        }
    }
}
