using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void Init()
    {
        Console.WriteLine(GetStartingMessage());
        AskForDuration();
        Console.WriteLine("You will be doing this activity for " + _duration + " seconds.");
    }

    private string GetStartingMessage()
    {
        return "Starting " + _activityName + ":\n " + _description;
    }

    private void AskForDuration()
    {
        Console.WriteLine("\nHow long would you like to do this activity for? (in seconds)");
        _duration = Program.PromptNumber();
    }


  protected static void ShowSpinner(int duration, string message ="")
  {
      char[] spinnerChars = { '|', '/', '-', '\\' };
      int spinnerPosition = message.Length + 1;  
      
      Console.Write(message + " "); 
      
      for (int i = duration; i > 0; i--)
      {
          foreach (char c in spinnerChars)
          {
              int left = Console.CursorLeft;
              int top = Console.CursorTop;
              
              Console.SetCursorPosition(spinnerPosition, top);
              Console.Write($"{i} {c}");
              
              Thread.Sleep(250);
          }
      }
      
      Console.SetCursorPosition(spinnerPosition, Console.CursorTop);
      Console.Write(new string(' ', 6));  
  }

  public void EndActivity()
  {
      Console.WriteLine($"\nCongratulations!, you have completed the {_activityName}.");
      SaveActivityData();
      var data = GetActivitiesData();
      string activityKey = GetActivityKey();
      int timesPlayed = data[activityKey].times_played;
      Console.WriteLine($"You have completed this activity {timesPlayed} times.");
      Console.WriteLine("You can press any key to go back to the menu.");
      Console.ReadLine();
      Console.Clear();
  }
    private void SaveActivityData()
    {
        const string filePath = "user_data.json";
        Dictionary<string, ActivityData> activitiesData;

        string json = File.ReadAllText(filePath);
        activitiesData = JsonSerializer.Deserialize<Dictionary<string, ActivityData>>(json);
        string activityKey = GetActivityKey();
        activitiesData[activityKey].times_played++;

        var options = new JsonSerializerOptions { WriteIndented = true };
        var updatedJson = JsonSerializer.Serialize(activitiesData, options);
        File.WriteAllText(filePath, updatedJson);
    }

    public static Dictionary<string, ActivityData> GetActivitiesData()
    {
        const string filePath = "user_data.json";
        
        if (!File.Exists(filePath))
        {
            return new Dictionary<string, ActivityData>();
        }
        try
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Dictionary<string, ActivityData>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler arquivo: {ex.Message}");
            return new Dictionary<string, ActivityData>();
        }
    }

    public static void InitializeStatsFile()
    {
        string statsFile = "user_data.json";
        var defaultStructure = new Dictionary<string, ActivityData>
        {
            { "Breathing_Activity", new ActivityData { times_played = 0 } },
            { "Reflection_Activity", new ActivityData { times_played = 0 } },
            { "Listing_Activity", new ActivityData { times_played = 0 } }
        };

        if (!File.Exists(statsFile))
        {
          var options = new JsonSerializerOptions { WriteIndented = true };
          string json = JsonSerializer.Serialize(defaultStructure, options);
          File.WriteAllText("user_data.json", json);
        }
    }

    public class ActivityData
    {
        public int times_played { get; set; }
    }

    private string GetActivityKey()
    {
        return _activityName.Replace(" ", "_");
    }
}