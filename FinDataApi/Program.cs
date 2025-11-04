
using FinDatabase;
using Reports.Common;
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

        builder.Services.AddMemoryCache();

        builder.Services.AddDbContext<FinDatabaseContext>();
        builder.Services.AddSingleton<CommonEntriesReader>();
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
        app.MapGet("/common/companies", async (HttpContext context, FinDatabaseContext dbContext, CommonEntriesReader dataBuilder) =>
        {
            return Results.Json(await dataBuilder.GetCompanyIds(dbContext));
        });
        app.MapGet("/common/companies/{companyId}", async (HttpContext context, FinDatabaseContext dbContext, CommonEntriesReader dataBuilder, int companyId) =>
        {
            return Results.Json(await dataBuilder.GetCompany(dbContext, companyId));
        });

        app.MapGet("/common/accounts/{companyId}", async (HttpContext context, FinDatabaseContext dbContext, CommonEntriesReader dataBuilder, int companyId) =>
        {
            return Results.Json(await dataBuilder.GetAccountIds(dbContext, companyId));
        });
        app.MapGet("/common/accounts/{companyId}/{accountId}", async (HttpContext context, FinDatabaseContext dbContext, CommonEntriesReader dataBuilder, int companyId, int accountId) =>
        {
            return Results.Json(await dataBuilder.GetAccount(dbContext, companyId, accountId));
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
