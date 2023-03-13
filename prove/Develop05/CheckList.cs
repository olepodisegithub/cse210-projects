class CheckList : Goals
{
    private int _numberOfEvents = 0;
    private int _bonusAtCompletion = 0;
    public int GetNumberOFEvents()
    {
        return _numberOfEvents;
    }
    public int GetBonusAtCompletion()
    {
        return _bonusAtCompletion;
    }
    public CheckList(string goaltype,int value,string title,string description,string status,string goalidentify,int numberofevents,int bonusatcompletion) : base(goaltype,value,title,description,status,goalidentify)
    {
        _numberOfEvents = numberofevents;
        _bonusAtCompletion = bonusatcompletion;
    }
    public override void DisplayGoal(int index)
    {
        if(GetStatus() == "Completed")
        {
            Console.WriteLine($"{index}. [X] {GetTitle()} ({GetDescription()}) -- Currently completed: {getEventsCount()}/{_numberOfEvents}");
        }
        else
        {
            Console.WriteLine($"{index}. [] {GetTitle()} ({GetDescription()}) -- Currently completed: {getEventsCount()}/{_numberOfEvents}");
        } 
    }
}
