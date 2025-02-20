
class EternalGoal : Goal
{
  private int _timesCompleted = 0;

  public EternalGoal()
  {
    _goalType = GoalTypes.EternalGoal;
  }

    public override Goal CreateSelf()
    {
      Console.Write("What is the name of your goal?: ");
      _name = Console.ReadLine();
      Console.Write("Write a short description of it: ");
      _description = Console.ReadLine();
      Console.WriteLine("The difficulty levels are: ");
      _difficultyLevel = Program.SelectEnumOption<DifficultyLevels>("Choose a difficulty level:");
      return this;
    }

  public override void ListSelf(int index) 
  {
    Console.WriteLine($"{index}. Eternal: completed -> [ {_timesCompleted} times ]. {GetName()}");
  }

  public override char GetMarker()
  {
    return _timesCompleted.ToString()[0];
  }

  public override int RecordEvent()
  {
    _timesCompleted++;
    return GetPoints();
  }

  // public override object ToJson()
  // {
  //   return new {
  //     type = _goalType,
  //     name = _name,
  //     description = _description,
  //     difficultyLevel = _difficultyLevel,
  //     isComplete = _isComplete,
  //     timesCompleted = _timesCompleted
  //   };
  // }

  //   public override void LoadGoal(JObject json)
  // {
  //   _name = json["name"].ToString();
  //   _description = json["description"].ToString();
  //   _difficultyLevel = Enum.Parse<DifficultyLevels>(json["difficultyLevel"].ToString());
  //   _isComplete = bool.Parse(json["isComplete"].ToString());
  //   _timesCompleted = int.Parse(json["timesCompleted"].ToString());
  // }

    public override string ToStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_description}|{(int)_difficultyLevel}|{_isComplete}|{_timesCompleted}";
    }

    public override void LoadGoal(string[] data)
    {
        _name = data[1];
        _description = data[2];
        _difficultyLevel = (DifficultyLevels)int.Parse(data[3]);
        _isComplete = bool.Parse(data[4]);
        _timesCompleted = int.Parse(data[5]);
    }



}