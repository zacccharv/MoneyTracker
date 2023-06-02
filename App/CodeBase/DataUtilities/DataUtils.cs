namespace MoneyTracker.DataObjectsUtilities;

public static class DataUtils
{
    public static (string name, int amount) DuplicateKeyChecker((string name, int amount) entry, SortedList<string, int> Entries)
    {
        if (Entries.ContainsKey(entry.name))
        {
            int count = 0;

            foreach (var item in Entries)
            {
                if (item.Key == entry.name)
                {
                    count++;
                }
            }
            entry.name += $"{count}";
            return entry;
        }

        return entry;
    }
}
