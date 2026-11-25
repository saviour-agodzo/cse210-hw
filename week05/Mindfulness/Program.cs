public class Program
{
    public static void Main()
    {
        // Creativity enhancement: reflection questions and listing prompts are shuffled
        // and are not repeated until every item in that pool has been used once.
        Random random = new Random();
        PromptPool reflectionPrompts = new PromptPool(new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        }, random);

        PromptPool reflectionQuestions = new PromptPool(new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        }, random);

        PromptPool listingPrompts = new PromptPool(new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt peace or inspiration this month?",
            "Who are some of your personal heroes?"
        }, random);

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectionActivity(reflectionPrompts, reflectionQuestions).Run();
                    break;
                case "3":
                    new ListingActivity(listingPrompts).Run();
                    break;
                case "4":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Please choose 1, 2, 3, or 4.");
                    break;
            }
        }

        Console.WriteLine("Thank you for taking time to be mindful.");
    }
}
 