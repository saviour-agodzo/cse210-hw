using System;

public class Program
{
    public static void Main()
    {
        // Creativity: choose a scripture at random from a small built-in library,
        // so each practice session can use a different passage.
        List<Scripture> library = new()
        {
            new Scripture(
                new ScriptureReference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son " +
                "that whosoever believeth in him should not perish but have everlasting life"),
            new Scripture(
                new ScriptureReference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own " +
                "understanding In all thy ways acknowledge him and he shall direct thy paths")
        };

        Scripture scripture = library[new Random().Next(library.Count)];

        while (!scripture.IsCompletelyHidden)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            string? response = Console.ReadLine();
            if (string.Equals(response?.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}