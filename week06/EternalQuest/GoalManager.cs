
using System;
using Newtonsoft.Json; 
class GoalManager 
{
  private string _filePath;
  private List<Goal> _goals = [];

  public GoalManager(string path)
  {
    _filePath = path;
  }

  private bool ValidateFile()
  {
    string fileName = _filePath;
    if (string.IsNullOrWhiteSpace(fileName))
    {
        Console.WriteLine("Invalid file name. The file name cannot be empty.");
        return false;
    } 
    if (!File.Exists(fileName))
    {
      Console.WriteLine($"File '{fileName}' does not exist.");
      return false;
    }
    if (Path.GetExtension(fileName) != ".json")
    {
      Console.WriteLine("Invalid file extension. The file must be a JSON file.");
      return false;
    }
    return true;
  }

  public void SaveFile()
  {
    if (ValidateFile()) {
      string json = JsonConvert.SerializeObject(_goals, Formatting.Indented);
      File.WriteAllText(_filePath, json);
      string filename = _filePath.Replace(".json", "");
      Console.WriteLine($"Goals saved successfully to {filename}.");
    }
  }

  public void LoadFile()
  {
    if (ValidateFile()) {
      string json = File.ReadAllText(_filePath);
      _goals = JsonConvert.DeserializeObject<List<Goal>>(json) ?? [];
      string filename = _filePath.Replace(".json", "");
      Console.WriteLine($"Goals loaded successfully from {filename}.");
      foreach (Goal goal in _goals)
      {
          Console.WriteLine($"[ {goal.Marked} ]. {goal.GetName()}");
      }
      // use method to show user points
    }
  }

    
  public static int PromptChoice(List<int> validChoices = null, bool allowEmpty = false)
    {
        int choice = 0;
        bool answerIsInvalid = true;

        while (answerIsInvalid)
        {
            try
            {
                string input = Console.ReadLine();
                if (allowEmpty && string.IsNullOrWhiteSpace(input))
                {
                    return -1;
                }
                choice = int.Parse(input);
                if (validChoices == null || validChoices.Contains(choice))
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

}