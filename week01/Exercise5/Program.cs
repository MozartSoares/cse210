using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome() 
        {
            Console.WriteLine("Welcome to the Program!");
        }
        static string PromptUserName() 
        {
            Console.WriteLine("Please enter your name:");
            return Console.ReadLine();
        }
        static int PromptUserNumber() 
        {
            Console.WriteLine("Please enter your favorite number:");
            bool inputIsValid = false;
            int userNumber = 0;
            while (!inputIsValid)
            {
                try
                {
                    userNumber = int.Parse(Console.ReadLine());  
                    inputIsValid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return userNumber;
        }
        static int SquareNumber(int number) 
        {
            return number * number;
        }
        static void DisplayResult(string userName, int userNumber) 
        {
            int squaredNumber = SquareNumber(userNumber);
            Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
        }
        static void Main() 
        {
            DisplayWelcome();
            string userName = PromptUserName();
            int userNumber = PromptUserNumber();
            DisplayResult(userName, userNumber);
        }
        Main();
    }
}