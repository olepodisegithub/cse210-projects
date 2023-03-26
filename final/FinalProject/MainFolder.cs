class MainFolder : Folder
{
    private int _fileStayDuration = 0;
    private static List<SubFolder> _allowedSubs = new List<SubFolder>();
    private static List<Files> fileList = new List<Files>();
    private static List<SubFolder> subs = new List<SubFolder>();
    public static Boolean archivesAllowed;
    public static Boolean documentsAllowed;
    public static Boolean imagesAllowed;
    public static Boolean moviesAllowed;
    public static Boolean musicAllowed;
    public static Boolean programsAllowed;
    public MainFolder(string name,string location,Boolean archives,Boolean docs,Boolean images,Boolean movies,Boolean music,Boolean programs) : base(name,location)
    {
        archivesAllowed = archives;
        documentsAllowed = docs;
        imagesAllowed = images;
        moviesAllowed = movies;
        musicAllowed = music;
        programsAllowed = programs;
    }

    public override void DisplayFolderDetails()
    {
        
    }
    public override void SaveFolder()
    {
        
    }
    public void CheckValidations()
    {
        
    }
    public void MoveFiles()
    {
        
    }

    public int GetFileStayDuration()
    {
        return _fileStayDuration;
    }
    public void SetFileStayDuration(int duration)
    {
        _fileStayDuration = duration;
    }
}