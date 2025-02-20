abstract class Goal 
{
  protected string  _name;
  protected string  _description;
  protected DifficultyLevels _difficultyLevel; 
  protected GoalTypes _goalType;
  protected bool _isComplete = false;

  public abstract void ListSelf(int index); 
  
  public abstract int RecordEvent();
  public abstract Goal CreateSelf();

  public abstract string ToStringRepresentation();

  public abstract char GetMarker();

  public abstract void LoadGoal(string[] data);

  public bool IsCompleted()
  {
    return _isComplete;
  }

  public string GetName()
  {
    return _name;
  }

  public string GetDescription()
  {
    return _description;
  }

  public int GetPoints() {
    return (int)_difficultyLevel;
  }

}

