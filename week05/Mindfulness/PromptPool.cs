public class PromptPool
{
    private readonly List<string> _allItems;
    private readonly List<string> _unusedItems;
    private readonly Random _random;

    public PromptPool(IEnumerable<string> items, Random random)
    {
        _allItems = items.ToList();
        _unusedItems = new List<string>();
        _random = random;
        RefillAndShuffle();
    }

    public string GetNext()
    {
        if (_unusedItems.Count == 0)
        {
            RefillAndShuffle();
        }

        int index = _random.Next(_unusedItems.Count);
        string item = _unusedItems[index];
        _unusedItems.RemoveAt(index);
        return item;
    }

    private void RefillAndShuffle()
    {
        _unusedItems.Clear();
        _unusedItems.AddRange(_allItems);

        for (int i = _unusedItems.Count - 1; i > 0; i--)
        {
            int swapIndex = _random.Next(i + 1);
            (_unusedItems[i], _unusedItems[swapIndex]) = (_unusedItems[swapIndex], _unusedItems[i]);
        }
    }
}
