using Moq;
using Entities.Reports.Rpt1WeeklyBalance;
using FinDatabase.Entities;
using Handlers.Reports.Rpt1WeeklyBalance;

namespace FinDataApi.Tests;

public class WeeklyBalancesTests1
{
    [Fact]
    public void CalculateBalances_Balances_ReturnSummsObject()
    {
        var stubYearEndingBalance = new CurrentYearEndingBalance()
        {
            Period1EndingBalance = 1,
            Period2EndingBalance = 2,
            Period3EndingBalance = 3,
            Period4EndingBalance = 4,
            Period5EndingBalance = 5,
            Period6EndingBalance = 6,
            Period7EndingBalance = 7,
            Period8EndingBalance = 8,
            Period9EndingBalance = 9,
            Period10EndingBalance = 10,
            Period11EndingBalance = 11,
            Period12EndingBalance = 12,
            Period13EndingBalance = 13
        };

        var stubDailyActivity = new WeekDailyActivity()
        {
            Day1DebitActiveAmount = 100,
            Day2DebitActiveAmount = 200,
            Day3DebitActiveAmount = 300,
            Day4DebitActiveAmount = 400,
            Day5DebitActiveAmount = 500,
            Day6DebitActiveAmount = 600,
            Day7DebitActiveAmount = 700,
            Day1CreditActiveAmount = 100,
            Day2CreditActiveAmount = 200,
            Day3CreditActiveAmount = 300,
            Day4CreditActiveAmount = 400,
            Day5CreditActiveAmount = 500,
            Day6CreditActiveAmount = 600,
            Day7CreditActiveAmount = 700
        };

        int currentPeriod = 1;
        int ctlDayOfWeek = 4;

        var expectedBalances = new WeeklyBalances()
        {
            BalanceDay1 = stubDailyActivity.Day4DebitActiveAmount + stubDailyActivity.Day4CreditActiveAmount + stubDailyActivity.Day3DebitActiveAmount + stubDailyActivity.Day3CreditActiveAmount + stubDailyActivity.Day2DebitActiveAmount + stubDailyActivity.Day2CreditActiveAmount + stubDailyActivity.Day1DebitActiveAmount + stubDailyActivity.Day1CreditActiveAmount + stubYearEndingBalance.Period1EndingBalance * -1,
            BalanceDay2 = stubDailyActivity.Day1DebitActiveAmount + stubDailyActivity.Day1CreditActiveAmount + stubYearEndingBalance.Period1EndingBalance * -1,
            BalanceDay3 = stubDailyActivity.Day2DebitActiveAmount + stubDailyActivity.Day2CreditActiveAmount + stubDailyActivity.Day1DebitActiveAmount + stubDailyActivity.Day1CreditActiveAmount + stubYearEndingBalance.Period1EndingBalance * -1,
            BalanceDay4 = stubDailyActivity.Day3DebitActiveAmount + stubDailyActivity.Day3CreditActiveAmount + stubDailyActivity.Day2DebitActiveAmount + stubDailyActivity.Day2CreditActiveAmount + stubDailyActivity.Day1DebitActiveAmount + stubDailyActivity.Day1CreditActiveAmount + stubYearEndingBalance.Period1EndingBalance * -1,
            BalanceDay5 = stubDailyActivity.Day5DebitActiveAmount + stubDailyActivity.Day5CreditActiveAmount + stubDailyActivity.Day4DebitActiveAmount + stubDailyActivity.Day4CreditActiveAmount + stubDailyActivity.Day3DebitActiveAmount + stubDailyActivity.Day3CreditActiveAmount + stubDailyActivity.Day2DebitActiveAmount + stubDailyActivity.Day2CreditActiveAmount + stubDailyActivity.Day1DebitActiveAmount + stubDailyActivity.Day1CreditActiveAmount + stubYearEndingBalance.Period1EndingBalance * -1,
            BalanceDay6 = stubDailyActivity.Day6DebitActiveAmount + stubDailyActivity.Day6CreditActiveAmount + stubDailyActivity.Day5DebitActiveAmount + stubDailyActivity.Day5CreditActiveAmount + stubDailyActivity.Day4DebitActiveAmount + stubDailyActivity.Day4CreditActiveAmount + stubDailyActivity.Day3DebitActiveAmount + stubDailyActivity.Day3CreditActiveAmount + stubDailyActivity.Day2DebitActiveAmount + stubDailyActivity.Day2CreditActiveAmount + stubDailyActivity.Day1DebitActiveAmount + stubDailyActivity.Day1CreditActiveAmount + stubYearEndingBalance.Period1EndingBalance * -1
        };

        var resultingBalances = WeeklyBalancesCalculator.CalculateBalances(currentPeriod, ctlDayOfWeek, stubYearEndingBalance, stubDailyActivity);

        // TODO: add equality to WeeklyBalances
        Assert.True(
            expectedBalances.BalanceDay1 == resultingBalances.BalanceDay1 &&
            expectedBalances.BalanceDay2 == resultingBalances.BalanceDay2 &&
            expectedBalances.BalanceDay3 == resultingBalances.BalanceDay3 &&
            expectedBalances.BalanceDay4 == resultingBalances.BalanceDay4 &&
            expectedBalances.BalanceDay5 == resultingBalances.BalanceDay5 &&
            expectedBalances.BalanceDay6 == resultingBalances.BalanceDay6);
    }
}
