
class Activity 
{
  protected string _activityName;
  protected string _description;
  int _duration { get; set; }

  public Activity(string activityName, string description)
  {
    _activityName = activityName;
    _description = description;
  }

  public void Init() 
  {
    Console.WriteLine(GetStartingMessage());
    askForDuration();
    Console.WriteLine("You will be doing this activity for " + _duration + " seconds.");
  }

  private string GetStartingMessage() 
  {
    return "Starting " + _activityName + ":\n " + _description;
  }

  private void askForDuration() 
  {
    Console.WriteLine("How long would you like to do this activity for? (in seconds)");
    _duration = Program.PromptNumber();
  }

  protected static void ShowSpinner(int duration)
  {
      char[] spinnerChars = { '|', '/', '-', '\\' };
      int counter = 0;
      DateTime endTime = DateTime.Now.AddSeconds(duration);
      while (DateTime.Now < endTime)
      {
          Console.Write($"\r{spinnerChars[counter % spinnerChars.Length]}"); 
          counter++;
          Thread.Sleep(200); 
      }
      Console.Write("\r "); 
  }

}