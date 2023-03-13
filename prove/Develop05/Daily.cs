class Daily : Goals
{
    private DateTime _startDate;
    private DateTime _endDate;
    private int _penaltyPoints;

    public DateTime GetStartDate()
    {
        return _startDate;
    }
    public DateTime GetEndDate()
    {
        return _endDate;
    }
    public int GetPenaltyPoints()
    {
        return _penaltyPoints;
    }
    public Daily(string goaltype,int value,string title,string description,string status,string goalidentify,DateTime startdate,DateTime enddate,int penaltyponits) : base(goaltype,value,title,description,status,goalidentify)
    {
        _startDate = startdate;
        _endDate = enddate;
        _penaltyPoints = penaltyponits;
    }
    public override void DisplayGoal(int index)
    {
        if(GetStatus() == "Completed")
        {
            Console.WriteLine($"{index}. [X] {GetTitle()} ({GetDescription()}) -- Days achieved ({getEventsCount()})");
        }
        else
        {
            Console.WriteLine($"{index}. [] {GetTitle()} ({GetDescription()}) -- Days achieved ({getEventsCount()})");
        }  
    }
}
