using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal has no entries yet.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        string json = File.ReadAllText(filename);
        List<Entry>? loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);

        // Replace the current journal with the entries from the selected file.
        _entries = loadedEntries ?? new List<Entry>();
    }
}
