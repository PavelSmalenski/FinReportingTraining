using Reports.Rpt1WeeklyBalance.Entities;

namespace Reports.Rpt1WeeklyBalance.Processing;

class WeeklyBalancesDatesCalculator
{
    internal static WeeklyBalanceControlDates GetDates(int ctlDayOfWeek, DateTime cbd)
    {
        switch (ctlDayOfWeek)
        {
            case 1:
                return new WeeklyBalanceControlDates(
                    Date1: cbd.AddDays(-7),
                    Date2: cbd.AddDays(-6),
                    Date3: cbd.AddDays(-5),
                    Date4: cbd.AddDays(-4),
                    Date5: cbd.AddDays(-3),
                    Date6: cbd.AddDays(-2),
                    Date7: cbd.AddDays(-1));
            case 2:
                return new WeeklyBalanceControlDates(
                    Date1: cbd.AddDays(-7),
                    Date2: cbd.AddDays(-6),
                    Date3: cbd.AddDays(-5),
                    Date4: cbd.AddDays(-4),
                    Date5: cbd.AddDays(-3),
                    Date7: cbd.AddDays(-2),
                    Date6: cbd.AddDays(-1));
            case 3:
                return new WeeklyBalanceControlDates(
                    Date1: cbd.AddDays(-7),
                    Date2: cbd.AddDays(-6),
                    Date3: cbd.AddDays(-5),
                    Date4: cbd.AddDays(-4),
                    Date7: cbd.AddDays(-3),
                    Date5: cbd.AddDays(-2),
                    Date6: cbd.AddDays(-1));
            case 4:
                return new WeeklyBalanceControlDates(
                    Date1: cbd.AddDays(-7),
                    Date2: cbd.AddDays(-6),
                    Date3: cbd.AddDays(-5),
                    Date7: cbd.AddDays(-4),
                    Date4: cbd.AddDays(-3),
                    Date5: cbd.AddDays(-2),
                    Date6: cbd.AddDays(-1));
            case 5:
                return new WeeklyBalanceControlDates(
                    Date1: cbd.AddDays(-7),
                    Date2: cbd.AddDays(-6),
                    Date7: cbd.AddDays(-5),
                    Date3: cbd.AddDays(-4),
                    Date4: cbd.AddDays(-3),
                    Date5: cbd.AddDays(-2),
                    Date6: cbd.AddDays(-1));
            case 6:
                return new WeeklyBalanceControlDates(
                    Date1: cbd.AddDays(-7),
                    Date7: cbd.AddDays(-6),
                    Date2: cbd.AddDays(-5),
                    Date3: cbd.AddDays(-4),
                    Date4: cbd.AddDays(-3),
                    Date5: cbd.AddDays(-2),
                    Date6: cbd.AddDays(-1));
            default:
                throw new ArgumentException($"Invalid control day of week: {ctlDayOfWeek}");
        }
    }
}