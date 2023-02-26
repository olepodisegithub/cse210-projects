public class ListedItems
{
    private String _itemDescription = "";

     public ListedItems(string descript)
    {
        _itemDescription = descript;
    }
    public void DisplayPrompt()
    {
        Console.WriteLine($"{_itemDescription}");
    }

}