using System.Reflection;
using System.Text.Json;
using log4net.Config;
using LoggingConsole.Extensions;
using NLog;
using Serilog;

namespace LoggingConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("NLog Logger:");
            ConfigureNLog();
            LogNLog();
            Console.WriteLine("NLog with object:");
            LogNLogWithObject();
            Console.WriteLine("==============");

            Console.WriteLine("log4net Logger:");
            Configureog4Net();
            LogLog4Net();
            Console.WriteLine("log4net with object:");
            LogLog4NetWithObject();
            Console.WriteLine("==============");

            Console.WriteLine("Serilog Logger:");
            ConfigureSerilog();
            LogSerilog();
            Console.WriteLine("Serilog with object:");
            LogSerilogWithObject();
            Console.WriteLine("==============");
        }

        public static void ConfigureNLog()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logFile = new NLog.Targets.FileTarget("logfile") { FileName = "nlog_log.txt" };
            var logConsole = new NLog.Targets.ConsoleTarget("logconsole");
            var logCustom = new NLogCustomTarget();

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logConsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logCustom);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }

        public static void LogNLog()
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Debug("debug message");
            logger.Info("info message");
            logger.Warn("warn message");
            logger.Error("error message");
            logger.Fatal("fatal message");
        }

        public static void LogNLogWithObject()
        {
            var logger = LogManager.GetCurrentClassLogger();
            var person = new Person { Name = "John", Age = 42 };
            logger.Debug("debug message with object {@person}", person);
            logger.Info("info message with object {@person}", person);
            logger.Warn("warn message with object {@person}", person);
            logger.Error("error message with object {@person}", person);
            logger.Fatal("fatal message with object {@person}", person);
        }

        public static void Configureog4Net()
        {
            var logRepository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());

            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        public static void LogLog4Net()
        {
            var logger = log4net.LogManager.GetLogger(typeof(Program));
            logger.Debug("debug message");
            logger.Info("info message");
            logger.Warn("warn message");
            logger.Error("error message");
            logger.Fatal("fatal message");
        }

        public static void LogLog4NetWithObject()
        {
            var logger = log4net.LogManager.GetLogger(typeof(Program));
            var person = new Person { Name = "John", Age = 42 };
            logger.Debug($"debug message with object {JsonSerializer.Serialize(person)}");
            logger.Info($"info message with object {JsonSerializer.Serialize(person)}");
            logger.Warn($"warn message with object {JsonSerializer.Serialize(person)}");
            logger.Error($"error message with object {JsonSerializer.Serialize(person)}");
            logger.Fatal($"fatal message with object {JsonSerializer.Serialize(person)}");

        }

        public static void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("serilog_log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Sink(new SerilogCustomSink())
                .CreateLogger();
        }

        public static void LogSerilog()
        {
            Log.Debug("debug message");
            Log.Information("info message");
            Log.Warning("warn message");
            Log.Error("error message");
            Log.Fatal("fatal message");
        }

        public static void LogSerilogWithObject()
        {
            var person = new Person { Name = "John", Age = 42 };
            Log.Debug("debug message with object {@person}", person);
            Log.Information("info message with object {@person}", person);
            Log.Warning("warn message with object {@person}", person);
            Log.Error("error message with object {@person}", person);
            Log.Fatal("fatal message with object {@person}", person);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}