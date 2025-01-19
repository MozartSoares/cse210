// To exceed the requirements i've added many extra functionalities to the program.
// The program now allows the user to play with a random scripture or a specific scripture.
// The scripture is fetched from the bible-api 
// The user can also display all the played scriptures.


using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Clear();
        ScriptureLibrary library = new();
        
        int option = 0;
        Console.WriteLine("Welcome to the Scripture Memorizer program!");
        while (option != 5)
        {   
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Play with a random scripture");
            Console.WriteLine("2. Play with a specific scripture");
            Console.WriteLine("3. Display all played scriptures");
            Console.WriteLine("4. Quit");
            Console.Write("What would you like to do: ");
            option = PromptChoice(validChoices:[1,2,3,4]);
            switch (option)
            {
                case 1:
                    try {
                        await library.FetchRandomScriptureAsync();
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                        break;
                    };
                    Scripture scripture = library.GetLastScripture();
                    PlayScriptureGame(scripture);
                    break;
                case 2:
                    bool fetchedScripture = false;
                    while (!fetchedScripture)
                    {
                        try {
                            Reference reference = GetUserScriptureReference();
                            await library.FetchScriptureByReferenceAsync(reference);
                            fetchedScripture = true;
                        } catch (Exception e) {
                            Console.WriteLine(e.Message);
                        }
                    }
                    Scripture specificScripture = library.GetLastScripture();
                    PlayScriptureGame(specificScripture);
                    break;
                case 3:
                    library.DisplayAllScriptures();
                break;
                case 4:
                    Console.WriteLine("Thanks for using the program, goodbye!");
                break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid choice.");
                break;
            }
        } 
    }

    private static int PromptChoice(List<int> validChoices = null, bool allowEmpty = false)
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

    private static void PlayScriptureGame(Scripture scripture) 
    {
        ShowInstructions();
        Console.Write("How many words would you like to hide each round? (choose from 1 to 5): ");
        int count = PromptChoice([1,2,3,4,5]);
        scripture.DisplayText();
        bool wantsToPlay = true;
        while (scripture.GetIsCompletelyHidden() == false && wantsToPlay)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "quit":
                    wantsToPlay = false;
                    break;
                case "r":
                    scripture.Reset();
                    scripture.DisplayText();
                    break;
                default:
                    int wordsToHide = Math.Min(count, scripture.GetRemainingWordsCount());
                    scripture.HideRandomWords(wordsToHide);
                    Console.Clear();
                    scripture.DisplayText();
                    break;
            }
        }
        scripture.Reset();
    }    

    private static void ShowInstructions() {
        Console.WriteLine("Press enter to hide words or type ['r'] to reset the word.");
        Console.WriteLine("Remember, you can alwys type ['quit'] to stop the game");
    }

    private static Reference GetUserScriptureReference() {
        Console.Write("Enter the book: ");
        string book = Console.ReadLine();

        Console.Write("Enter the chapter: ");
        int chapter = PromptChoice();

        Console.Write("Enter the verse: ");
        int verse = PromptChoice();

        Console.Write("Enter the end verse or press enter to use only 1 verse: ");
        int endVerse = PromptChoice(allowEmpty: true);

        if (endVerse != -1 && endVerse < verse)
        {
            Console.WriteLine("End verse cannot be before the start verse. Using only the start verse.");
            endVerse = -1;
        }
        if (endVerse != -1)
        {
            return new Reference(book, chapter, verse, endVerse);
        }
        else
        {
            return new Reference(book, chapter, verse);
        }
    }
}