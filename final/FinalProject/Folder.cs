abstract class Folder
{
    private String _folderName = "";
    private String _folderLocation = "";

    public Folder(string name,string location)
    {
        _folderName = name;
        _folderLocation = location;
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
    
    public abstract void SaveFolder();
}