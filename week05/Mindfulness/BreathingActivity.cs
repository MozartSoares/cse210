
class BreathingActivity : Activity
{
  int _breathingInterval; 
  public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
  {
  }

  public void StartActivity()
  {
    init();
    PromptBreathingInterval();
    
    DateTime startTime = DateTime.Now;
    DateTime futureTime = startTime.AddSeconds(Duration);

    while (DateTime.Now < futureTime)
    {
        Console.WriteLine("Breathe in...");
        showSpinner(_breathingInterval);

        if (DateTime.Now >= futureTime) break;

        Console.WriteLine("Breathe out...");
        showSpinner(_breathingInterval);
    }

  }

  private promptBreathingInterval() {
    Console.WriteLine("Select one of  the following breathing intervals: ");
    Console.WriteLine("5 seconds \n 10 seconds \n 15 seconds");
    _breathingInterval = Program.PromptNumber([5, 10, 15]);
  }
}
