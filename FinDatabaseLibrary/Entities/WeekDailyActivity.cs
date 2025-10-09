using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinDatabase.Entities;

public class WeekDailyActivity
{
    public int CompanyId { get; set; }

    public int AccountId { get; set; }

    public int CenterId { get; set; }

    public char ChargeType { get; set; }

    public string WeekDailyActivityIndex { get; set; } = null!;

    public decimal Day1DebitActiveAmount { get; set; }

    public decimal Day1CreditActiveAmount { get; set; }

    public decimal Day2DebitActiveAmount { get; set; }

    public decimal Day2CreditActiveAmount { get; set; }

    public decimal Day3DebitActiveAmount { get; set; }

    public decimal Day3CreditActiveAmount { get; set; }

    public decimal Day4DebitActiveAmount { get; set; }

    public decimal Day4CreditActiveAmount { get; set; }

    public decimal Day5DebitActiveAmount { get; set; }

    public decimal Day5CreditActiveAmount { get; set; }

    public decimal Day6DebitActiveAmount { get; set; }

    public decimal Day6CreditActiveAmount { get; set; }

    public decimal Day7DebitActiveAmount { get; set; }

    public decimal Day7CreditActiveAmount { get; set; }

    public byte WeekId { get; set; }

    public Center Center { get; set; } = null!;
}