using System;

class Program
{
    static Boolean quit = false;
    private static int _selectedMenueNumber = 0;
    private static List<Menue> _menueItems = new List<Menue>();
    private static BreathingActivity _breath = new BreathingActivity(
        "in",
        5,
        5,
        "Breathing Activity",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
        "Get ready..",
        0);
    private static ReflectionActivity _reflect = new ReflectionActivity(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
        "Get ready..",
        2);
    private static ListingActivity _list = new ListingActivity(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
        "Get ready..",
        2);
    static void Main(string[] args)
    {
        SetupProgram();
        while (quit == false)
        {
            Console.Clear();
            DisplayMenue();

            //check which menu item have been selected
            if (_selectedMenueNumber == 1)
            {
                Console.Clear();
                _breath.Breath();
            }
            else if (_selectedMenueNumber == 2)
            {
                Console.Clear();
                _reflect.Reflect();
            }
            else if (_selectedMenueNumber == 3)
            {
                Console.Clear();
                _list.List();
            }
            else if (_selectedMenueNumber == 4)
            {
                Environment. Exit(0);
            }

            //Console.WriteLine();
            //Console.WriteLine("Click enter to proceed.");
            //Console.ReadLine();
        }
    }

    public static void SetupProgram()
    {
        _menueItems.Add(new Menue(1,"Start breathing activity"));
        _menueItems.Add(new Menue(2,"Start reflecting activity"));
        _menueItems.Add(new Menue(3,"Start listing activity"));
        _menueItems.Add(new Menue(4,"Quit"));
    }

    public static void DisplayMenue()
    {
        Console.WriteLine($"Menue Options:");
        foreach (Menue item in _menueItems)
        {
            item.DisplayItem();
        }
        _selectedMenueNumber = getSelectedMenuNumber(4);
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
}