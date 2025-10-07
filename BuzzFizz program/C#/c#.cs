using System;
using System.Collections.Generic;

class Program
{
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static int GetValidInput()
    {
        int attempts = 0;
        while (attempts < 3)
        {
            Console.Write("Enter a number between 10 and 200: ");
            string input = Console.ReadLine();
            int value;
            if (int.TryParse(input, out value))
            {
                if (value >= 10 && value <= 200)
                    return value;
                else
                    Console.WriteLine("Number not in the range 10–200.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            attempts++;
        }
        Console.WriteLine("Too many invalid attempts. Exiting.");
        Environment.Exit(0);
        return -1; // Won't reach here
    }

    static void Main()
    {
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();
        int N = GetValidInput();

        List<string> output = new List<string>();
        int countPrimes = 0;
        int sumEven = 0;
        int maxOdd = int.MinValue;
        int sumDivBy7 = 0;

        for (int i = 1; i <= N; i++)
        {
            if (i % 15 == 0)
            {
                output.Add("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                output.Add("Fizz");
            }
            else if (i % 5 == 0)
            {
                output.Add("Buzz");
            }
            else if (IsPrime(i))
            {
                output.Add($"[{i}]");
                countPrimes++;
            }
            else
            {
                output.Add(i.ToString());
            }

            if (i % 2 == 0)
            {
                sumEven += i;
            }

            if (i % 2 != 0)
            {
                if (i > maxOdd)
                    maxOdd = i;
            }

            if (i % 7 == 0)
            {
                sumDivBy7 += i;
            }
        }

        // Output result
        Console.WriteLine(string.Join(" ", output));

        // Summary
        Console.WriteLine($"\nCountPrimes = {countPrimes}");
        Console.WriteLine($"SumEven = {sumEven}");
        Console.WriteLine($"MaxOdd = {maxOdd}");
        Console.WriteLine($"SumDivBy7 = {sumDivBy7}");

        Console.WriteLine($"Well done, {name}! You combined loops and conditionals successfully.");
    }
}

