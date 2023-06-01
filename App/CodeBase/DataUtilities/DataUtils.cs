using MoneyTracker.Managers;

namespace MoneyTracker.DataObjectsUtilities;

public static class DataUtils
{
    public static (string name, int amount) DuplicateKeyNamer((string name, int amount) entry)
    {
        AppDataManager.appData.DuplicateNum++;
        entry.name += $"{AppDataManager.appData.DuplicateNum}";

        return entry;
    }
}
