public class Prompts
{
    private String _description = "";

    public Prompts(string descript)
    {
        _description = descript;
    }
    public void DisplayPrompt()
    {
        Console.WriteLine($"Prompt: {_description}");
    }

}