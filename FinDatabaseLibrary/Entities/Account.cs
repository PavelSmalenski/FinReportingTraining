using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinDatabase.Entities;

public class Account
{
    public int CompanyId { get; set; }

    [Column("AccountId")]
    public int Id { get; set; }

    public char ChargeType { get; set; }

    [MaxLength(25)]
    public string Description { get; set; } = null!;

    [MaxLength(18)]
    public string ControlAccountId { get; set; } = null!;

    public char AccountType { get; set; }

    public byte ClassCode { get; set; }

    public byte GroupCode { get; set; }

    public byte NormalSignCode { get; set; }

    public char AccountRequiredEntryIndex { get; set; }

    public decimal AccountBalanceUpperLimit { get; set; }

    public decimal AccountBalanceLowerLimit { get; set; }

    public decimal AccountEntryUpperLimit { get; set; }

    public decimal AccountEntryLowerLimit { get; set; }

    public decimal AccountPercentChangeLimit { get; set; }

    public decimal AccountAuthorizedCashAmt { get; set; }

    public char AccountOverAndShortIndex { get; set; }

    public char AccountReconcilementIndex { get; set; }

    public char ProjectionMethodOverride { get; set; }

    public char? AmountTaxEquivalentCd { get; set; }

    public Company Company { get; set; } = null!;

    public List<Center> Centers { get; set; } = null!;
}