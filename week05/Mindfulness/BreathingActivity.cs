
class BreathingActivity : Activity
{
  public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }


  public void StartActivity()
  {
      Init();
      Console.Clear();
      ShowSpinner(3,"Get ready:");
      Console.Clear();
      DateTime startTime = DateTime.Now;
      DateTime futureTime = startTime.AddSeconds(_duration);
      while (DateTime.Now < futureTime)
      {
          ShowSpinner(5, "Breathe in...");
          Console.WriteLine(); 

          if (DateTime.Now >= futureTime) break;

          ShowSpinner(6, "Now breathe out...");
          Console.WriteLine();
      }
  }

}