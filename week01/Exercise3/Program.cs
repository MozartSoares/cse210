using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome top the random number game !");
        Random random = new();
        int magicNumber = random.Next(1, 100);
        bool won = false;
        while (won == false)
        {
            Console.WriteLine("What is your guess?");
            bool validInput = false;
            int number = 0;
            while (!validInput)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            if (number == magicNumber)
            {
                Console.WriteLine("You guessed it!");
                won = true;
            }
            else if (number < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (number > magicNumber)
            {
                Console.WriteLine("Lower");
            }
        }
        
        

    }
}