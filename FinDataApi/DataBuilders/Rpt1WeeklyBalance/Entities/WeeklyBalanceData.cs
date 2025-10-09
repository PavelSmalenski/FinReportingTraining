namespace Reports.Rpt1WeeklyBalance.Entities;

public record struct WeeklyBalanceData(
    int CompanyId,
    int AccountId,
    int TotalCount,
    List<WeeklyBalanceRow> Rows
);