public class ListingActivity : Activiy
{
    private List<Prompts> _promptList = new List<Prompts>();
    private List<ListedItems> _items = new List<ListedItems>();
     public ListingActivity(string activityname,
                            string description,
                            string preparingmessage,
                            int pasueduration) : 
                            
                            base( activityname, 
                            description, 
                            preparingmessage, 
                            pasueduration)
    {
        CreatePromptList();
    }
    public void CreatePromptList()
    {
        string[] entrylines = System.IO.File.ReadAllLines("ListingPromptList.txt");
        foreach(string item in entrylines)
        {
            Prompts pro = new Prompts(item);
            _promptList.Add(pro);
        }
    }
    public void List()
    {
        DisplayStartingMessage();
        DisplayDescription();
        SetDurationFromInput("How long in seconds would you like for your session ?");

        DisplayPreparingMessage();
        DisplaySpinner(3);

        Console.Clear();
        Console.WriteLine("List as many responses you can to these prompt:");
        DisplayRandomPrompt();

        Console.WriteLine("x");
        DisplayCountDown("Start in..",5);

        ClearLine();

        ListCountDown();

        DisplayEndingMessage();
        DisplaySpinner(4);
    }

    public void DisplayRandomPrompt()
    {
        var rnd = new Random();
        rnd = new Random();
        int index = rnd.Next(_promptList.Count);
        _promptList[index].DisplayPrompt();
    }

    public void ListCountDown()
    {
        System.Timers.Timer timer = new (interval: 1000 );
        
        int countLeft = ((GetDuration() * 1000));

        void HandleTimer(object sender, EventArgs e)
		{
            countLeft = countLeft - 1000;
            
           SaveItem(Console.ReadLine());
           
            if (countLeft <= 0)
            {
                timer.Stop();
            }
		}

        timer.Elapsed += ( sender, e ) => HandleTimer(sender, e);
		timer.Start();

        System.Threading.Thread.Sleep((GetDuration() * 1000));

        timer.Dispose();
        Console.WriteLine("");
        Console.WriteLine($"You listed {_items.Count()} items");
    }

    public void SaveItem(string desc)
    {
        _items.Add(new ListedItems(desc));
    }
}