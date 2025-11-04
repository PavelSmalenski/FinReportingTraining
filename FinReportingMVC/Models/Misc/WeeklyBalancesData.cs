namespace FinReportingMVC.Models.Misc;

class WeeklyBalanceData
{
    public int CompanyId { get; set; }

    public int AccountId { get; set; }

    public int TotalCount { get; set; }

    public List<WeeklyBalanceDataRow> Rows { get; init; }
}