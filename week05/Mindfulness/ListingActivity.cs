
class ListingActivity : Activity
{
    List<String> _userPrompts = [
    "Who are people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the Holy Ghost this month?",
    "Who are some of your personal heroes?",
    "What are you grateful for today?",
    "What are some of your favorite memories?",
    "What are some goals you have achieved recently?",
    "Who are people that inspire you?",
    "What are some challenges you have overcome?",
    "What are some things you enjoy doing in your free time?"
  ];

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void StartActivity() 
    {
      Init();
        ShowSpinner(3,"Get ready:");
      Console.Clear();
      Random random = new();
      var randomPrompt = _userPrompts[random.Next(_userPrompts.Count)];
      Console.WriteLine($"List as many responses as you can to the following prompt:");
      Console.WriteLine($"--- {randomPrompt} ---");
      Console.WriteLine("Now ponder on each of the following question as they relate to this experience:");
      ShowSpinner(5,"You may begin in:");
      List<string> responses = [];
      DateTime startTime = DateTime.Now;
      DateTime futureTime = startTime.AddSeconds(_duration);
      while (DateTime.Now < futureTime) 
      {
        Console.Write("\n> ");
        string response = Console.ReadLine();
        responses.Add(response);
      }
      int responseCount = responses.Count;
      Console.WriteLine($"Well done, you listed {responseCount} Here are your responses:");
      foreach (string response in responses)
      {
        Console.WriteLine(response);
      }
    }
}