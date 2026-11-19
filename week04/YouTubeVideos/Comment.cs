public class Comment
{
    private readonly string _commenterName;
    private readonly string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public void Display()
    {
        Console.WriteLine($"{_commenterName}: {_text}");
    }
}