using System.Diagnostics;

public class ListingActivity : Activity
{
    private readonly PromptPool _promptPool;

    public ListingActivity(PromptPool promptPool)
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _promptPool = promptPool;
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_promptPool.GetNext()} ---");
        Console.WriteLine("You may begin in:");
        int thinkingSeconds = Math.Min(5, GetDurationSeconds());
        ShowCountdown(thinkingSeconds);
        Console.WriteLine($"You have {GetDurationSeconds()} seconds. Start listing and press Enter after each item.");

        Stopwatch timer = Stopwatch.StartNew();
        int itemCount = 0;
        string currentItem = "";

        while (timer.Elapsed.TotalSeconds < GetDurationSeconds())
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (!string.IsNullOrWhiteSpace(currentItem))
                    {
                        itemCount++;
                        currentItem = "";
                        Console.WriteLine();
                    }
                }
                else if (key.Key == ConsoleKey.Backspace && currentItem.Length > 0)
                {
                    currentItem = currentItem[..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    currentItem += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            else
            {
                Thread.Sleep(50);
            }
        }

        if (!string.IsNullOrWhiteSpace(currentItem))
        {
            itemCount++;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items.");
    }
}
