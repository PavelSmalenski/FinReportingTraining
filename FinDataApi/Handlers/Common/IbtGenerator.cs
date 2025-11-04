using Entities.Common;

namespace Handlers.Common;

static class IbtGenerator
{
    public static Ibt GetIbt(int accountId)
    {

        if (accountId == 817930012 || accountId == 830480013 || accountId == 850410002)
        {
            return new Ibt("4219", "Help desk");
        }
        else
        {
            return new Ibt("6294", "Accounting desk");
        }
    }
}