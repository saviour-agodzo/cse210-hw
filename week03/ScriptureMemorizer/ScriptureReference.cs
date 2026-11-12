public class ScriptureReference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int? _endVerse;

    public ScriptureReference(string book, int chapter, int verse)
        : this(book, chapter, verse, null)
    {
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        : this(book, chapter, startVerse, (int?)endVerse)
    {
    }

    private ScriptureReference(string book, int chapter, int startVerse, int? endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        string verses = _endVerse.HasValue
            ? $"{_startVerse}-{_endVerse.Value}"
            : _startVerse.ToString();
        return $"{_book} {_chapter}:{verses}";
    }
}