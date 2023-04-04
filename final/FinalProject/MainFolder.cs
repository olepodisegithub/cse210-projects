class MainFolder : Folder
{
    public static List<Files> fileList = new List<Files>();
    public static List<SubFolder> subs = new List<SubFolder>();
    private string archivesAllowed;
    private string documentsAllowed;
    private string imagesAllowed;
    private string moviesAllowed;
    private string musicAllowed;
    private string programsAllowed;

    public string GetArchivesAllowed()
    {
        return archivesAllowed;
    }
    public string GetDocsAllowed()
    {
        return documentsAllowed;
    }
    public string GetImagesAllowed()
    {
        return imagesAllowed;
    }
    public string GetMoviesAllowed()
    {
        return moviesAllowed;
    }
    public string GetMusicAllowed()
    {
        return musicAllowed;
    }
    public string GetProgramsAllowed()
    {
        return programsAllowed;
    }

    public MainFolder(int foldernumber,string name,string location,string archives,string docs,string images,string movies,string music,string programs) : base(foldernumber,name,location)
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
        Console.WriteLine(GetFolderNumber() + ". " + GetFolderName() + " @ " + GetFolderLocation() + ", Ach=" + GetArchivesAllowed() + ",Doc=" + GetDocsAllowed() + ",Ima=" + GetImagesAllowed() + ",Mov=" + GetMoviesAllowed() + ",Mus=" + GetMusicAllowed() + ",Pro=" + GetProgramsAllowed());
    }
    public void CheckValidations(int itemnumber,List<SubFolder> allowedSubs)
    {
        //files extensions
        Boolean fileallowed = false;
        fileList.Clear();

        int count = 0;
        string[] files = Directory.GetFiles(@GetFolderLocation());
        foreach (var file in files)
        {
            count = count + 1;
            string[] columns = file.Split(".");
            string filelocationandname = columns[0];
            string fileextension = columns[1];
            string[] foldsplit = filelocationandname.Split(@"\");
            string filename = foldsplit[foldsplit.Length-1];
            fileList.Add(new Files(filename,fileextension));
        }

        Console.WriteLine("");
        Console.WriteLine(itemnumber + ". Files not allowed in " + GetFolderLocation() + " from " + count);
        foreach (Files f in fileList)
        {
            if (f.GetFileExtension().ToLower() != "ini")
            {
                fileallowed = false;
                if (f.getFileTypeID() == 1)
                {
                    if (archivesAllowed == "yes")
                    {
                        fileallowed = true;
                    }
                }
                else if (f.getFileTypeID() == 2)
                {
                    if (documentsAllowed == "yes")
                    {
                        fileallowed = true;
                    }
                }
                else if (f.getFileTypeID() == 3)
                {
                    if (musicAllowed == "yes")
                    {
                        fileallowed = true;
                    }
                }
                else if (f.getFileTypeID() == 4)
                {
                    if (programsAllowed == "yes")
                    {
                        fileallowed = true;
                    }
                }
                else if (f.getFileTypeID() == 5)
                {
                    if (moviesAllowed == "yes")
                    {
                        fileallowed = true;
                    }
                }
                else if (f.getFileTypeID() == 6)
                {
                    if (imagesAllowed == "yes")
                    {
                        fileallowed = true;
                    }
                }
                else
                {
                    fileallowed = false;
                }

                if (fileallowed == false)
                {
                    Console.WriteLine("   " + f.GetFileName() + "." + f.GetFileExtension());
                }
            }
        }

        //check folders
        subs.Clear();

        int foldercount = 0;
        string[] dirs = Directory.GetDirectories(@GetFolderLocation());
        foreach (string dir in dirs)
        {
            foldercount = foldercount + 1;
            string[] foldsplit = dir.Split(@"\");
            string foldername = foldsplit[foldsplit.Length-1];
            
            subs.Add(new SubFolder(foldercount,foldername,GetFolderLocation(),GetFolderNumber()));
        }

        Console.WriteLine("");
        Console.WriteLine(itemnumber + ". Folders not allowed in " + GetFolderLocation() + " from " + foldercount);
        Boolean foldercorrect = false;
        foreach (SubFolder sf in subs)
        {
            foldercorrect = false;
            foreach (SubFolder subs in allowedSubs)
            {
                if ((sf.GetFolderName().ToLower() == subs.GetFolderName().ToLower()) && (sf.GetMainFolderNumber() == subs.GetMainFolderNumber()))
                {
                    foldercorrect = true;
                }
            }

            if (foldercorrect == false)
            {
                Console.WriteLine("   " + sf.GetFolderName());
            }
        }
    }
}