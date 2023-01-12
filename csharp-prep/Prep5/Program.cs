using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "";
        int number = 0;

        Console.WriteLine("");

        DisplayWelcome();
        name = PromptUserName();
        number = PromptUserNumber();
        DisplayResult(name,SquareNumber(number));
        
        Console.WriteLine("");
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int num)
    {
        return num * num;
    }

    static void DisplayResult(string name, int num)
    {
        Console.WriteLine($"Brother {name}, the square of your number is {num}");
    }
}