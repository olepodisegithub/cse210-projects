abstract class Goals
{
    private string _goalType = "";
    private int _value = 0;
    private string _title = "";
    private string _description = "";
    private string _status = "";
    private string _goalIdentify = "";
    public Goals(string goaltype,int value,string title,string description,string status,string goalidentify)
    {
        _goalType = goaltype;
        _value = value;
        _title = title;
        _description = description;
        _status = status;
        _goalIdentify = goalidentify;
    }
    public string GetGoalType()
    {
        return _goalType;
    }
    public int GetValue()
    {
        return _value;
    }
    public string GetTitle()
    {
        return _title;
    }
    public string GetDescription()
    {
        return _description;
    }
    public string GetStatus()
    {
        return _status;
    }
    public string GetGoalIdentity()
    {
        return _goalIdentify;
    }
    public void SetStatus(string status)
    {
        _status = status;
    }
    public int getEventsCount()
    {
        int count = 0;
        string ide = "";
        
        string[] entrylines = System.IO.File.ReadAllLines("Events.txt");
        foreach (string line in entrylines)
        {
            string[] columns = line.Split("|");
            ide = columns[0];

            if(ide == _goalIdentify)
            {
                count = count + 1;
            }
        }
        return count;
    }
    public abstract void DisplayGoal(int index);
}
