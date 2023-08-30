using EShopperAPI.API.Configurations.ColumnWriters;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

namespace EShopperAPI.API.Configurations.Builder
{
    public static class LoggerConfig
    {
        public static Logger getLogger()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.AddJsonFile("appsettings.json");
            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .WriteTo.Seq(configurationManager.GetSection("seqURL").Value)
                .WriteTo.PostgreSQL(configurationManager.GetSection("PostgreSQL_ConnectionString").Value, "logs", needAutoCreateTable: true,
                    columnOptions: new Dictionary<string, ColumnWriterBase>
                    {
                        {"message", new RenderedMessageColumnWriter() },
                        {"message_template", new MessageTemplateColumnWriter() },
                        {"level", new LevelColumnWriter() },
                        {"time_stamp", new TimestampColumnWriter() },
                        {"exception", new ExceptionColumnWriter() },
                        {"log_event", new LogEventSerializedColumnWriter() } ,
                        {"user_name", new UsernameColumnWriter() }
                    })
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .CreateLogger();
            return log;
        }
    }
}
