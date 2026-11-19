public class Video
{
    private readonly string _title;
    private readonly string _author;
    private readonly int _lengthSeconds;
    private readonly List<Comment> _comments;

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthSeconds} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");

        foreach (Comment comment in _comments)
        {
            Console.Write("  ");
            comment.Display();
        }
    }
}