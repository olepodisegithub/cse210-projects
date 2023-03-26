using System;

class Program
{
    private static List<Menue> _menueItems = new List<Menue>();
    private static int _selectedMainMenuNumber = 0;
    static void Main(string[] args)
    {
        Console.WriteLine("File Manager App!");
        SetupProgram();
        DisplayMenue("Main");
    }

    public static void SetupProgram()
    {
        _menueItems.Add(new Menue(1,"Create Sub Folders","1"));
        _menueItems.Add(new Menue(2,"Check File Validity","2"));
        _menueItems.Add(new Menue(3,"Set File Structure","3"));
        _menueItems.Add(new Menue(4,"Quit","4"));
        
    }

    public static void DisplayMenue(string whichmenue)
    {
        Console.WriteLine("");
        
        if(whichmenue == "Main")
        {
            Console.WriteLine("");
            Console.WriteLine($"Menue Options:");
            foreach (Menue item in _menueItems)
            {
                item.DisplayItem();
            }
            _selectedMainMenuNumber = getSelectedMenuNumber(_menueItems.Count());
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

}