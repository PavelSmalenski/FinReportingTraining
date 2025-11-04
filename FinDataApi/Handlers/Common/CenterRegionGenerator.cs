namespace Handlers.Common;

static class CenterRegionGenerator
{
    public static byte GetModifiedRegion(int companyId, int centerId, byte baseRegion)
    {
        if (companyId == 3)
        {
            return 99;
        }

        switch (centerId)
        {
            case 1009:
            case 3589:
                return 29;
            case 0802:
                return 19;
            case 5334:
                return 18;
            case 0926:
            case 8025:
                return 28;
            case 2705:
            case 4355:
            case 2205:
            case 1145:
                return 27;
            case 5172:
                return 06;
            case 0721:
            case 1317:
                return 33;
        }

        return baseRegion;
    }
}