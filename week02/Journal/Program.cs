// To exceeed the requirements, i implemented the file management in a single function saving the data as a Json formatted data to ensure better and more consistent data handling
using System;
class Program
{
    static void Main(string[] args)
    {
        Journal Journal = new();
        int choice = 0;
        Console.WriteLine("Welcome to the journal program!");
        while (choice != 5)
        {   
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do:");
            choice = Journal.PromptChoice();
            switch (choice)
            {
                case 1:
                    Journal.Write();
                break;
                case 2:
                    Journal.Display();
                break;
                case 3:
                    Journal.ManageFile(FileAction.Save);
                break;
                case 4:
                    Journal.ManageFile(FileAction.Load);
                break;
                case 5:
                    Console.WriteLine("Thanks for using the program, goodbye!");
                break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid choice.");
                break;
            }
        } 
    }
}