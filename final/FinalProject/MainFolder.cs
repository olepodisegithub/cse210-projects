class MainFolder : Folder
{
    public static List<Files> _fileList = new List<Files>();
    public static List<SubFolder> _subs = new List<SubFolder>();
    private string _archivesAllowed;
    private string _documentsAllowed;
    private string _imagesAllowed;
    private string _moviesAllowed;
    private string _musicAllowed;
    private string _programsAllowed;

    public string GetArchivesAllowed()
    {
        return _archivesAllowed;
    }
    public string GetDocsAllowed()
    {
        return _documentsAllowed;
    }
    public string GetImagesAllowed()
    {
        return _imagesAllowed;
    }
    public string GetMoviesAllowed()
    {
        return _moviesAllowed;
    }
    public string GetMusicAllowed()
    {
        return _musicAllowed;
    }
    public string GetProgramsAllowed()
    {
        return _programsAllowed;
    }

    public MainFolder(int folderNumber,string name,string location,string archives,string docs,string images,string movies,string music,string programs) : base(folderNumber,name,location)
    {
        _archivesAllowed = archives;
        _documentsAllowed = docs;
        _imagesAllowed = images;
        _moviesAllowed = movies;
        _musicAllowed = music;
        _programsAllowed = programs;
    }
    
    public override void DisplayFolderDetails()
    {
        Console.WriteLine(GetFolderNumber() + ". " + GetFolderName() + " @ " + GetFolderLocation() + ", Ach=" + GetArchivesAllowed() + ",Doc=" + GetDocsAllowed() + ",Ima=" + GetImagesAllowed() + ",Mov=" + GetMoviesAllowed() + ",Mus=" + GetMusicAllowed() + ",Pro=" + GetProgramsAllowed());
    }
    public void CheckValidations(int itemnumber,List<SubFolder> allowedSubs)
    {
        try
        {
            //files extensions
            Boolean fileAllowed = false;
            _fileList.Clear();

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
                _fileList.Add(new Files(filename,fileextension));
            }

            Console.WriteLine("");
            Console.WriteLine(itemnumber + ". Files not allowed in " + GetFolderLocation() + " from " + count);
            foreach (Files f in _fileList)
            {
                if (f.GetFileExtension().ToLower() != "ini")
                {
                    fileAllowed = false;
                    if (f.getFileTypeID() == 1)
                    {
                        if (_archivesAllowed == "yes")
                        {
                            fileAllowed = true;
                        }
                    }
                    else if (f.getFileTypeID() == 2)
                    {
                        if (_documentsAllowed == "yes")
                        {
                            fileAllowed = true;
                        }
                    }
                    else if (f.getFileTypeID() == 3)
                    {
                        if (_musicAllowed == "yes")
                        {
                            fileAllowed = true;
                        }
                    }
                    else if (f.getFileTypeID() == 4)
                    {
                        if (_programsAllowed == "yes")
                        {
                            fileAllowed = true;
                        }
                    }
                    else if (f.getFileTypeID() == 5)
                    {
                        if (_moviesAllowed == "yes")
                        {
                            fileAllowed = true;
                        }
                    }
                    else if (f.getFileTypeID() == 6)
                    {
                        if (_imagesAllowed == "yes")
                        {
                            fileAllowed = true;
                        }
                    }
                    else
                    {
                        fileAllowed = false;
                    }

                    if (fileAllowed == false)
                    {
                        Console.WriteLine("   " + f.GetFileName() + "." + f.GetFileExtension());
                    }
                }
            }

            //check folders
            _subs.Clear();

            int folderCount = 0;
            string[] dirs = Directory.GetDirectories(@GetFolderLocation());
            foreach (string dir in dirs)
            {
                folderCount = folderCount + 1;
                string[] foldsplit = dir.Split(@"\");
                string foldername = foldsplit[foldsplit.Length-1];
                
                _subs.Add(new SubFolder(folderCount,foldername,GetFolderLocation(),GetFolderNumber()));
            }

            Console.WriteLine("");
            Console.WriteLine(itemnumber + ". Folders not allowed in " + GetFolderLocation() + " from " + folderCount);
            Boolean folderCorrect = false;
            foreach (SubFolder sf in _subs)
            {
                folderCorrect = false;
                foreach (SubFolder subs in allowedSubs)
                {
                    if ((sf.GetFolderName().ToLower() == subs.GetFolderName().ToLower()) && (sf.GetMainFolderNumber() == subs.GetMainFolderNumber()))
                    {
                        folderCorrect = true;
                    }
                }

                if (folderCorrect == false)
                {
                    Console.WriteLine("   " + sf.GetFolderName());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception Message:", ex.Message);
            Console.WriteLine("Exception source:", ex.Source);
        }
    }
}