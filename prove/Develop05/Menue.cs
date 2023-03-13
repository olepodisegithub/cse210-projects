public class Menue
{
    private String _menueDescription = "";
    private int _itemNumber = 0;
    private string _uniqueIdentify = "";
  
   public Menue(int number,string descript,string identify)
    {
        _menueDescription= descript;
        _itemNumber = number;
        _uniqueIdentify = identify;
    }

    public void DisplayItem()
    {
        Console.WriteLine($"  {_itemNumber}. {_menueDescription}");
    }  

    public string GetIdentify()
    {
        return _uniqueIdentify;
    }

    public int GetItemNumber()
    {
        return _itemNumber;
    }
}