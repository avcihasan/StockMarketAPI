using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Collections.ObjectModel;
using Serilog.Core;
using StockMarket.API.Configurations.SeriLogEnriches;
using Serilog.Context;
using Microsoft.AspNetCore.HttpLogging;
using Serilog.Events;

namespace StockMarket.API.Extensions
{
    public static class ConfigureLogExtension
    {
        public static IHostBuilder AddSeriLog(this ConfigureHostBuilder host, ConfigurationManager configuration)
        {
            return host.UseSerilog(CreateLogger(configuration));
        }

        public static IServiceCollection Add_HttpLogging(this IServiceCollection service)
        {
            return service.AddHttpLogging(logging =>
              {
                  logging.LoggingFields = HttpLoggingFields.All;
                  logging.RequestHeaders.Add("sec-ch-ua");
                  logging.ResponseHeaders.Add("MyResponseHeader");
                  logging.MediaTypeOptions.AddText("application/javascript");
                  logging.RequestBodyLogLimit = 4096;
                  logging.ResponseBodyLogLimit = 4096;

              });
        }

        public static IApplicationBuilder UseAddUserNameToLogContext(this WebApplication builder)
        {
            return builder.Use(async (context, next) =>
             {
                 var username = context.User?.Identity.IsAuthenticated != null || true ? context.User.Identity.Name : null;
                 LogContext.PushProperty("UserName", username);
                 await next();
             });
        }
        private static ColumnOptions GetColumnOptions()
        {
            SqlColumn sqlColumn = new()
            {
                ColumnName = "UserName",
                DataType = System.Data.SqlDbType.NVarChar,
                PropertyName = "UserName",
                DataLength = 50,
                AllowNull = true
            };
            ColumnOptions columnOpt = new();
            columnOpt.Store.Remove(StandardColumn.Properties);
            columnOpt.Store.Add(StandardColumn.LogEvent);
            columnOpt.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };

            return columnOpt;
        }

        private static Logger CreateLogger(ConfigurationManager configuration)
        {
            Logger logger = new LoggerConfiguration()
                   .WriteTo.File("Logs/GeneralLogs",LogEventLevel.Information)
                   .WriteTo.File("Logs/ErrorLogs", LogEventLevel.Error)
                   .WriteTo.Console(LogEventLevel.Information)
                   .WriteTo.MSSqlServer(
                               connectionString: configuration.GetConnectionString("SqlCon"),
                            sinkOptions: new MSSqlServerSinkOptions
                            {
                                AutoCreateSqlTable = true,
                                TableName = "Logs",
                            },
                            appConfiguration: null,
                            columnOptions: GetColumnOptions()
                               )
                .Enrich.FromLogContext()
               .Enrich.With<UserNameColumn>()
               .CreateLogger();
            return logger;
        }
    }
}
