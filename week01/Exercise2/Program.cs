using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        int grade = 0;
        bool validInput = false;
        while (!validInput)
        {
            try
            {
            grade = int.Parse(Console.ReadLine());
            validInput = true;
            }
            catch (FormatException)
            {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        char letter = ' ';
        if (grade < 60)
        {
            letter = 'F';
        }
        else if (grade < 70)
        {
            letter = 'D';
        }
        else if (grade < 80)
        {
            letter = 'C';
        }
        else if (grade < 90)
        {
            letter = 'B';
        }
        else if (grade <= 100)
        {
            letter = 'A';
        }
        Console.WriteLine($"your grade is " + letter);
        bool isPassing = grade >= 70;
        if (isPassing)
        {
            Console.WriteLine("You passed the course congratulations!");
        }
        else
        {
            Console.WriteLine("You failed the course, better luck next time!");
        }
    }
}