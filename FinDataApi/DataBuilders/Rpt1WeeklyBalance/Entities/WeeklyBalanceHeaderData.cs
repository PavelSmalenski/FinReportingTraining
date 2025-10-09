namespace Reports.Rpt1WeeklyBalance.Entities;

public record struct WeeklyBalanceHeaderData(
    string Ibt,
    string IbtName,
    string AccountId,
    string AccountDescription,
    WeeklyBalanceControlDates EntryDates
);