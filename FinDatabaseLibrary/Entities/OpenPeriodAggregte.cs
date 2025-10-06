using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinDatabase.Entities;

public class OpenPeriodAggregte
{
    public int CompanyId { get; set; }

    public int AccountId { get; set; }

    public int CenterId { get; set; }

    public char ChargeType { get; set; }

    public decimal PyrPeriod1Aggregate { get; set; }
    public decimal PyrPeriod2Aggregate { get; set; }
    public decimal PyrPeriod3Aggregate { get; set; }
    public decimal PyrPeriod4Aggregate { get; set; }
    public decimal PyrPeriod5Aggregate { get; set; }
    public decimal PyrPeriod6Aggregate { get; set; }
    public decimal PyrPeriod7Aggregate { get; set; }
    public decimal PyrPeriod8Aggregate { get; set; }
    public decimal PyrPeriod9Aggregate { get; set; }
    public decimal PyrPeriod10Aggregate { get; set; }
    public decimal PyrPeriod11Aggregate { get; set; }
    public decimal PyrPeriod12Aggregate { get; set; }
    public decimal PyrPeriod13Aggregate { get; set; }
    public decimal PyrPeriod14Aggregate { get; set; }

    public Center Center { get; set; } = null!;
}