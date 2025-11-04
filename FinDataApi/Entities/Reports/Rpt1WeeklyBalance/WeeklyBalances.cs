using System.Text.Json.Serialization;

namespace Entities.Reports.Rpt1WeeklyBalance;
public record struct WeeklyBalances (
    decimal BalanceDay1,
    decimal BalanceDay2,
    decimal BalanceDay3,
    decimal BalanceDay4,
    decimal BalanceDay5,
    decimal BalanceDay6
)
{
    [JsonIgnore]
    public decimal Total {
        get
        {
            return BalanceDay1 + BalanceDay2 + BalanceDay3 + BalanceDay4 + BalanceDay5 + BalanceDay6;
        }
    }
}