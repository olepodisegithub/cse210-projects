public class Menu
{
    public String _item = "";
    public int _itemNumber = 0;
  
    public void DisplayItem()
    {
        Console.WriteLine($"{_itemNumber}. {_item}");
    }  
}