public class FileType
{
    public FileType(int num,string name,int typeId)
    {
       _number = num;
       _extension = name;
       filetypeid = typeId;
    }
    private int _number = 0;
    private String _extension = "";
    private int filetypeid = 0;

    public string GetExtension()
    {
        return _extension;
    }

    public void SetExtension(string extension)
    {
        _extension =  extension;
    }

    public int GetExtensionNumber()
    {
        return _number;
    }

    public int GetFileTypeID()
    {
        return filetypeid;
    }

    public void DisplaExtension(int count)
    {
        Console.WriteLine("   " + count + ". " + _extension);
    }
}