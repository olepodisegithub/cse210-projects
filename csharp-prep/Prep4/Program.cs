using System;

class Program
{
    static void Main(string[] args)
    {
        Boolean add = true;
        List<int> numbers = new List<int>();
        int num = 0;
        int sum = 0;
        int largest = 0;

        Console.WriteLine("");

        Console.WriteLine("Add numbers. enter 0 if you are done!");

        while (add == true)
        {
            Console.Write("Enter number? ");
            num = int.Parse(Console.ReadLine());
            if (num == 0)
            {
                add = false;
            }
            else
            {
                numbers.Add(num);
            }
        }

        foreach (int n in numbers)
        {
            sum = sum + n;
            if (n > largest)
            {
                largest = n;
            }
        }

        Console.WriteLine("");
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"Average is: {sum / numbers.Count}");
        Console.WriteLine($"The larget is: {largest}");
    }
}