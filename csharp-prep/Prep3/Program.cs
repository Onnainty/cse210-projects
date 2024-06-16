using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int guess = 0;
            int numberOfGuesses = 0;

    
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {numberOfGuesses} guesses.");
                }
            }

            Console.Write("Do you want to play again? (yes/no) ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes");
        }
    }
}
