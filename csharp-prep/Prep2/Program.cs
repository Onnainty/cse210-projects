using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your grade percentage: ");
            string input = Console.ReadLine();
            int percentage;
            while (!int.TryParse(input, out percentage) || percentage < 0 || percentage > 100)
            {
                Console.WriteLine("Invalid input. Please enter a percentage between 0 and 100.");
                Console.Write("Enter your grade percentage: ");
                input = Console.ReadLine();
            }

            string letter = "";
            string sign = "";

            if (percentage >= 90)
            {
                letter = "A";
            }
            else if (percentage >= 80)
            {
                letter = "B";
            }
            else if (percentage >= 70)
            {
                letter = "C";
            }
            else if (percentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Unfortunately, you did not pass the course. Better luck next time.");
            }

            int lastDigit = percentage % 10;

            if (letter != "A" && letter != "F")
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
            else if (letter == "A" && lastDigit < 3)
            {
                sign = "-";
            }

            Console.WriteLine($"Your letter grade is: {letter}{sign}");
        }
    }
}
