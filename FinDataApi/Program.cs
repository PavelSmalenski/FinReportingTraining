
using FinDatabase;
using Extensions.Common;
using Handlers.Reports.Rpt1WeeklyBalance.Response;

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

        builder.Services.AddMemoryCache();

        builder.Services.AddDbContext<FinDatabaseContext>();
        builder.Services.AddSingleton<WeeklyBalanceDataExtractor>();

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

        MapCommonEndpoints(app);
        MapRpt1Endpoints(app);

        app.Run();
    }

    static void MapCommonEndpoints(WebApplication app)
    {
        app.MapGet("/common/companies", async (HttpContext context, FinDatabaseContext dbContext) =>
        {
            return Results.Json(await dbContext.GetCompanyIds());
        });
        app.MapGet("/common/companies/{companyId}", async (HttpContext context, FinDatabaseContext dbContext, int companyId) =>
        {
            return Results.Json(await dbContext.GetCompany(companyId));
        });

        app.MapGet("/common/accounts/{companyId}", async (HttpContext context, FinDatabaseContext dbContext, int companyId) =>
        {
            return Results.Json(await dbContext.GetAccountIds(companyId));
        });
        app.MapGet("/common/accounts/{companyId}/{accountId}", async (HttpContext context, FinDatabaseContext dbContext, int companyId, int accountId) =>
        {
            return Results.Json(await dbContext.GetAccount(companyId, accountId));
        });
    }

    static void MapRpt1Endpoints(WebApplication app)
    {
        app.MapGet("/rpt1/rows/{companyId}/{accountId}", async (HttpContext context, FinDatabaseContext dbContext, WeeklyBalanceDataExtractor dataBuilder, int companyId, int accountId) =>
        {
            return Results.Json(await dataBuilder.GetData(dbContext, companyId, accountId));
        });

        app.MapGet("/rpt1/heading/{companyId}/{accountId}", async (HttpContext context, FinDatabaseContext dbContext, WeeklyBalanceDataExtractor dataBuilder, int companyId, int accountId) =>
        {
            return Results.Json(await dataBuilder.GetHeaderData(dbContext, companyId, accountId));
        });

        app.MapGet("/rpt1/total/{companyId}/{accountId}", async (HttpContext context, FinDatabaseContext dbContext, WeeklyBalanceDataExtractor dataBuilder, int companyId, int accountId, int? provinceId) =>
        {
            return Results.Json(await dataBuilder.GetTotal(dbContext, companyId, accountId, provinceId));
        });
    }
}
