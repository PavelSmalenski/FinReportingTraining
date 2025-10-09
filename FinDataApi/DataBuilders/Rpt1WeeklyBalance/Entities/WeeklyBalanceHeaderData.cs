namespace Reports.Rpt1WeeklyBalance.Entities;

public record struct WeeklyBalanceHeaderData(
    string Ibt,
    string IbtName,
    int AccountId,
    string AccountDescription,
    WeeklyBalanceControlDates EntryDates
);