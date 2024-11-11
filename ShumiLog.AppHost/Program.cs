using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql");
var mysqldb = mysql.AddDatabase("mysqldb");

builder.AddProject<Projects.ShumiLog_MigrationService>("migrations")
    .WithReference(mysqldb);

var apiService = builder.AddProject<Projects.ShumiLog_ApiService>("apiservice")
                       .WithReference(mysqldb);

builder.AddProject<Projects.ShumiLog_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
