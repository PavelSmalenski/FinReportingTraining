using Entities.Reports.Rpt1WeeklyBalance;

namespace Entities.Reports.Rpt1WeeklyBalance.Response;

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