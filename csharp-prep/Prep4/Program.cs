using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
                break;

            numbers.Add(number);
        }

        int sum = numbers.Sum();

        double average = numbers.Count > 0 ? numbers.Average() : 0;

        int maxNumber = numbers.Count > 0 ? numbers.Max() : 0;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        int? smallestPositiveNumber = numbers.Where(n => n > 0).DefaultIfEmpty().Min();

        if (smallestPositiveNumber.HasValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber.Value}");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
