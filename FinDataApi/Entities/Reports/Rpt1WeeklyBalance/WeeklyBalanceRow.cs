namespace Entities.Reports.Rpt1WeeklyBalance;

public record struct WeeklyBalanceRow(
    int    Center,
    string CenterName,
    string CenterInternalBank,
    byte   CenterRegion,

    WeeklyBalances Balances
);