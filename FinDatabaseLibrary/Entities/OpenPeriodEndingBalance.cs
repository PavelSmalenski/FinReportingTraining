using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinDatabase.Entities;

public class OpenPeriodEndingBalance
{
    public int CompanyId { get; set; }

    public int AccountId { get; set; }

    public int CenterId { get; set; }

    public char ChargeType { get; set; }

    public decimal PyrPeriod1EndingBalance { get; set; }
    public decimal PyrPeriod2EndingBalance { get; set; }
    public decimal PyrPeriod3EndingBalance { get; set; }
    public decimal PyrPeriod4EndingBalance { get; set; }
    public decimal PyrPeriod5EndingBalance { get; set; }
    public decimal PyrPeriod6EndingBalance { get; set; }
    public decimal PyrPeriod7EndingBalance { get; set; }
    public decimal PyrPeriod8EndingBalance { get; set; }
    public decimal PyrPeriod9EndingBalance { get; set; }
    public decimal PyrPeriod10EndingBalance { get; set; }
    public decimal PyrPeriod11EndingBalance { get; set; }
    public decimal PyrPeriod12EndingBalance { get; set; }
    public decimal PyrPeriod13EndingBalance { get; set; }

    public decimal PyrLifeToDateBalance { get; set; }

    public Center Center { get; set; } = null!;
}