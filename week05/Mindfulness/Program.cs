using System;
//to exceed the requirements i've added methods to save user data to a json file and
//added another option to show the statistics of the activities
class Program
{
    static void Main(string[] args)
    {
        Activity.InitializeStatsFile();
        Console.Clear();
        Console.WriteLine("Welcome to the Mindfulness App!");
        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Please select an activity to begin:");
            Console.WriteLine("1. Reflection Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Breathing Activity");
            Console.WriteLine("4. Display Statistics");
            Console.WriteLine("5. Exit");
            choice = PromptNumber([1, 2, 3, 4,5]);
            switch (choice)
            {
                case 1:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartActivity();
                    reflectionActivity.EndActivity();
                    break;
                case 2:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartActivity();
                    listingActivity.EndActivity();
                    break;
                case 3:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartActivity();
                    breathingActivity.EndActivity();
                    break;
                case 4:
                    Console.Clear();
                    var data = Activity.GetActivitiesData();
                    Console.WriteLine("=== Estatísticas de Atividades ===");
                    Console.WriteLine("Atividade\t\tVezes Jogadas");
                    Console.WriteLine("----------------------------------");
                    foreach (var activity in data)
                    {
                        string activityName = activity.Key.Replace("_", " ");
                        Console.WriteLine($"{activityName,-20}\t{activity.Value.times_played}");
                    }
                    Console.WriteLine("\nPress any key to go back to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 5:
                    Console.WriteLine("Thanks for using the mindfullness app, goodbye!");
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

