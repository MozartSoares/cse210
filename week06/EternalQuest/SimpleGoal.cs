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

      public override string ToStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{(int)_difficultyLevel}|{_isComplete}";
    }

    public override void LoadGoal(string[] data)
    {
        _name = data[1];
        _description = data[2];
        _difficultyLevel = (DifficultyLevels)int.Parse(data[3]);
        _isComplete = bool.Parse(data[4]);
    }
}