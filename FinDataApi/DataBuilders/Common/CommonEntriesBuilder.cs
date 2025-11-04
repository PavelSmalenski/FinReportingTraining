using FinDatabase;
using FinDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Reports.Common;

class CommonEntriesReader
{
    public async Task<int[]> GetCompanyIds(FinDatabaseContext dbContext)
    {
        return await dbContext.Companies
            .Select(c => c.Id)
            .ToArrayAsync();
    }

    public async Task<Company?> GetCompany(FinDatabaseContext dbContext, int companyId)
    {
        return await dbContext.Companies
            .Where(comp => comp.Id == companyId)
            .FirstOrDefaultAsync();
    }

    public async Task<int[]> GetAccountIds(FinDatabaseContext dbContext, int companyId)
    {
        return await dbContext.Accounts
            .Where(a => a.CompanyId == companyId)
            .Select(a => a.Id)
            .ToArrayAsync();
    }

    public async Task<Account?> GetAccount(FinDatabaseContext dbContext, int companyId, int accountId)
    {
        return await dbContext.Accounts
            .Where(acc => acc.CompanyId == companyId && acc.Id == accountId)
            .FirstOrDefaultAsync();
    }
}