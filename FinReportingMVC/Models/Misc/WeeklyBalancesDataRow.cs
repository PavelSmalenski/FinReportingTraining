namespace FinReportingMVC.Models.Misc;

class WeeklyBalanceDataRow
{
    public int Center { get; set; }
    public string CenterName { get; set; }
    public string CenterInternalBank { get; set; }
    public byte CenterRegion { get; set; }

    public decimal BalanceDay1 { get; set; }
    public decimal BalanceDay2 { get; set; }
    public decimal BalanceDay3 { get; set; }
    public decimal BalanceDay4 { get; set; }
    public decimal BalanceDay5 { get; set; }
    public decimal BalanceDay6 { get; set; }
}