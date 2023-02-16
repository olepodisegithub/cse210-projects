public class WritingAssignment : Assignments
{
    private String _title = "";

    public WritingAssignment(String studentname, String topic,String title) : base(studentname,topic)
    {
        _title = title;
    }  

    public string GetWritingInformation()
    {
       return $"{_title}";
    }  
}