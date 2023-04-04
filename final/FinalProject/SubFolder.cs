class SubFolder : Folder
{
     private int _mainFolderNumber = 0;
    public SubFolder(int foldernumber,string name,string location,int mainfoldernumber) : base(foldernumber,name,location)
    {
       _mainFolderNumber = mainfoldernumber;
    }
    public override void DisplayFolderDetails()
    {
        Console.WriteLine(GetFolderName() + " @ " + GetFolderLocation());
    }
    public int GetMainFolderNumber()
    {
        return _mainFolderNumber;
    }
}