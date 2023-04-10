using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingConsole.Extensions
{
    public class log4netCustomAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            // Custom logic for handling log events
        }
    }
}
