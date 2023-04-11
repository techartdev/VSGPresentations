using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingConsole.Extensions
{
    public class SerilogCustomSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
            // Custom logic for handling log events
        }
    }
}
