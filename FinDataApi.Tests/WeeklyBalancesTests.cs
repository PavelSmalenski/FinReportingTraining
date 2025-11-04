using Moq;
using Reports.Rpt1WeeklyBalance.Entities;

namespace FinDataApi.Tests;

public class WeeklyBalancesTests
{
    [Fact]
    public void Totals_ReturnsSumm()
    {
        WeeklyBalances weeklyBalances = new WeeklyBalances(1, 2, 3, 4, 5, 6);

        Assert.True(weeklyBalances.Total == 21);
    }
}
