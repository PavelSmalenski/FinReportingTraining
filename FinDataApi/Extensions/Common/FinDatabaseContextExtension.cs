using FinDatabase;
using FinDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Extensions.Common;

static class FinDatabaseContextExtension
{
    public static async Task<int[]> GetCompanyIds(this FinDatabaseContext dbContext)
    {
        return await dbContext.Companies
            .Select(c => c.Id)
            .ToArrayAsync();
    }

    public static async Task<Company?> GetCompany(this FinDatabaseContext dbContext, int companyId)
    {
        return await dbContext.Companies
            .Where(comp => comp.Id == companyId)
            .FirstOrDefaultAsync();
    }

    public static async Task<int[]> GetAccountIds(this FinDatabaseContext dbContext, int companyId)
    {
        return await dbContext.Accounts
            .Where(a => a.CompanyId == companyId)
            .Select(a => a.Id)
            .ToArrayAsync();
    }

    public static async Task<Account?> GetAccount(this FinDatabaseContext dbContext, int companyId, int accountId)
    {
        return await dbContext.Accounts
            .Where(acc => acc.CompanyId == companyId && acc.Id == accountId)
            .FirstOrDefaultAsync();
    }
}