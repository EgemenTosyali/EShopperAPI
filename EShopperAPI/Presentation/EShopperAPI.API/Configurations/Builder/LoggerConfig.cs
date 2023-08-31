using EShopperAPI.API.Configurations.ColumnWriters;
using EShopperAPI.Persistence;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

namespace EShopperAPI.API.Configurations.Builder
{
    public class LoggerConfig
    {
        private readonly IConfiguration _configuration;
        public LoggerConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Logger getLogger()
        {
            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .WriteTo.Seq(_configuration["seqURL"])
                .WriteTo.PostgreSQL(_configuration["PostgreSQL_ConnectionString"], "logs", needAutoCreateTable: true,
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
