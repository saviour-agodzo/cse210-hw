using System.Diagnostics;

public class ReflectionActivity : Activity
{
    private readonly PromptPool _promptPool;
    private readonly PromptPool _questionPool;

    public ReflectionActivity(PromptPool promptPool, PromptPool questionPool)
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _promptPool = promptPool;
        _questionPool = questionPool;
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {_promptPool.GetNext()} ---");
        Console.WriteLine("When you have something in mind, reflect on each question that follows.");
        ShowSpinner(3);
        Console.WriteLine();

        Stopwatch timer = Stopwatch.StartNew();
        while (timer.Elapsed.TotalSeconds < GetDurationSeconds())
        {
            Console.WriteLine();
            Console.WriteLine($"> {_questionPool.GetNext()}");
            double pauseSeconds = Math.Min(5.0, GetDurationSeconds() - timer.Elapsed.TotalSeconds);
            if (pauseSeconds > 0)
            {
                ShowSpinner(pauseSeconds);
            }
        }
    }
}
