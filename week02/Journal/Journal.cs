using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Text.Json.Serialization;
using Newtonsoft.Json; 

enum FileAction 
{
  Save,
  Load
  
}
class Journal {
  private readonly List<string> _questions =["Who was the most interesting person I interacted with today?","What was the best part of my day?","How did I see the hand of the Lord in my life today?","What was the strongest emotion I felt today?","If I had one thing I could do over today, what would it be?","What is one thing I learned today that I didn’t know before?","How did I make someone’s day better today?","What challenge did I face today, and how did I overcome it (or how could I handle it better)?","What am I most grateful for today, and why?","If I could freeze one moment from today to relive forever, what would it be?"];
  private List<Entry> _entries = [];
    public static int PromptChoice()
    {
      int choice = 0;
        List<int> validChoices = [ 1, 2, 3, 4, 5 ];
        bool answerIsInvalid = true;

        while (answerIsInvalid)
        {
            try
            {
            choice = int.Parse(Console.ReadLine());
            if (validChoices.Contains(choice))
            {
                answerIsInvalid = false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
            }
            }
            catch (FormatException)
            {
            Console.WriteLine("Invalid input. Please enter a valid choice.");
            }
        }
        return choice;
    }
    public void Write()
    {
      Random random = new();
      int index = random.Next(this._questions.Count);
      string selectedQuestion = this._questions[index];
      Console.WriteLine(selectedQuestion);

      string response = Console.ReadLine();
      DateTime theCurrentTime = DateTime.Now;
      string dateText = theCurrentTime.ToShortDateString();
      Entry newEntry = new()
      {
        _question = selectedQuestion,
        _response = response,
        _date = dateText
      };
      _entries.Add(newEntry);
    }
    public void Display()
    {
      foreach (Entry entry in _entries)
      {
        Console.WriteLine($"{entry._date}, {entry._question}, {entry._response}");
      }
    }
    public void ManageFile(FileAction option)
    {
      string action = option == FileAction.Save ? "save" : "load";
      Console.WriteLine($"Please enter the file name to {action} the journal: ");
      string fileName = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(fileName))
      {
          Console.WriteLine("Invalid file name. The file name cannot be empty.");
          return;
      } 
      try
      {
        void save(string file)
        {
            string json = JsonConvert.SerializeObject(_entries, Formatting.Indented);
            File.WriteAllText(file, json);
            Console.WriteLine($"Journal saved successfully to {file}.");
        }
        void load(string file)
        {
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                _entries = JsonConvert.DeserializeObject<List<Entry>>(json) ?? new List<Entry>();
                Console.WriteLine($"Journal loaded successfully from {file}.");
            }
            else
            {
                Console.WriteLine($"File '{file}' does not exist.");
            }
        }
        if (option == FileAction.Save)
        {
            save(fileName);
        }
        else
        {
            load(fileName);
        }
      }
      catch (Exception ex)
      {
          Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
      }
    }
}