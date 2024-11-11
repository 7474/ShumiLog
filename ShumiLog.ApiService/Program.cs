using ShumiLog.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddMySqlDbContext<ApplicationDbContext>("mysqldb");
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // See. MigrationService
    //using (var scope = app.Services.CreateScope())
    //{
    //    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //    context.Database.EnsureCreated();
    //}
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    //  https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapGet("/weatherforecast", () =>
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var forecast = db.WeatherForecasts.OrderBy(x => x.Date).ToList();
    return forecast;
});

app.MapDefaultEndpoints();

app.Run();
