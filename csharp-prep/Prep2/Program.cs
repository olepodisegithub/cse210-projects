using System;

class Program
{
    static void Main(string[] args)
    {
        int gradePercentage = 0;
        String letterGrade = "";
        int passPercentage = 70;
        int lastDigit = 0;
        int plusSignGreaterOrEqualsTo = 7;
        int minusLessThan = 3;
        String sign = "";

        Console.WriteLine("");

        Console.Write("What is your grade percentage? ");
        gradePercentage = int.Parse(Console.ReadLine());

        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else if (gradePercentage < 60)
        {
            letterGrade = "F";
        }

        Console.WriteLine("");

        lastDigit = int.Parse(gradePercentage.ToString().Substring(gradePercentage.ToString().Length - 1));
        if (lastDigit >= plusSignGreaterOrEqualsTo)
        {
            sign = "+";
            if (letterGrade == "A")
            {
                sign = "";
            }
            else if (letterGrade == "F")
            {
                sign = "";
            }
        }
        else if (lastDigit < minusLessThan)
        {
            sign = "-";
            if (letterGrade == "F")
            {
                sign = "";
            }
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is {sign}{letterGrade}.");
        if (gradePercentage >= passPercentage)
        {
            Console.WriteLine("Congradulations! You have passed the class.");
        }
        else
        {
            Console.WriteLine("Unfortunately you have not passed the class. Try next time.");
        }
        Console.WriteLine("");
    }
}