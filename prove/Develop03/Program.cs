using System;

class Program
{
    private static Scripture _scripture = new Scripture();
    private static int _wordsCountToDisappear = 1;
    private static Prompt _pro = new Prompt();
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Oats Scripture Memorizer!");
        Console.WriteLine("");

        _wordsCountToDisappear = GetEnteredResponse("Enter how many words do you want to disappear everytime you hit Enter!");
        
        Console.Clear();
        NewScripture();
        _pro = new Prompt(_scripture);

        
        while (Console.ReadKey().Key == ConsoleKey.Enter) 
        {
            if (_pro._clearedWords.Count == _scripture._words.Count)
            {
                //Console.WriteLine(getEnteredResponse("Nice!"));
                Console.Clear();
                _pro._clearedWords.Clear();
                NewScripture();
                _pro = new Prompt(_scripture);
            }
            else
            {
                Console.Clear();
                _pro.DisplayPrompt(_wordsCountToDisappear);
            }

            if (Console.ReadLine().ToLower() == "quit")
            {
                Environment. Exit(0);
            }
        }
    }
    static int GetEnteredResponse(string displaytext)
    {
        Boolean _responseEntered = false;
        int _response = 0;

        while (_responseEntered == false)
        {
            Console.Write($"{displaytext}");
            _response = int.Parse(Console.ReadLine());
            if (_response == 0)
            {
                _responseEntered = false;
            }
            else
            {
                _responseEntered = true;
            }   
        }
        return _response;
    }

    private static void NewScripture()
    {
        string bookname = "";
        int chapter = 0;
        int startVerse = 0;
        int endVerse = 0;

        string[] entrylines = System.IO.File.ReadAllLines("Scriptures.txt");
        var rnd = new Random();
        int index = rnd.Next(entrylines.Length);

        string[] row = entrylines[index].Split(":");

        string bookAndChapter = row[0];
        string verses = row[1];
        string sriptureText = row[2];

        string[] bokCh = bookAndChapter.Split(" ");
        if (bokCh.Length > 2)
        {
            bookname = $"{bokCh[0]} {bokCh[1]}";
            chapter = int.Parse(bokCh[2]);
        }
        else
        {
            bookname = bokCh[0];
            chapter = int.Parse(bokCh[1]);
        }

        if (verses.Contains("-") == true)
        {
            string[] vers = verses.Split("-");
            startVerse = int.Parse(vers[0]);
            endVerse = int.Parse(vers[1]);
            _scripture = new Scripture(sriptureText,bookname,chapter,startVerse,endVerse);
        }
        else
        {
            startVerse = int.Parse(verses);
            endVerse = 0;
            _scripture = new Scripture(sriptureText,bookname,chapter,startVerse);
        }

        _scripture.DisplayScripture(_scripture.GetScriptureText());
    }

}