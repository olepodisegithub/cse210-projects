using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = 0;
        int guess = 0;
        Boolean guessed = false;
        int guessNumber = 0;
        Boolean play = true;

        while (play == true)
        {
            guessed = false;
            Console.WriteLine("");

            Random randomGenerator = new Random();
            magicNumber = randomGenerator.Next(1, 100);
            Console.WriteLine("Margic number is between 1 and 100");

            while (guessed == false)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess > magicNumber)
                {
                    Console.WriteLine("Go lower!");
                    guessNumber = guessNumber + 1;
                }
                else if (guess == magicNumber)
                {
                    Console.WriteLine($"Correct!. It took you {guessNumber} try(es) to get it");
                    guessed = true;
                    Console.Write("Do you want to proceed playing? (Enter yes / no): ");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        play = true;
                    }
                    else
                    {
                        play = false;
                    }
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Go Higher");
                    guessNumber = guessNumber + 1;
                }
            }
            Console.WriteLine("");
        }
    }
}