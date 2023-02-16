public class MathAssignment : Assignments
{
    private String _textbookSection = "";
    private String _problems = "";

    public MathAssignment(String studentname, String topic,String textbooksection, String problem) : base(studentname,topic)
    {
        _textbookSection = textbooksection;
        _problems = problem;
    }  

    public string GetHomeworkList()
    {
       return $"Section {_textbookSection} Problem {_problems}";
    }  
}