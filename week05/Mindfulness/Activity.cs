using System.Diagnostics;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected int GetDurationSeconds()
    {
        return _durationSeconds;
    }

    protected abstract void PerformActivity();

    private void DisplayStartingMessage()
    {
        Console.WriteLine($"\nWelcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        _durationSeconds = ReadDuration();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    private int ReadDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.WriteLine("Please enter a whole number greater than zero.");
        }
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done! You have done a good job.");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_durationSeconds} seconds.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected static void ShowSpinner(double seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        Stopwatch timer = Stopwatch.StartNew();
        int frame = 0;

        while (timer.Elapsed < TimeSpan.FromSeconds(seconds))
        {
            Console.Write(spinner[frame % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frame++;
        }
    }

    protected static void ShowCountdown(int seconds)
    {
        for (int remaining = seconds; remaining > 0; remaining--)
        {
            Console.Write($"{remaining} ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }
}
