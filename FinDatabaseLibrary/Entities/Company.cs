using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinDatabase.Entities;

public class Company
{
    [Column("CompanyId")]
    public int Id { get; set; }

    public char SequentialProcessOption { get; set; }

    public char AggregatesOption { get; set; }

    public byte DaysLateAlert { get; set; }

    public DateTime PostingDate { get; set; }

    public ushort CurrentFiscalYear { get; set; }

    public byte ActiveSegmentsAllowed { get; set; }

    public byte PeriodsOpen { get; set; }

    public byte CurrentPeriod { get; set; }

    public byte PeriodsAllowedOpen { get; set; }

    public char PriorYearOpenIndicator { get; set; }

    public byte YearsOfHistory { get; set; }

    [MaxLength(18)]
    public string ClosingAccountId { get; set; } = null!;

    [MaxLength(12)]
    public string ClosingCenterId { get; set; } = null!;

    public bool OnlineUpdateIndicator { get; set; }

    public bool OnlineAlertMessageIndicator { get; set; }

    public bool OnlineSummarizeIndicator { get; set; }

    public ushort CycleNumber { get; set; }

    public DateTime OnlinePostingDate { get; set; }

    public List<Account> Accounts { get; set; } = null!;
}