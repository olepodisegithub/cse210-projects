using System;

class Program
{
    static Boolean quit = false;
    static Boolean quitgoalsmenue = false;
    static Boolean quitrecordeventmenue = false;
    private static int _selectedMenueNumber = 0;
    private static int _selectedGoal = 0;
    private static int _selectedEventGoal = 0;
    private static List<Menue> _menueItems = new List<Menue>();
    private static List<Menue> _goalsMenueItems = new List<Menue>();
    private static List<Menue> _goalsListMenue = new List<Menue>();
    private static List<Simple> _simpleGoals = new List<Simple>();
    private static List<Eternal> _eternalGoals = new List<Eternal>();
    private static List<CheckList> _checkListGoals = new List<CheckList>();
    private static List<Daily> _dailyGoals = new List<Daily>();
    private static string identify = "";
    static void Main(string[] args)
    {
        SetupProgram();
        while (quit == false)
        {
            DisplayMenue("Main");

            //check which menu item have been selected
            if (_selectedMenueNumber == 1)
            {
                quitgoalsmenue = false;
                DisplayMenue("Goals");
                while (quitgoalsmenue == false)
                {
                    //create new goal
                    if (_selectedGoal == 1)
                    {
                        //simple goal
                        Console.WriteLine("Enter the following values for the simple goal;");
                        string title = getEnteredString("Title of the goal =");
                        string description = getEnteredString("Description of the goal =");
                        int point = int.Parse(getEnteredString("Point associated with the goal ="));
                        _simpleGoals.Add(new Simple("Simple",point,title,description,"Not Completed","Simple:" + DateTime.Now));
                        quitgoalsmenue = true;

                        //save goals
                        ClearFile();
                        SaveGoal();
                        LoadGoals();
                    }
                    else if (_selectedGoal == 2)
                    {
                        //eternal goal
                        Console.WriteLine("Enter the following values for the eternal goal;");
                        string title = getEnteredString("Title of the goal =");
                        string description = getEnteredString("Description of the goal =");
                        int point = int.Parse(getEnteredString("Point associated with the goal ="));
                        _eternalGoals.Add(new Eternal("Eternal",point,title,description,"Not Completed","Eternal:" + DateTime.Now));
                        quitgoalsmenue = true;

                        //save goals
                        ClearFile();
                        SaveGoal();
                        LoadGoals();
                    }
                    else if (_selectedGoal == 3)
                    {
                        //check list goal
                        //eternal goal
                        Console.WriteLine("Enter the following values for the check list goal;");
                        string title = getEnteredString("Title of the goal =");
                        string description = getEnteredString("Description of the goal =");
                        int point = int.Parse(getEnteredString("Point associated with the goal ="));
                        int numberofevents = int.Parse(getEnteredString("Number of events to complete for the goal ="));
                        int bonuspoints = int.Parse(getEnteredString("Bonus point when the events have been completed for the goal ="));
                        _checkListGoals.Add(new CheckList("Check List",point,title,description,"Not Completed","Check List:" + DateTime.Now,numberofevents,bonuspoints));
                        quitgoalsmenue = true;

                        //save goals
                        ClearFile();
                        SaveGoal();
                        LoadGoals();
                    }
                    else if (_selectedGoal == 4)
                    {
                        //daily goal
                        Console.WriteLine("Enter the following values for the eternal goal;");
                        string title = getEnteredString("Title of the goal =");
                        string description = getEnteredString("Description of the goal =");
                        int point = int.Parse(getEnteredString("Point associated with the goal ="));
                        DateTime startdate = DateTime.Parse(getEnteredString("Start Date of the goal (e.g. YYYY/mm/dd) ="));
                        DateTime enddate = DateTime.Parse(getEnteredString("End/Finishing Date of the goal (e.g. YYYY/mm/dd) ="));
                        int penaltypoints = int.Parse(getEnteredString("Penalty points deducted daily if the goal is not done ="));
                        _dailyGoals.Add(new Daily("Daily",point,title,description,"Not Completed","Daily:" + DateTime.Now,startdate,enddate,penaltypoints));
                        quitgoalsmenue = true;

                        //save goals
                        ClearFile();
                        SaveGoal();
                        LoadGoals();
                    }
                    else if (_selectedGoal == 5)
                    {
                        //quit
                        quitgoalsmenue = true;
                    }
                }
            }
            else if (_selectedMenueNumber == 2)
            {
                //list goals
                ListGoals();
            }
            else if (_selectedMenueNumber == 3)
            {
                //record event
                quitrecordeventmenue = false;
                DisplayMenue("Events");

                while (quitrecordeventmenue == false)
                {
                    identify = GetSelectedIdentity(_selectedEventGoal);
                    SaveEvent();
                    ClearFile();
                    updateGoalsStatus();
                    SaveGoal();
                    LoadGoals();
                    quitrecordeventmenue = true;
                }
            }
            else if (_selectedMenueNumber == 4)
            {
               //quit
                quit = true;
            }
        }
    }
    public static string GetSelectedIdentity(int selected)
    {
        string ide = "";
        foreach (Menue item in _goalsListMenue)
        {
            if(item.GetItemNumber() == selected)
            {
                ide = item.GetIdentify();
            }
        }
        return ide;
    }
    public static void SetupProgram()
    {
        _menueItems.Add(new Menue(1,"Create New Goal","1"));
        _menueItems.Add(new Menue(2,"List Goals","2"));
        _menueItems.Add(new Menue(3,"Record Event","3"));
        _menueItems.Add(new Menue(4,"Quit","4"));

        _goalsMenueItems.Add(new Menue(1,"Simple Goal","1"));
        _goalsMenueItems.Add(new Menue(2,"Eternal Goal","2"));
        _goalsMenueItems.Add(new Menue(3,"Check List Goal","3"));
        _goalsMenueItems.Add(new Menue(4,"Daily Goal","4"));
        _goalsMenueItems.Add(new Menue(5,"Quit","5"));

        LoadGoals();
        updateGoalsStatus();
    }
    public static void DisplayMenue(string whichmenue)
    {
        Console.WriteLine("");
        Console.WriteLine($"You have {getPoints()} points!");

        if(whichmenue == "Main")
        {
            Console.WriteLine("");
            Console.WriteLine($"Menue Options:");
            foreach (Menue item in _menueItems)
            {
                item.DisplayItem();
            }
            _selectedMenueNumber = getSelectedMenuNumber(_menueItems.Count());
        }
        else if(whichmenue == "Goals")
        {
            Console.WriteLine("");
            Console.WriteLine($"Goals Options:");
            foreach (Menue item in _goalsMenueItems)
            {
                item.DisplayItem();
            }
            _selectedGoal = getSelectedMenuNumber(_goalsMenueItems.Count());
        }
        else if(whichmenue == "Events")
        {
            Console.WriteLine("");
            Console.WriteLine($"Goals Events Options:");
            foreach (Menue item in _goalsListMenue)
            {
                item.DisplayItem();
            }
            _selectedEventGoal = getSelectedMenuNumber(_goalsListMenue.Count());
        }
    }
    static int getSelectedMenuNumber(int menucount)
    {
        Boolean _itemSelected = false;
        int num = 0;

        while (_itemSelected == false)
        {
            Console.Write($"Please select menu item (Enter number between 1 and {menucount}):");
            try
            {
                num = int.Parse(Console.ReadLine());
                if (num == 0)
                {
                    _itemSelected = false;
                }
                else
                {
                    if (num > 0)
                    {
                        if ( num <= menucount)
                        {
                             _itemSelected = true;
                        }
                    }
                }
            }
            catch
            {
                _itemSelected = false;
            }
        }
        return num;
    }
    static string getEnteredString(string displaytext)
    {
        Boolean _textEntered = false;
        string response = "";

        while (_textEntered == false)
        {
            Console.Write(displaytext);
            try
            {
                response = Console.ReadLine();
                if (response == "")
                {
                    _textEntered = false;
                }
                else
                {
                    _textEntered = true;
                }
            }
            catch
            {
                 _textEntered = false;
            }
        }
        return response;
    }
    public static void SaveGoal()
    {
        string path = @"Goals.txt";
        using (StreamWriter sw = File.AppendText(path))
        {
            foreach (Simple goal in _simpleGoals)
            {
                sw.WriteLine(goal.GetGoalType() + "|" + goal.GetGoalIdentity() + "|" + goal.GetTitle() + "|" + goal.GetDescription() + "|" + goal.GetValue() + "|" + goal.GetStatus());
            }
            foreach (Eternal goal in _eternalGoals)
            {
                sw.WriteLine(goal.GetGoalType() + "|" + goal.GetGoalIdentity() + "|" + goal.GetTitle() + "|" + goal.GetDescription() + "|" + goal.GetValue() + "|" + goal.GetStatus());
            }
            foreach (CheckList goal in _checkListGoals)
            {
                sw.WriteLine(goal.GetGoalType() + "|" + goal.GetGoalIdentity() + "|" + goal.GetTitle() + "|" + goal.GetDescription() + "|" + goal.GetValue() + "|" + goal.GetStatus() + "|" + goal.GetNumberOFEvents() + "|" + goal.GetBonusAtCompletion());
            }
            foreach (Daily goal in _dailyGoals)
            {
                sw.WriteLine(goal.GetGoalType() + "|" + goal.GetGoalIdentity() + "|" + goal.GetTitle() + "|" + goal.GetDescription() + "|" + goal.GetValue() + "|" + goal.GetStatus() + "|" + goal.GetStartDate() + "|" + goal.GetEndDate() + "|" + goal.GetPenaltyPoints());
            }
        }	
    }
    public static void ClearFile()
    {
        string path = @"Goals.txt";
         File.WriteAllText(path, String.Empty);
    }
    public static void LoadGoals()
    {
        try
        {
            _simpleGoals.Clear();
            _eternalGoals.Clear();
            _checkListGoals.Clear();
            _dailyGoals.Clear();

            _goalsListMenue.Clear();

            int _addedItems = 0;

            string[] entrylines = System.IO.File.ReadAllLines("Goals.txt");
            foreach (string line in entrylines)
            {
                string[] columns = line.Split("|");

                string _goalType = columns[0];
                string _goalIdentify = columns[1];
                string _title = columns[2];
                string _description = columns[3];
                int _value = int.Parse(columns[4]);
                string _status = columns[5];

                int _numberOfEvents = 0;
                int _bonusAtCompletion = 0;

                DateTime _startDate;
                DateTime _endDate;
                int _penaltyPoints;

                if(line.StartsWith("Simple"))
                {
                    _simpleGoals.Add(new Simple(_goalType,_value,_title,_description,_status,_goalIdentify));
                    
                    if(_status != "Completed")
                    {
                        _addedItems = _addedItems + 1;
                        _goalsListMenue.Add(new Menue(_addedItems,_title,_goalIdentify));
                    }
                }
                else if(line.StartsWith("Eternal"))
                {
                    _eternalGoals.Add(new Eternal(_goalType,_value,_title,_description,_status,_goalIdentify));
                    
                    if(_status != "Completed")
                    {
                        _addedItems = _addedItems + 1;
                        _goalsListMenue.Add(new Menue(_addedItems,_title,_goalIdentify));
                    }
                }
                else if(line.StartsWith("Check List"))
                {
                    _numberOfEvents = int.Parse(columns[6]);
                    _bonusAtCompletion  = int.Parse(columns[7]);
                    _checkListGoals.Add(new CheckList(_goalType,_value,_title,_description,_status,_goalIdentify,_numberOfEvents,_bonusAtCompletion));
                    
                    if(_status != "Completed")
                    {
                        _addedItems = _addedItems + 1;
                        _goalsListMenue.Add(new Menue(_addedItems,_title,_goalIdentify));
                    }
                }
                else if(line.StartsWith("Daily"))
                {
                    _startDate = DateTime.Parse(columns[6]);
                    _endDate  = DateTime.Parse(columns[7]);
                    _penaltyPoints  = int.Parse(columns[8]);
                    _dailyGoals.Add(new Daily(_goalType,_value,_title,_description,_status,_goalIdentify,_startDate,_endDate,_penaltyPoints));
                    
                    if(_status != "Completed")
                    {
                        _addedItems = _addedItems + 1;
                        _goalsListMenue.Add(new Menue(_addedItems,_title,_goalIdentify));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something wrong : " + ex.Message);
        }  
        //Console.WriteLine("All Goals Loaded");  
    }

    public static void ListGoals()
    {
        int count = 1;
        foreach (Simple goal in _simpleGoals)
        {
            goal.DisplayGoal(count);
            count = count + 1;
        }
        foreach (Eternal goal in _eternalGoals)
        {
            goal.DisplayGoal(count);
            count = count + 1;
        }
        foreach (CheckList goal in _checkListGoals)
        {
            goal.DisplayGoal(count);
            count = count + 1;
        }
        foreach (Daily goal in _dailyGoals)
        {
            goal.DisplayGoal(count);
            count = count + 1;
        }
        Console.WriteLine("All Goals Listed");
    }
    public static void SaveEvent()
    {
        DateTime transdate = DateTime.Now;
        string path = @"Events.txt";
        using (StreamWriter sw = File.AppendText(path))
        {
            if(identify.StartsWith("Daily"))
            {
                transdate = DateTime.Parse(getEnteredString("Enter the date of the day you did the goal (e.g. YYYY/mm/dd) ="));
            }
            sw.WriteLine(identify + "|" + transdate);
        }	
        Console.WriteLine("Saved Event");
    }

    public static void updateGoalsStatus()
    {
        foreach (Simple goal in _simpleGoals)
        {
            if(goal.getEventsCount() > 0)
            {
                goal.SetStatus("Completed");
            }
        }
        foreach (CheckList goal in _checkListGoals)
        {
            if(goal.getEventsCount() >= goal.GetNumberOFEvents())
            {
                goal.SetStatus("Completed");
            }
        }
        foreach (Daily goal in _dailyGoals)
        {
            if(goal.GetEndDate() < DateTime.Now)
            {
                goal.SetStatus("Completed");
            }
        }
    }

    public static int getPoints()
    {
        int points = 0;

        foreach (Simple goal in _simpleGoals)
        {
            if(goal.GetStatus() == "Completed")
            {
                points = points + goal.GetValue();
            }
        }
        foreach (Eternal goal in _eternalGoals)
        {
            points = points + (goal.getEventsCount() * goal.GetValue());
        }
        foreach (CheckList goal in _checkListGoals)
        {
            points = points + (goal.getEventsCount() * goal.GetValue());
            if(goal.GetStatus() == "Completed")
            {
                points = points + goal.GetBonusAtCompletion();
            }
        }
        foreach (Daily goal in _dailyGoals)
        {
            DateTime thedate = goal.GetStartDate();
            DateTime enddate = goal.GetEndDate();
            while(thedate <= enddate)
            {
                if(thedate <= DateTime.Now)
                {
                    if(CheckEvent(goal.GetGoalIdentity(),thedate) == true)
                    {
                        points = points + goal.GetValue();
                    }
                    else
                    {
                        points = points - goal.GetPenaltyPoints();
                    }
                }
                thedate = thedate.AddDays(1);
                //Console.WriteLine(thedate);
            }
        }
        return points;
    }
    public static Boolean CheckEvent(string identity,DateTime transdate)
    {
        Boolean bol = false;
        string ide = "";
        DateTime dat;
        string[] entrylines = System.IO.File.ReadAllLines("Events.txt");
        foreach (string line in entrylines)
        {
            string[] columns = line.Split("|");
            ide = columns[0];
            dat = DateTime.Parse(columns[1]);
            if(ide == identity)
            {
                if(dat == transdate)
                {
                    bol = true;
                }
            }
        }
        return bol;
    }
}