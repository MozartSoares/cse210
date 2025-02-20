
// To exceed the requirements I added a user class to keep track of the user stats and added a new option to the menu to see stats 
// I also added a leveling up system for the user
class Program
{
    private static readonly string _baseFileUrl = "goals.txt";
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine("Please insert a file name to load the goals and user stats, or leave empty to create a new one: ");
        string file = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(file))
        {
            file = _baseFileUrl;
        }
        var goalManager = new GoalManager(file); 
        // var user = new User() with stats form file
        int choice = 0;
        while (choice != 7)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. See Stats");
            Console.WriteLine("7. Exit");
            Console.Write("Select a choice from the menu: ");
            choice = PromptChoice([1, 2, 3, 4,5,6,7]);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("The types of goal are: ");
                    GoalTypes goalType = SelectEnumOption<GoalTypes>("Which type of goal would you like to create?");
                    goalManager.CreateNewGoal(goalType);
                    goalManager.SaveFile();
                    break;
                case 2:
                    goalManager.ListGoals();
                    goalManager.ShowUserXp();
                    break;
                case 3:
                    Console.Write("Enter the file name to save the goals and user stats: ");
                    string fileName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        Console.WriteLine("Invalid file name. The file name cannot be empty.");
                        break;
                    } 
                    goalManager.SaveFile(fileName);
                    break;
                case 4:
                    Console.WriteLine("Enter the file name to load the goals: ");
                    string filename = Console.ReadLine();
                    goalManager.LoadFile(filename);
                    //load goals    
                    break;
                case 5:
                    goalManager.RecordEvent();
                    //record event
                    break;
                case 6:
                    goalManager.ShowUserStats();
                    //see stats
                    break;
                case 7:
                    Console.WriteLine("Thanks for using the Eternal Quest, goodbye!");
                    break;
            }
        }
    }

    public static T SelectEnumOption<T>(string promptMessage) where T : Enum
    {
        var enumValues = (T[])Enum.GetValues(typeof(T));
        var intValues = enumValues.Select(t => Convert.ToInt32(t)).ToArray();

        Console.WriteLine(promptMessage);
        foreach (var value in enumValues)
        {
            Console.WriteLine($" option [{Convert.ToInt32(value)}]. {value}");
        }

        int choice = PromptChoice(intValues);
        return (T)Enum.ToObject(typeof(T), choice);
    }

    public static int PromptChoice(int[] validChoices = null, bool allowEmpty = false)
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

