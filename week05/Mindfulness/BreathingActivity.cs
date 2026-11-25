using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Stopwatch timer = Stopwatch.StartNew();
        string[] phases = { "Breathe in...", "Breathe out..." };
        int phase = 0;

        while (timer.Elapsed.TotalSeconds < GetDurationSeconds())
        {
            double secondsLeft = GetDurationSeconds() - timer.Elapsed.TotalSeconds;
            int phaseSeconds = Math.Min(4, (int)Math.Ceiling(secondsLeft));

            Console.WriteLine(phases[phase]);
            for (int count = phaseSeconds; count > 0; count--)
            {
                if (timer.Elapsed.TotalSeconds >= GetDurationSeconds())
                {
                    break;
                }

                Console.Write($"{count} ");
                Thread.Sleep(1000);
            }

            Console.WriteLine();
            phase = 1 - phase;
        }
    }
}
