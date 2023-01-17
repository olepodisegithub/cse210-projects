using System;

class Program
{
    static void Main(string[] args)
    {
        Jobs jb1 = new Jobs();
        jb1._jobTitle = "Software Engineer";
        jb1._company = "Thito Holdings";
        jb1._startYear = 2014;
        jb1._endYear = 2022;

        Jobs jb2 = new Jobs();
        jb2._jobTitle = "Manager";
        jb2._company = "Thito Holdings";
        jb2._startYear = 2023;
        jb2._endYear = 2025;

        Resume rs = new Resume();
        rs._jobs.Add(jb1);
        rs._jobs.Add(jb2);

        rs.Display();        
    }
}