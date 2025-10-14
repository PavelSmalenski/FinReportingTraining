using Reports.Rpt1WeeklyBalance.Entities;

namespace Reports.Rpt1WeeklyBalance.Processing;

static class RegionFilter
{
    public static void ModifyRegion(WeeklyBalanceRow weeklyBalanceRow, int companyId, int centerId)
    {
        if (companyId == 3)
        {
            weeklyBalanceRow.CenterRegion = 99;
            return;
        }

        switch (centerId)
        {
            case 1009:
            case 3589:
                weeklyBalanceRow.CenterRegion = 29;
                break;
            case 0802:
                weeklyBalanceRow.CenterRegion = 19;
                break;
            case 5334:
                weeklyBalanceRow.CenterRegion = 18;
                break;
            case 0926:
            case 8025:
                weeklyBalanceRow.CenterRegion = 28;
                break;
            case 2705:
            case 4355:
            case 2205:
            case 1145:
                weeklyBalanceRow.CenterRegion = 27;
                break;
            case 5172:
                weeklyBalanceRow.CenterRegion = 06;
                break;
            case 0721:
            case 1317:
                weeklyBalanceRow.CenterRegion = 33;
                break;
        }

        return;
    }
}