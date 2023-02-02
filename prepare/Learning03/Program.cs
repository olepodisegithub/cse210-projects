using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(new Fraction().GetFractionString());
        Console.WriteLine(new Fraction().GetDecimalValue());

        Console.WriteLine(new Fraction(5).GetFractionString());
        Console.WriteLine(new Fraction(5).GetDecimalValue());

        Console.WriteLine(new Fraction(3,4).GetFractionString());
        Console.WriteLine(new Fraction(3,4).GetDecimalValue());

        Console.WriteLine(new Fraction(1,3).GetFractionString());
        Console.WriteLine(new Fraction(1,3).GetDecimalValue());
    }
}