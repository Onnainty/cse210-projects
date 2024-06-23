// by Damian Onnainty

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Entry
{    
    [JsonProperty("prompt")]
    public string Prompt { get; set; }

    [JsonProperty("response")]
    public string Response { get; set; }

    [JsonProperty("date")]
    public string Date { get; set; }
}


public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response, string date)
    {
        entries.Add(new Entry { Prompt = prompt, Response = response, Date = date });
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
            File.WriteAllText(filename, json);
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                entries = JsonConvert.DeserializeObject<List<Entry>>(json);
                Console.WriteLine($"Journal loaded from {filename}");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string filename = "journal.json";

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nJournal");
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    
                    string[] prompts = {
                        "What is something new that I learned today?",
                        "Describe a moment that made me laugh today.",
                        "How did someone's kindness impact my day?",
                        "What is a goal I'm currently working towards, and what progress did I make today?",
                        "Reflect on a decision I made today. What were the factors influencing it?",
                        "Describe a moment today when I felt truly inspired or motivated.",
                        "Reflect on a time today when I felt a deep sense of peace or contentment."
                    };
                    
                    Random rnd = new Random();
                    string randomPrompt = prompts[rnd.Next(prompts.Length)];
                    
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.Write("Your response: ");
                    
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    
                    journal.AddEntry(randomPrompt, response, date);
                    Console.WriteLine("Entry added successfully.\n");
                    break;
                
                case "2":
                    journal.DisplayEntries();
                    break;
                
                case "3":
                    Console.Write("Enter file name to save (e.g., journal.json): ");
                    filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                    break;
                
                case "4":
                    Console.Write("Enter file name to load (e.g., journal.json): ");
                    filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                    break;
                
                case "5":
                    exit = true;
                    break;
                
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.\n");
                    break;
            }
        }
    }
}
