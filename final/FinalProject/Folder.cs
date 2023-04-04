abstract class Folder
{
    private String _folderName = "";
    private String _folderLocation = "";
    private int _folderNumber = 0;

    public Folder(int number,string name,string location)
    {
        _folderNumber = number;
        _folderName = name;
        _folderLocation = location;
    }
    public int GetFolderNumber()
    {
        return _folderNumber;
    }
    public string GetFolderName()
    {
        return _folderName;
    }
    public void SetFolderName(string name)
    {
        _folderName = name;
    }
    public string GetFolderLocation()
    {
        return _folderLocation;
    }
    public void SetFolderLocation(string location)
    {
        _folderLocation = location;
    }

    public abstract void DisplayFolderDetails();
    
}