public class Program
{
    public static void Main()
    {
        Video video1 = new Video("A Day in the Mountains", "Jordan Lee", 485);
        video1.AddComment(new Comment("Mia", "The scenery is beautiful."));
        video1.AddComment(new Comment("Ethan", "I want to visit this trail."));
        video1.AddComment(new Comment("Ava", "The camera shots are amazing."));

        Video video2 = new Video("Easy Weeknight Pasta", "Sam Rivera", 362);
        video2.AddComment(new Comment("Noah", "I made this for dinner and loved it."));
        video2.AddComment(new Comment("Chloe", "The sauce was so simple."));
        video2.AddComment(new Comment("Liam", "Please share more recipes."));

        Video video3 = new Video("Building a Small Garden", "Taylor Chen", 714);
        video3.AddComment(new Comment("Isabella", "This gave me ideas for my balcony."));
        video3.AddComment(new Comment("Lucas", "Which soil did you use?"));
        video3.AddComment(new Comment("Amelia", "The finished garden looks great."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}