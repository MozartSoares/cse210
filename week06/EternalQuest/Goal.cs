using System.Diagnostics.Contracts;

class Goal 
{
  protected string  _name;
  protected bool _isComplete;

  public char Marked() {
    return _isComplete ? 'X' : ' ';
  }

  public bool IsCompleted()
  {
    return _isComplete;
  }

  public string GetName()
  {
    return _name;
  }

}