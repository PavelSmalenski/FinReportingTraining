namespace Reports.Rpt1WeeklyBalance.Entities;

public record struct WeeklyBalances (
    decimal BalanceDay1,
    decimal BalanceDay2,
    decimal BalanceDay3,
    decimal BalanceDay4,
    decimal BalanceDay5,
    decimal BalanceDay6
);