using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    // Creativity beyond the core requirements: the journal is saved as formatted JSON,
    // which preserves punctuation and can be extended with additional entry fields.
    private static readonly List<string> _prompts = new List<string>
    {
        "What small moment made you smile today?",
        "Who helped you or made your day better?",
        "What is one thing you learned today?",
        "What did you do today that took courage?",
        "What is something you are grateful for right now?",
        "What would you like to remember about today?"
    };

    private static readonly Random _random = new Random();

    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please enter a number from 1 to 5.\n");
                    break;
            }
        }
    }

    private static void WriteEntry(Journal journal)
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine() ?? "";
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        journal.AddEntry(new Entry(date, prompt, response));
        Console.WriteLine("Entry added.\n");
    }

    private static void SaveJournal(Journal journal)
    {
        Console.Write("Enter a filename to save to (for example, journal.json): ");
        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.\n");
            return;
        }

        try
        {
            journal.SaveToFile(filename);
            Console.WriteLine($"Journal saved to {Path.GetFullPath(filename)}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not save the journal: {ex.Message}\n");
        }
    }

    private static void LoadJournal(Journal journal)
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.\n");
            return;
        }

        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine("Journal loaded. The entries currently in memory were replaced.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load the journal: {ex.Message}\n");
        }
    }
}
