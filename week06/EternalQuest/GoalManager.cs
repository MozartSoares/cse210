class GoalManager 
{
  private string _filePath;
  private List<Goal> _goals = [];
  private User _user;

  public GoalManager(string path)
  {
    LoadFile(path);
    
  }

  public List<Goal> GetGoals()
  {
    return _goals;
  }

  public void RecordEvent()
  {
    if (_goals.Count == 0)
    {
        Console.WriteLine("No goals to record events for.");
        return;
    }
    Console.WriteLine("Select a goal to record an event for: ");
    var goalsToDo = _goals.Where(goal => !goal.IsCompleted()).ToList();
    int[] availableOptions = new int[goalsToDo.Count];
    for (int i = 0; i < goalsToDo.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {goalsToDo[i].GetName()}");
      availableOptions[i] = i + 1;
    }
    int choice = Program.PromptChoice(availableOptions);
    int XpToAdd = goalsToDo[choice - 1].RecordEvent();
    _user.AddXp(XpToAdd);
    Console.WriteLine($"Event recorded successfully. You've earned {XpToAdd} XP.");
  }

  public void ShowUserStats()
  {
    _user.ShowStats();
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

  // public void SaveFile(string filename = " ")
  // {
  //   if (string.IsNullOrWhiteSpace(filename))
  //   {
  //       filename = _filePath;
  //   }
  //   var jsonData = new
  //   {
  //       User = _user.ToJson(),
  //       Goals = _goals.Select(goal => goal.ToJson()).ToList()
  //   };

  //   string json = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
  //   _filePath = filename.Contains(".json") ? filename : filename + ".json";
  //   File.WriteAllText(_filePath, json);
  //   Console.WriteLine($"User and goals saved successfully to {_filePath}.");
  // }

  public void SaveFile(string filename = "")
    {
        _filePath = string.IsNullOrEmpty(filename) ? _filePath : filename;
        _filePath = Path.ChangeExtension(_filePath, ".txt");
        
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            writer.WriteLine($"User|{_user.Name}|{_user.Level}|{_user.CurrentXp}");
            
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.ToStringRepresentation());
            }
        }
        Console.WriteLine($"User and goals to {_filePath}");
    }

  // public void LoadFile(string filename)
  // {
  //     _filePath = filename.Contains(".json") ? filename : filename + ".json";
  //     if (!File.Exists(_filePath))
  //     {
  //         Console.WriteLine($"File '{_filePath}' not found. Creating a new one...");
  //         CreateNewUser();
  //         SaveFile(_filePath);
  //         return;
  //     }
  //     if (!ValidateFile()) return;
      
  //     string json = File.ReadAllText(_filePath);
  //     var jsonData = JsonConvert.DeserializeObject(json);

  //     if (jsonData == null)
  //     {
  //         Console.WriteLine("Invalid JSON file.");
  //         return;
  //     }
  //     LoadUser(jsonData);
  //     LoadGoals(jsonData);
  //     ListGoals();
  // }
  public void LoadFile(string filename)
    {
        _filePath = Path.ChangeExtension(filename, ".txt");
        
        if (!File.Exists(_filePath))
        {
            CreateNewUser();
            SaveFile(_filePath);
            return;
        }

        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            switch (parts[0])
            {
                case "User":
                    _user = new User(parts[1], int.Parse(parts[2]), int.Parse(parts[3]));
                    break;
                case "SimpleGoal":
                    var simpleGoal = new SimpleGoal();
                    simpleGoal.LoadGoal(parts);
                    _goals.Add(simpleGoal);
                    break;
                case "EternalGoal":
                    var eternalGoal = new EternalGoal();
                    eternalGoal.LoadGoal(parts);
                    _goals.Add(eternalGoal);
                    break;
                case "ChecklistGoal":
                    var checklistGoal = new ChecklistGoal();
                    checklistGoal.LoadGoal(parts);
                    _goals.Add(checklistGoal);
                    break;
            }
        }
        Console.WriteLine($"Data loaded from {_filePath}");
    }


  // private void LoadGoals(dynamic jsonData)
  // {
  //   _goals.Clear();
  //   if (jsonData.Goals == null)
  //   {
  //     Console.WriteLine("No goals found.");
  //     return;
  //   }
  //   foreach (var goal in jsonData.Goals)
  //   { 
  //     string goalTypeString = goal.type.ToString();
  //     if (!int.TryParse(goalTypeString, out int goalTypesInt))
  //     {
  //         Console.WriteLine($"Invalid goal type: {goalTypeString}");
  //         continue;
  //     }
  //     JObject goalJObject = goal.ToObject<JObject>();
  //     switch (goalTypesInt)
  //     {
  //       case (int)GoalTypes.SimpleGoal:
  //         var simpleGoal = new SimpleGoal();
  //         simpleGoal.LoadGoal(goalJObject);
  //         _goals.Add(simpleGoal);
  //         break;
  //       case (int)GoalTypes.EternalGoal:
  //         var eternalGoal = new EternalGoal();
  //         eternalGoal.LoadGoal(goalJObject);
  //         _goals.Add(eternalGoal);
  //         break;
  //       case (int)GoalTypes.ChecklistGoal:
  //         var checklistGoal = new ChecklistGoal();
  //         checklistGoal.LoadGoal(goalJObject);
  //         _goals.Add(checklistGoal);
  //         break;
  //       default:
  //         Console.WriteLine($"Unknown goal type: {goalTypeString}");
  //         continue;
  //     }
  //   }
  //   Console.WriteLine($"Goals loaded successfully from {_filePath}.");
  // }

  // private void LoadUser(dynamic jsonData) {
  //   if (jsonData.User == null)
  //     {
  //       CreateNewUser();
  //     } else {
  //       string name = jsonData.User.name;
  //       int level = jsonData.User.level;
  //       int currentXp = jsonData.User.currentXp;
  //       _user = new User(name, level, currentXp);
  //       Console.WriteLine($"Welcome back !, {_user.Name}. Level: {_user.Level}, XP: {_user.CurrentXp}");
  //     }
  // } 

  private void CreateNewUser() {
    Console.Write("Looks like you're new here !, please enter your username: ");
    string name;
    while (true) {
      name = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(name)) {
        Console.WriteLine("Invalid username. The username cannot be empty.");
        return;
      } else {
        break;
      }
    }
    SetUser(name);
  }
  private void SetUser(string name) {
    _user = new User(name);
  }
  public void CreateNewGoal(GoalTypes goalType) 
  {       
    Goal newGoal;
    switch (goalType)
    {
      case GoalTypes.SimpleGoal:
        newGoal = new SimpleGoal();
        break;
      case GoalTypes.EternalGoal:
        newGoal = new EternalGoal();
        break;
      case GoalTypes.ChecklistGoal:
        newGoal = new ChecklistGoal();
        break;
      default:
        newGoal = new SimpleGoal();
        Console.WriteLine("Invalid goal type.");
        break;
    }
    newGoal.CreateSelf();
    _goals.Add(newGoal);
    Console.WriteLine($"Goal '{newGoal.GetName()}' created successfully.");
  }

  public void ListGoals() {
    if (_goals.Count == 0) {
      Console.WriteLine("No goals found.");
    } else {
      for (int i = 0; i < _goals.Count; i++) {
        var goal = _goals[i];
        goal.ListSelf(i+1);
      }
    }
  }

  public void ShowUserXp() {
    _user.ShowCurrentXp();
  }


}
