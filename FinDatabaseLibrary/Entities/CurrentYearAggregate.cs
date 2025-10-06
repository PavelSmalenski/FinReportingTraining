using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinDatabase.Entities;

public class CurrentYearAggregate
{
    public int CompanyId { get; set; }

    public int AccountId { get; set; }

    public int CenterId { get; set; }

    public char ChargeType { get; set; }

    public decimal Period1AggregateAmount { get; set; }
    public decimal Period2AggregateAmount { get; set; }
    public decimal Period3AggregateAmount { get; set; }
    public decimal Period4AggregateAmount { get; set; }
    public decimal Period5AggregateAmount { get; set; }
    public decimal Period6AggregateAmount { get; set; }
    public decimal Period7AggregateAmount { get; set; }
    public decimal Period8AggregateAmount { get; set; }
    public decimal Period9AggregateAmount { get; set; }
    public decimal Period10AggregateAmount { get; set; }
    public decimal Period11AggregateAmount { get; set; }
    public decimal Period12AggregateAmount { get; set; }
    public decimal Period13AggregateAmount { get; set; }
    public decimal Period14AggregateAmount { get; set; }

    public Center Center { get; set; } = null!;
}