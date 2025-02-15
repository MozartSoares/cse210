using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
class ChecklistGoal : Goal
{
  private int _timesRequiredForBonus;
  private BonusOptions _bonus;
  private int _checks = 0;

  public ChecklistGoal()
  {
    _goalType = GoalTypes.ChecklistGoal;
  }

  public override Goal CreateSelf()
  {
    Console.Write("What is the name of your goal?: ");
    _name = Console.ReadLine();
    Console.Write("Write a short description of it: ");
    _description = Console.ReadLine();
    Console.WriteLine("The difficulty levels are: ");
    _difficultyLevel = Program.SelectEnumOption<DifficultyLevels>("Choose a difficulty level:");
    Console.Write("How many times does this goal need to be accomplished for a bonus?: ");
    _timesRequiredForBonus = Program.PromptChoice();
    Console.Write("What is the bonus for accomplishing it that many times?: ");
    _bonus = Program.SelectEnumOption<BonusOptions>("Choose a bonus:");
    return this;
  }

  public override void ListSelf(int index)
  {
    Console.WriteLine($"{index}. Checklist: [ {GetMarker()} ]. {GetName()} ({GetDescription()}) -- Next bonus: {_checks}/{_timesRequiredForBonus} times");
  }

  public override char GetMarker()
  {
    return _isComplete ? 'X' : ' ';
  }

  private int GetBonus()
  {
    return (int)_bonus;
  }

  public override int RecordEvent()
  {
    _checks++;
    int points = GetPoints();
    if (_checks == _timesRequiredForBonus)
    {
      Console.WriteLine($"Congratulations! You've accomplished the goal '{GetName()}' {_timesRequiredForBonus} times and earned the bonus: {_bonus}");
      _checks = 0;
      _isComplete = true;
    }
    points += GetBonus();
    return points;
  }

  public override object ToJson()
  {
    return new
    {
      type = _goalType,
      name = _name,
      description = _description,
      difficultyLevel = _difficultyLevel,
      isComplete = _isComplete,
      checks = _checks,
      timesRequiredForBonus = _timesRequiredForBonus,
      bonus = _bonus,
    };
  }

  public override void LoadGoal(JObject json)
  {
    _name = json["name"].ToString();
    _description = json["description"].ToString();
    _difficultyLevel = Enum.Parse<DifficultyLevels>(json["difficultyLevel"].ToString());
    _isComplete = bool.Parse(json["isComplete"].ToString());
    _checks = int.Parse(json["checks"].ToString());
    _timesRequiredForBonus = int.Parse(json["timesRequiredForBonus"].ToString());
    _bonus = Enum.Parse<BonusOptions>(json["bonus"].ToString());
  }
}

