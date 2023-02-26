public class ReflectionQuestion
{
    private String _questionDescription = "";

     public ReflectionQuestion(string descript)
    {
        _questionDescription = descript;
    }
    public void DisplayQuestion()
    {
        Console.WriteLine($"Question: {_questionDescription}");
    }

}