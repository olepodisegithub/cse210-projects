using System;

class Program
{
    static void Main(string[] args)
    {
        String firstName = "";
        String lastName = "";

        Console.WriteLine("");

        Console.Write("What is your first name? ");
        firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        lastName = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");

        Console.WriteLine("");
    }
}