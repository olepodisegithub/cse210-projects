class Eternal : Goals
{
    public Eternal(string goaltype,int value,string title,string description,string status,string goalidentify) : base(goaltype,value,title,description,status,goalidentify)
    {
        
    }
    public override void DisplayGoal(int index)
    {
        if(GetStatus() == "Completed")
        {
            Console.WriteLine($"{index}. [X] {GetTitle()} ({GetDescription()})");
        }
        else
        {
            Console.WriteLine($"{index}. [] {GetTitle()} ({GetDescription()})");
        } 
    }
}
