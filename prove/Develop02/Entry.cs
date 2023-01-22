public class Entry
{
    public String _promptDescription = "";
    public String _response = "";
    public String _date = "";

    public void DisplayEntry()
    {
        Console.WriteLine($"Date : {_date} --> Prompt : {_promptDescription}");
        Console.WriteLine($"{_response}");
        Console.WriteLine("");
    }  
}