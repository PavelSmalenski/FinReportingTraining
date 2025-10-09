
using FinDatabase;
using Reports.Rpt1WeeklyBalance;
using Reports.Rpt1WeeklyBalance.Processing;

namespace FinDataApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        // builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<FinDatabaseContext>();
        builder.Services.AddSingleton<WeeklyBalanceDataBuilder>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
        {
            var forecast =  Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast");


        app.MapGet("/rpt607b/data/rows/{companyId}/{accountId}", async (HttpContext context, FinDatabaseContext dbContext, WeeklyBalanceDataBuilder dataBuilder, int companyId, int accountId) =>
        {
            return Results.Json(await dataBuilder.GetData(dbContext, companyId, accountId));
        });

        app.MapGet("/rpt607b/data/headings/{companyId}/{accountId}", async (HttpContext context, FinDatabaseContext dbContext, WeeklyBalanceDataBuilder dataBuilder, int companyId, int accountId) =>
        {
            return Results.Json(await dataBuilder.GetHeaderData(dbContext, companyId, accountId));
        });

        app.Run();
    }
}
