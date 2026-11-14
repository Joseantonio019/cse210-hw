using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood; // Extra feature: tracks user's mood

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} | Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    // Formats the entry as a valid CSV line, escaping quotes and wrapping fields in quotes
    public string ToCsvLine()
    {
        return $"{EscapeCsv(_date)},{EscapeCsv(_mood)},{EscapeCsv(_promptText)},{EscapeCsv(_entryText)}";
    }

    private string EscapeCsv(string field)
    {
        if (string.IsNullOrEmpty(field))
        {
            return "\"\"";
        }
        string escaped = field.Replace("\"", "\"\"");
        return $"\"{escaped}\"";
    }
}