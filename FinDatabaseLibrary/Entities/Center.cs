using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinDatabase.Entities;

public class Center
{
    public int CompanyId { get; set; }

    public int AccountId { get; set; }

    [Column("CenterId")]
    public int Id { get; set; }

    public char ChargeType { get; set; }

    public char CenterStatusCode { get; set; }

    public DateTime ActivateDate { get; set; }

    public DateTime InactivateDate { get; set; }

    public char RequiredEntryIndex { get; set; }

    public decimal CenterBalanceUpperLimit { get; set; }

    public decimal CenterBalanceLowerLimit { get; set; }

    public decimal CenterEntryUpperLimit { get; set; }

    public decimal CenterEntryLowerLimit { get; set; }

    public decimal CenterPercentChangeLimit { get; set; }

    public decimal CenterAuthorizedCashAmount { get; set; }

    public byte NumberOfDaysOver { get; set; }

    public byte NumberOfDaysUnder { get; set; }

    public char CenterOverAndShortIndex { get; set; }

    public char CenterReconcilementIndex { get; set; }

    [MaxLength(12)]
    public string InterLvl1RptCenterId { get; set; } = null!;

    [MaxLength(12)]
    public string InterLvl2RptCenterId { get; set; } = null!;

    [MaxLength(12)]
    public string InterLvl3RptCenterId { get; set; } = null!;

    public DateTime LastActivityDate { get; set; }

    public decimal PriorPostEndingBalance { get; set; }

    public decimal PriorYearEndingBalance { get; set; }

    public Account Account { get; set; } = null!;

    public List<CurrentYearEndingBalance> CurrentYearEndingBalances { get; set; } = null!;
    public List<CurrentYearAggregate> CurrentYearAggregates { get; set; } = null!;
    public List<WeekDailyActivity> WeekDailyActivities { get; set; } = null!;
    public List<OpenPeriodEndingBalance> OpenPeriodEndingBalances { get; set; } = null!;
    public List<OpenPeriodAggregte> OpenPeriodAggregtes { get; set; } = null!;
}