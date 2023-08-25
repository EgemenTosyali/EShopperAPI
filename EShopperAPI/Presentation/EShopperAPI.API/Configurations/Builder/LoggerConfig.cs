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
            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .WriteTo.Seq(Environment.GetEnvironmentVariable("seqURL").ToString())
                .WriteTo.PostgreSQL(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") switch
                {
                    "Development" => Environment.GetEnvironmentVariable("PostgreSQL_Development").ToString(),
                    "Staging" => Environment.GetEnvironmentVariable("PostgreSQL_Staging").ToString(),
                    "Production" => Environment.GetEnvironmentVariable("PostgreSQL_Production").ToString()
                }, "logs", needAutoCreateTable: true,
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
