using System;

class Program
{
    private static MathAssignment ma = new MathAssignment("Samuel Bennett","Multiplication","7.3","8-9");
    private static WritingAssignment wa = new WritingAssignment("Mary Waters","European History","The Causes of World War II by Mary Waters");
    static void Main(string[] args)
    {
        Console.WriteLine(ma.GetSummary()); 
        Console.WriteLine(ma.GetHomeworkList()); 

        Console.WriteLine(wa.GetSummary()); 
        Console.WriteLine(wa.GetWritingInformation());
    }
}