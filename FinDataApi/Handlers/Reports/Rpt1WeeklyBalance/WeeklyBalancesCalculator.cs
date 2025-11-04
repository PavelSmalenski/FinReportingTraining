using FinDatabase.Entities;
using Entities.Common;
using Entities.Reports.Rpt1WeeklyBalance;

namespace Handlers.Reports.Rpt1WeeklyBalance;

public class WeeklyBalancesCalculator
{
    
    public static WeeklyBalances CalculateBalances(int currentPeriod, int ctlDayOfWeek, CurrentYearEndingBalance currentYearEndingBalance, WeekDailyActivity weekDailyActivity)
    {
        if (ctlDayOfWeek < 1 || ctlDayOfWeek > 7)
        {
            throw new ArgumentException($"Invalid control day of week: {ctlDayOfWeek}");
        }

        decimal periodEndingBalance = 0M;
        var retroBalances = new decimal[7];

        switch (currentPeriod)
        {
            case 1:
                periodEndingBalance = currentYearEndingBalance.Period1EndingBalance * -1;
                break;
            case 2:
                periodEndingBalance = currentYearEndingBalance.Period2EndingBalance * -1; ;
                break;
            case 3:
                periodEndingBalance = currentYearEndingBalance.Period3EndingBalance * -1; ;
                break;
            case 4:
                periodEndingBalance = currentYearEndingBalance.Period4EndingBalance * -1; ;
                break;
            case 5:
                periodEndingBalance = currentYearEndingBalance.Period5EndingBalance * -1; ;
                break;
            case 6:
                periodEndingBalance = currentYearEndingBalance.Period6EndingBalance * -1; ;
                break;
            case 7:
                periodEndingBalance = currentYearEndingBalance.Period7EndingBalance * -1; ;
                break;
            case 8:
                periodEndingBalance = currentYearEndingBalance.Period8EndingBalance * -1; ;
                break;
            case 9:
                periodEndingBalance = currentYearEndingBalance.Period9EndingBalance * -1; ;
                break;
            case 10:
                periodEndingBalance = currentYearEndingBalance.Period10EndingBalance * -1; ;
                break;
            case 11:
                periodEndingBalance = currentYearEndingBalance.Period11EndingBalance * -1; ;
                break;
            case 12:
                periodEndingBalance = currentYearEndingBalance.Period12EndingBalance * -1; ;
                break;
            case 13:
                periodEndingBalance = currentYearEndingBalance.Period13EndingBalance * -1; ;
                break;
        }

        retroBalances[0] = periodEndingBalance + weekDailyActivity.Day1DebitActiveAmount + weekDailyActivity.Day1CreditActiveAmount;
        retroBalances[1] = retroBalances[0] + weekDailyActivity.Day2DebitActiveAmount + weekDailyActivity.Day2CreditActiveAmount;
        retroBalances[2] = retroBalances[1] + weekDailyActivity.Day3DebitActiveAmount + weekDailyActivity.Day3CreditActiveAmount;
        retroBalances[3] = retroBalances[2] + weekDailyActivity.Day4DebitActiveAmount + weekDailyActivity.Day4CreditActiveAmount;
        retroBalances[4] = retroBalances[3] + weekDailyActivity.Day5DebitActiveAmount + weekDailyActivity.Day5CreditActiveAmount;
        retroBalances[5] = retroBalances[4] + weekDailyActivity.Day6DebitActiveAmount + weekDailyActivity.Day6CreditActiveAmount;
        retroBalances[6] = retroBalances[5] + weekDailyActivity.Day7DebitActiveAmount + weekDailyActivity.Day7CreditActiveAmount;

        var balances = new decimal[7];

        if (ctlDayOfWeek >= 2 && ctlDayOfWeek <= 6)
        {
            balances[0] = retroBalances[ctlDayOfWeek - 1];

            for (int i = 0; i < ctlDayOfWeek - 1; i++)
            {
                balances[i + 1] = retroBalances[i];
            }

            for (int i = ctlDayOfWeek; i < 7; i++)
            {
                balances[i] = retroBalances[i];
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                balances[i - 1] = retroBalances[i];
            }
        }

        return new WeeklyBalances()
        {
            BalanceDay1 = balances[0],
            BalanceDay2 = balances[1],
            BalanceDay3 = balances[2],
            BalanceDay4 = balances[3],
            BalanceDay5 = balances[4],
            BalanceDay6 = balances[5]
        };
    }
}