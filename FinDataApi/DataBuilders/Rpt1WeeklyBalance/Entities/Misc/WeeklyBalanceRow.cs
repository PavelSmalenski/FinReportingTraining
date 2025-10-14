namespace Reports.Rpt1WeeklyBalance.Entities;

public record struct WeeklyBalanceRow(
    int    Center,
    string CenterName,
    string CenterInternalBank,
    byte   CenterRegion,

    WeeklyBalances Balances
);