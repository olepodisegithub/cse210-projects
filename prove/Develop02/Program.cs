using System;

class Program
{

    //Comments on what i did to exceed the requirements
    //1. I ensured that when someone what to load or quit the program, 
    //   the system should check if there is any new entries that have been 
    //   written but have not been saved yet. Then the system will give the user 
    //   a prompt for them to know and make a decision. This was to ensure that users 
    //   do not loss the entries forgetting that they have not saved them.

    //2. When a user write a new entry, load journal, save journal and quit the program,
    //   there is always a question asked to confirm if the user what to proceed with the 
    //   chosen action.
    //   This was to make sure that user do not make mistakes by doing actions they would 
    //   have not wanted to do at that time.

    public static List<Menu> _menuItems = new List<Menu>();
    public static List<Prompts> _promptList = new List<Prompts>();
    public static Journal _journal = new Journal();
    static int _selectedMenuNumber = 0;
    static Boolean quit = false;
    static String _entryStatus = "";

    static String _lastLoadedFileName = "";
    static void Main(string[] args)
    {

        SetupProgram();

        Console.Write("");
        Console.WriteLine("Welcome to Oats Journal Program");

        Console.Write("");

        while (quit == false)
        {
            //display the menu items
            DisplayMenuItems();

            //check which menu item have been selected
            if (_selectedMenuNumber == 1)
            {
                Boolean _writeEntry = true;
                String _prompt = "";
                String _response = "";
                while (_writeEntry == true)
                {
                    
                    Console.WriteLine("");
                    
                    //display random prompt and get the response
                    _prompt = getRandomPrompt();
                    Console.WriteLine($"PROMPT: {_prompt}");
                    if (getEnteredResponse("Write new journal entry for this prompt (yes or no)?:").ToLower() == "yes")
                    {
                        
                       _response = getEnteredResponse("Enter you response:");

                        Entry _newEntry = new Entry();
                        _newEntry._date = DateTime.Now.ToShortDateString();
                        _newEntry._promptDescription = _prompt;   
                        _newEntry._response = _response;         
                        _journal._entries.Add(_newEntry);
                        Console.WriteLine("##### Journal entry written ####");
                        _entryStatus = "To Save";
                    }
                    else
                    {
                        _writeEntry = false;
                    }
                }
                Console.WriteLine("");
                _journal.DisplayJournal();
            }
            else if (_selectedMenuNumber == 2)
            {
                Console.WriteLine("");
                DisplayLastLoadedFileName();
                 if ( _entryStatus == "To Save" || _lastLoadedFileName != "")
                {
                    if (getEnteredResponse("Save the journal entries (yes or no)?:").ToLower() == "yes")
                    {
                        //get file name and save the journal
                        _journal._fileLocation = getEnteredResponse("Enter file name to save to (like Journal.txt)?:");
                        _journal.SaveJournal();
                        _entryStatus = "";
                    }
                    Console.WriteLine("##### Journal saved ####");
                }
                else
                {
                    Console.WriteLine("##### Nothing to save ####");
                }
            }
            else if (_selectedMenuNumber == 3)
            {
                //display the journal
                Console.WriteLine("");
                DisplayLastLoadedFileName();
                _journal.DisplayJournal();
            }
            else if (_selectedMenuNumber == 4)
            {
                //load journal from a specified file
                Console.WriteLine("");
                DisplayLastLoadedFileName();
                if ( _entryStatus == "To Save")
                {
                    if (getEnteredResponse("There are new journal entries that need to be saved. Proceed to load anyway (yes or no)?:").ToLower() == "yes")
                    {
                        _journal._fileLocation = getEnteredResponse("Enter file name to load from (like Journal.txt)?:");
                        _journal.LoadJournal();
                        _lastLoadedFileName = _journal._fileLocation;
                    }
                }
                else
                {
                    _journal._fileLocation = getEnteredResponse("Enter file name to load from (like Journal.txt)?:");
                    _journal.LoadJournal();
                    _lastLoadedFileName = _journal._fileLocation;
                }
                Console.WriteLine("##### Journal loaded ####");
            }
            else if (_selectedMenuNumber == 5)
            {
                //quit
                Console.WriteLine("");
                if ( _entryStatus == "To Save")
                {
                    if (getEnteredResponse("New Journal Entries not saved. Quit anyway (yes or no)?:").ToLower() == "yes")
                    {
                        quit = true;
                    }
                }
                else
                {
                    if (getEnteredResponse("Quit the program (yes or no)?:").ToLower() == "yes")
                    {
                        quit = true;
                    }
                }
            }
        }
    }

    public static void DisplayLastLoadedFileName()
    {
        if (_lastLoadedFileName != "")
        {
             Console.WriteLine($"The last loaded journal file name is ({_lastLoadedFileName})");
        }
    }

    public static void SetupProgram()
    {
        //start setup
       
       //menu item
        Menu _newItem = new Menu();
        _newItem._itemNumber = 1;
        _newItem._item = "Write Journal Entry";             
        _menuItems.Add(_newItem);

        _newItem = new Menu();
        _newItem._itemNumber = 2;
        _newItem._item = "Save Journal Entry";             
        _menuItems.Add(_newItem);

         _newItem = new Menu();
        _newItem._itemNumber = 3;
        _newItem._item = "Display Journal Entries";             
        _menuItems.Add(_newItem);

         _newItem = new Menu();
        _newItem._itemNumber = 4;
        _newItem._item = "Load Journal Entries";             
        _menuItems.Add(_newItem);

         _newItem = new Menu();
        _newItem._itemNumber = 5;
        _newItem._item = "Quit Program";             
        _menuItems.Add(_newItem);

        //prompts
         Prompts _newPrompt = new Prompts();
        _newPrompt._description = "Who was the most interesting person I interacted with today?";         
        _promptList.Add(_newPrompt);

        _newPrompt = new Prompts();
        _newPrompt._description = "What was the best part of my day?";         
        _promptList.Add(_newPrompt);

        _newPrompt = new Prompts();
        _newPrompt._description = "How did I see the hand of the Lord in my life today?";         
        _promptList.Add(_newPrompt);

        _newPrompt = new Prompts();
        _newPrompt._description = "What was the strongest emotion I felt today?";         
        _promptList.Add(_newPrompt);

        _newPrompt = new Prompts();
        _newPrompt._description = "If I had one thing I could do over today, what would it be?";         
        _promptList.Add(_newPrompt);

        //end setup       
    }

    static String getRandomPrompt()
    {
        var rnd = new Random();
        int index = rnd.Next(_promptList.Count);
        return _promptList[index]._description;
    }

    public static void DisplayMenuItems()
    {
        foreach (Menu item in _menuItems)
        {
            item.DisplayItem();
        }
        _selectedMenuNumber = getSelectedMenuNumber(_menuItems.Count);
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

    static String getEnteredResponse(string displaytext)
    {
        Boolean _responseEntered = false;
        String _response = "";

        while (_responseEntered == false)
        {
            Console.Write($"{displaytext}");
            _response = Console.ReadLine();
            if (_response == "")
            {
                _responseEntered = false;
            }
            else
            {
                _responseEntered = true;
            }   
        }
        return _response;
    }
}