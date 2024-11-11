using ShumiLog.Data.Context;
using ShumiLog.MigrationService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddMySqlDbContext<ApplicationDbContext>("mysqldb");

var host = builder.Build();
host.Run();
