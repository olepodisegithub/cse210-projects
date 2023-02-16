public class Assignments
{
    private String _studentName = "";
    private String _topic = "";

    public Assignments(String studentname, String topic)
    {
        _studentName = studentname;
        _topic = topic;
    }  

    public string GetSummary()
    {
       return $"{_studentName} - {_topic}";
    }  
}