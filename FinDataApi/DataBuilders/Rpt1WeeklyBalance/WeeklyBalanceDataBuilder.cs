using FinDatabase;
using FinDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Reports.Rpt1WeeklyBalance.Entities;
using Reports.Rpt1WeeklyBalance.Processing;

namespace Reports.Rpt1WeeklyBalance;

class WeeklyBalanceDataBuilder
{
    public async Task<WeeklyBalanceHeaderData> GetHeaderData(FinDatabaseContext dbContext, int companyId, int accountId)
    {
        var companyControl = await dbContext.CompanyControls.Where(c => c.CompanyId == companyId)
                                                            .FirstOrDefaultAsync();

        WeeklyBalanceControlDates weeklyBalanceControlDates = companyControl is not null
            ? WeeklyBalanceDatesBuilder.GetDates(companyControl.CtlDayOfWeek, companyControl.Cbd)
            : new WeeklyBalanceControlDates();

        string ibt;
        string ibtName;
        if (accountId == 817930012 || accountId == 830480013 || accountId == 850410002)
        {
            ibt = "4219";
            ibtName = "Help desk";
        }
        else
        {
            ibt = "6294";
            ibtName = "Accounting";
        }

        var account = await dbContext.Accounts.Where(acc => acc.CompanyId == companyId && acc.Id == accountId)
                                              .FirstOrDefaultAsync();

        return new WeeklyBalanceHeaderData(
            Ibt: ibt,
            IbtName: ibtName,
            AccountDescription: account?.Description ?? "",
            AccountId: accountId,
            EntryDates: weeklyBalanceControlDates
        );
    }

    public async Task<WeeklyBalanceData> GetData(FinDatabaseContext dbContext, int companyId, int accountId)
    {
        return await ExtractReportData(dbContext, companyId, accountId);
    }

    public async ValueTask<WeeklyBalances> GetTotal(FinDatabaseContext dbContext, int companyId, int accountId, int? provinceId)
    {
        var data = await ExtractReportData(dbContext, companyId, accountId);
        var rows = provinceId == null
                    ? data.Rows
                    : data.Rows.Where(row => row.CenterRegion == provinceId);
        return new WeeklyBalances()
        {
            BalanceDay1 = rows.Sum(row => row.Balances.BalanceDay1),
            BalanceDay2 = rows.Sum(row => row.Balances.BalanceDay2),
            BalanceDay3 = rows.Sum(row => row.Balances.BalanceDay3),
            BalanceDay4 = rows.Sum(row => row.Balances.BalanceDay4),
            BalanceDay5 = rows.Sum(row => row.Balances.BalanceDay5),
            BalanceDay6 = rows.Sum(row => row.Balances.BalanceDay6)
        };
    }

    async Task<WeeklyBalanceData> ExtractReportData(FinDatabaseContext dbContext, int companyId, int accountId)
    {
        WeeklyBalanceData reportData = new WeeklyBalanceData();

        var centersQuery = dbContext.Centers
            .Where((center) =>
                center.Id != 0
                && center.Id != 999998
                && center.Id != 999999
                && center.CompanyId == companyId
                && center.AccountId == accountId
            )
            .Include(cent => cent.CurrentYearEndingBalances)
            .Include(cent => cent.WeekDailyActivities)
            .Include(cent => cent.Account)
            .ThenInclude(acc => acc.Company)
            .Join(dbContext.CenterControls,
                center => center.Id % 10000,
                control => control.CenterId,
                (center, centerControl) => new
                {
                    center.CompanyId,
                    center.AccountId,
                    CenterId = center.Id,

                    center.Account.Company.CurrentPeriod,
                    // ???
                    Balances = center.CurrentYearEndingBalances.First(),
                    WeekActivities = center.WeekDailyActivities.First(),

                    centerControl.CenterName,
                    centerControl.InternalBank,
                    centerControl.Region,
                    centerControl.TestIndex
                }
            )
            .Where(res => res.TestIndex != 'Y')
            .Join(dbContext.CompanyControls,
                centerAndCenterControl => centerAndCenterControl.CompanyId,
                companyControl => companyControl.CompanyId,
                (centerAndCenterControl, companyControl) => new
                {
                    centerAndCenterControl.CompanyId,
                    centerAndCenterControl.AccountId,
                    centerAndCenterControl.CenterId,

                    centerAndCenterControl.CurrentPeriod,
                    // ???
                    centerAndCenterControl.Balances,
                    centerAndCenterControl.WeekActivities,

                    centerAndCenterControl.CenterName,
                    centerAndCenterControl.InternalBank,
                    centerAndCenterControl.Region,

                    companyControl.Cbd,
                    companyControl.CtlDayOfWeek
                }
            );

        var centersQueryOrderedWithCount = centersQuery
            .OrderBy(res => res.AccountId)
            .ThenBy(res => res.CompanyId)
            .ThenBy(res => res.InternalBank)
            .ThenBy(res => res.Region)
            .ThenBy(res => res.CenterId);

        var centers = await centersQueryOrderedWithCount.ToArrayAsync();

        // it selects 1 account - should have 1 company as well
        reportData.CompanyId = centers.First()?.CompanyId ?? -1;
        reportData.AccountId = centers.First()?.AccountId ?? -1;

        foreach (var center in centers)
        {
            WeeklyBalanceRow balanceRow = new WeeklyBalanceRow()
            {
                Center = center.CenterId % 10000,

                CenterName = center.CenterName,
                CenterRegion = center.Region,
                CenterInternalBank = center.InternalBank,

                Balances = WeeklyBalancesCalculation.CalculateBalances(center.CurrentPeriod, center.CtlDayOfWeek, center.Balances, center.WeekActivities)
            };

            RegionFilter.ModifyRegion(balanceRow, center.CompanyId, center.CenterId);

            if (balanceRow.Balances.Total != 0)
            {
                reportData.Rows.Add(balanceRow);
            }
        }

        reportData.TotalCount = reportData.Rows.Count;

        return reportData;
    }
}