using Entities.Reports.Rpt1WeeklyBalance;

namespace Entities.Reports.Rpt1WeeklyBalance.Response;

public record struct WeeklyBalanceHeaderData(
    string Ibt,
    string IbtName,
    int AccountId,
    string AccountDescription,
    WeeklyBalanceControlDates EntryDates
);