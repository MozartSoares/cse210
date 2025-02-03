using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App!");
        Console.WriteLine("Please select an activity to begin:");
        Console.WriteLine("1. Reflection Activity");
        Console.WriteLine("2. Listing Activity");
        Console.WriteLine("3. Breathing Activity");
        Console.WriteLine("4. Exit");

        int choice = PromptNumber([ 1, 2, 3,4 ]);

        while (choice != 4) 
        {
            switch (choice)
            {
                case 1:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Init();
                    break;
                case 2:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Init();
                    break;
                case 3:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    BreathingActivity.StartActivity();
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }
    }

    public static int PromptNumber(List<int> validChoices = null, bool allowEmpty = false)
    {
        int choice = 0;
        bool answerIsInvalid = true;

        while (answerIsInvalid)
        {
            try
            {
                string input = Console.ReadLine();
                if (allowEmpty && string.IsNullOrWhiteSpace(input))
                {
                    return -1;
                }
                choice = int.Parse(input);
                if (validChoices == null || validChoices.Contains(choice))
                {
                    answerIsInvalid = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
            }
        }

        return choice;
    }
}

