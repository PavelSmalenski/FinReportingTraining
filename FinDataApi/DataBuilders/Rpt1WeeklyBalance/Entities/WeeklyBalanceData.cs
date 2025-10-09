namespace Reports.Rpt1WeeklyBalance.Entities;

public record struct WeeklyBalanceData
{
    public int CompanyId { get; set; }

    public int AccountId { get; set; }

    public int TotalCount { get; set; }

    public List<WeeklyBalanceRow> Rows { get; init; }

    public WeeklyBalanceData()
    {
        Rows = new List<WeeklyBalanceRow>();
    }
}