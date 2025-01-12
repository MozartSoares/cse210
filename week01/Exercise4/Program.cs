using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = [];
        int userInput = 999;
        while (userInput !=0)
        {
            try
            {
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0) {
            numbers.Add(userInput);
            }
            }
            catch (FormatException)
            {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        if (numbers.Count > 0)
        {
            float average = (float)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            int max = numbers[0];
            foreach (int number in numbers)
            {
            if (number > max)
            {
                max = number;
            }
            }
            Console.WriteLine($"The largest number is: {max}");
        }

    }
}