using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinDatabase.Entities;

public class CurrentYearEndingBalance
{
    public int CompanyId { get; set; }

    public int AccountId { get; set; }

    public int CenterId { get; set; }

    public char ChargeType { get; set; }

    public decimal Period1EndingBalance { get; set; }
    public decimal Period2EndingBalance { get; set; }
    public decimal Period3EndingBalance { get; set; }
    public decimal Period4EndingBalance { get; set; }
    public decimal Period5EndingBalance { get; set; }
    public decimal Period6EndingBalance { get; set; }
    public decimal Period7EndingBalance { get; set; }
    public decimal Period8EndingBalance { get; set; }
    public decimal Period9EndingBalance { get; set; }
    public decimal Period10EndingBalance { get; set; }
    public decimal Period11EndingBalance { get; set; }
    public decimal Period12EndingBalance { get; set; }
    public decimal Period13EndingBalance { get; set; }

    public decimal CurrentYearLtdBalance { get; set; }

    public string CenterProcessingCycleNumber { get; set; } = null!;

    public Center Center { get; set; } = null!;
}