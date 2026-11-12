public class Scripture
{
    private readonly ScriptureReference _reference;
    private readonly List<Word> _words;
    private readonly Random _random;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => new Word(word))
            .ToList();
        _random = new Random();
    }

    public bool IsCompletelyHidden => _words.All(word => word.IsHidden);

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int selectedIndex = _random.Next(visibleWords.Count);
            visibleWords[selectedIndex].Hide();
            visibleWords.RemoveAt(selectedIndex);
        }
    }

    public string GetDisplayText()
    {
        string displayedWords = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference}\n{displayedWords}";
    }
}