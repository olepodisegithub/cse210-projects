public class Menue
{
    private String _menueDescription = "";
    private int _itemNumber = 0;
  
   public Menue(int number,string descript)
    {
        _menueDescription= descript;
        _itemNumber = number;
    }

    public void DisplayItem()
    {
        Console.WriteLine($"  {_itemNumber}. {_menueDescription}");
    }  
}