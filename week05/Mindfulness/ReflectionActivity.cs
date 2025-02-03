
class ReflectionActivity : Activity
{

    List<string> _userPrompts = [
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless.",
    "Think of a time when you overcame a fear.",
    "Think of a time when you made a new friend.",
    "Think of a time when you learned something new.",
    "Think of a time when you achieved a personal goal.",
    "Think of a time when you made a positive impact on someone else's life.",
    "Think of a time when you stood up for your beliefs.",
    "Think of a time when you worked as part of a team.",
    "Think of a time when you resolved a conflict.",
    "Think of a time when you showed compassion to someone.",
    "Think of a time when you made a difficult decision."
  ];
    List<string> _questions = [
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?",
    "How did this experience change you?",
    "What challenges did you face during this experience?",
    "How did you overcome those challenges?",
    "What strengths did you discover in yourself?",
    "How can you apply what you learned from this experience to your future goals?"
  ];

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void StartActivity() 
    {
      Init();
      Console.Clear();
      
      ShowSpinner(3,"Get ready:");

      Console.Clear();
      Random random = new();
      var randomPrompt = _userPrompts[random.Next(_userPrompts.Count)];
      Console.WriteLine($"Consider the following prompt:");
      Console.WriteLine($"--- {randomPrompt} ---");
      Console.WriteLine("When you have something in mind, press any key to continue.");
      Console.ReadLine();
      Console.WriteLine("Now ponder on each of the following question as they relate to this experience:\n");
      ShowSpinner(3,"You may begin in:");
      List<string> usedQuestions = [];
      DateTime startTime = DateTime.Now;
      DateTime futureTime = startTime.AddSeconds(_duration);
      while (DateTime.Now < futureTime) 
      {
        var randomQuestion = _questions[random.Next(_questions.Count)];
        if (usedQuestions.Contains(randomQuestion)) continue;
        ShowSpinner(5,$"\n> {randomQuestion}");
        usedQuestions.Add(randomQuestion);
      }

    }
}