using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
class SimpleGoal: Goal
{
    
    public SimpleGoal() 
    {
      _goalType = GoalTypes.SimpleGoal;
    }

    public override Goal CreateSelf()
    {
      Console.Write("What is the name of your goal?: ");
      _name = Console.ReadLine();
      Console.Write("Write a short description of it: ");
      _description = Console.ReadLine();
      _difficultyLevel = Program.SelectEnumOption<DifficultyLevels>("Select how many points you want to get when completed?:");
      return this;
    }

    public override char GetMarker()
    {
        return _isComplete ? 'X' : ' ';
    }

    public override void ListSelf(int index) 
  {
    Console.WriteLine($"{index}. [ {GetMarker()} ]. {GetName()} ({GetDescription()})");
  }

  public override int RecordEvent()
  {
    _isComplete = true;
    int points = GetPoints();
    return points;
  }

  public override object ToJson()
  {
    return new {
      type = _goalType,
      name = _name,
      description = _description,
      difficultyLevel = _difficultyLevel,
      isComplete = _isComplete
    };
  }
  public override void LoadGoal(JObject json)
  {
    _name = json["name"].ToString();
    _description = json["description"].ToString();
    _difficultyLevel = Enum.Parse<DifficultyLevels>(json["difficultyLevel"].ToString());
    _isComplete = bool.Parse(json["isComplete"].ToString());
  }
}