var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ShumiLog_ApiService>("apiservice");

builder.AddProject<Projects.ShumiLog_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
