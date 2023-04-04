using System;

class Program
{
    private static List<Menue> _menueItems = new List<Menue>();
    private static List<MainFolder> _mainFolders = new List<MainFolder>();
    public static List<SubFolder> _allowedSubs = new List<SubFolder>();
    private static List<Menue> _foldersMenue = new List<Menue>();
    private static List<Menue> _subFoldersMenue = new List<Menue>();
    private static List<Menue> _fileTypeMenue = new List<Menue>();
    private static List<Menue> _extensionsMenue = new List<Menue>();
    private static int _selectedMainMenuNumber = 0;
    private static int _selectedFolderMenuNumber = 0;
    private static int _selectedSubFolderMenuNumber = 0;
    private static int _selectedFolderNumber = 0;
    private static int _selectedSubFolderNumber = 0;
    private static int _selectedFileTypeNumber = 0;
    private static int _selectedExtensionNumber = 0;
    private static int _selectedFileTypeID = 0;
    private static Boolean quit = false;
    private static List<Archives> _archiveExtensions = new List<Archives>();
    private static List<Documents> _documentExtensions = new List<Documents>();
    private static List<Music> _musicExtensions = new List<Music>();
    private static List<Movies> _movieExtensions = new List<Movies>();
    private static List<Programs> _programExtensions = new List<Programs>();
    private static List<Images> _imageExtensions = new List<Images>();
    static void Main(string[] args)
    {
        Console.WriteLine("File Manager App!");
        SetupProgram();
        FilingReport();

        while (quit == false)
        {
            DisplayMenue("Main");

            //check which menu item have been selected
            if (_selectedMainMenuNumber == 1)
            {
                //Add Main Folder
                ViewMainFolders();
                AddMainFolder();
                LoadMainFolders();
            }
            else if (_selectedMainMenuNumber == 2)
            {
                //view main folders
                ViewMainFolders();
                pauseProgram("Press enter to proceed!");
            }
            else if (_selectedMainMenuNumber == 3)
            {
                //remove Main Folder
                DisplayMenue("Folders");
                if (getYesOrNo("Are you sure to remove " + GetFolderNameByFolderNumber(_selectedFolderNumber) + " folder ? (yes/no)") == "yes")
                {
                    RemoveMainFolder(_selectedFolderNumber);
                    LoadMainFolders();
                }
            }
            else if (_selectedMainMenuNumber == 4)
            {
                // set sub folders
                DisplayMenue("Folders");
                AddSubFolder(_selectedFolderNumber);
                LoadMainFolders();
            }
            else if (_selectedMainMenuNumber == 5)
            {
                //View Sub Folders
                DisplayMenue("Folders");
                ViewSubFolders(_selectedFolderNumber);
                pauseProgram("Press enter to proceed!");
            }
            else if (_selectedMainMenuNumber == 6)
            {
                //Delete Sub Folder
                DisplayMenue("Folders");
                DisplayMenue("Sub Folders");
                RemoveSubFolder(_selectedSubFolderNumber);
                LoadSubFoldersToMainFolder();
                pauseProgram("Done removing sub folder. Press enter to proceed!");
            }
            else if (_selectedMainMenuNumber == 7)
            {
                // set file extensions
                DisplayMenue("File Types");
                foreach (Menue m in _fileTypeMenue)
                {
                    if (m.GetItemNumber() == _selectedFileTypeNumber)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Add file extension for " + m.GetMenueDesciption());
                    }
                }
                AddFileExtension(_selectedFileTypeNumber);
                LoadExtensions();
            }
            else if (_selectedMainMenuNumber == 8)
            {
                //View file extensions
                LoadExtensions();
                ViewFileExtensions();
                pauseProgram("Press enter to proceed!");
            }
            else if (_selectedMainMenuNumber == 9)
            {
                //remove extension
                DisplayMenue("File Types");
                foreach (Menue m in _fileTypeMenue)
                {
                    if (m.GetItemNumber() == _selectedFileTypeNumber)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Remove file extension from " + m.GetMenueDesciption());
                    }
                }
                DisplayMenue("File Extensions");
                RemoveFileExtension(_selectedFileTypeID,_selectedExtensionNumber);
                LoadExtensions();
                pauseProgram("Done removing extension. Press enter to proceed!");
            }
            else if (_selectedMainMenuNumber == 10)
            {
                //Check Filing Report
                FilingReport();
            }
            else if (_selectedMainMenuNumber == 11)
            {
                //Quit
                System.Environment.Exit(0); 
            }
        }
    }

    public static void FilingReport()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("Report on files in your main folders");
        int count = 0;
        foreach (MainFolder f in _mainFolders)
        {
            count = count + 1;
            f.CheckValidations(count,_allowedSubs);
        }
        pauseProgram("Press enter to proceed!");
    }
    public static void SetupProgram()
    {
        _menueItems.Add(new Menue(1,"Add Main Folder","1"));
        _menueItems.Add(new Menue(2,"View Main Folders","2"));
        _menueItems.Add(new Menue(3,"Remove Main Folder from file","3"));
        _menueItems.Add(new Menue(4,"Set Sub Folder","4"));
        _menueItems.Add(new Menue(5,"View Sub Folders","5"));
        _menueItems.Add(new Menue(6,"Remove Sub Folder from file","6"));
        _menueItems.Add(new Menue(7,"Set file extension","7"));
        _menueItems.Add(new Menue(8,"View file extensions","8"));
        _menueItems.Add(new Menue(9,"Remove file extension","9"));
        _menueItems.Add(new Menue(10,"Check Filing Report","10"));
        _menueItems.Add(new Menue(11,"Quit","11"));  

        LoadMainFolders();
        SetFileTypesMenu();
    }

    public static void RemoveMainFolder(int foldernumber)
    {
        //clear main folder file
        string clearpath = @"MainFolders.txt";
        File.WriteAllText(clearpath, String.Empty);

        //save to the file after clearing
        string path = @"MainFolders.txt";
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("MainFolderNumber=FolderName=FolderLocation=Achives=Documents=Images=Movies=Music=Programs");
            foreach (MainFolder f in _mainFolders)
            {
                if (f.GetFolderNumber() != foldernumber)
                {
                    //pauseProgram(f.GetFolderNumber() + " : " + f.GetFolderName() + " : " + f.GetFolderLocation() + " : " + f.GetArchivesAllowed() + " : " + f.GetDocsAllowed() + " : " + f.GetImagesAllowed() + " : " + f.GetMoviesAllowed() + " : " + f.GetMusicAllowed() + " : " + f.GetProgramsAllowed());
                    sw.WriteLine(f.GetFolderNumber() + "=" + f.GetFolderName() + "=" + f.GetFolderLocation() + "=" + f.GetArchivesAllowed() + "=" + f.GetDocsAllowed() + "=" + f.GetImagesAllowed() + "=" + f.GetMoviesAllowed() + "=" + f.GetMusicAllowed() + "=" + f.GetProgramsAllowed());
                }
            }
        }

        //clear sub folder file
        string clearsubpath = @"SubFolders.txt";
        File.WriteAllText(clearsubpath, String.Empty);

        //save to the file after clearing
        string subpath = @"SubFolders.txt";
        using (StreamWriter sw = File.AppendText(subpath))
        {
            sw.WriteLine("SubFolderNumber=FolderName=FolderLocation=MainFolderNumber");
            foreach (SubFolder sf in _allowedSubs)
            {
                if (sf.GetMainFolderNumber() != foldernumber)
                {
                    sw.WriteLine(sf.GetFolderNumber() + "=" + sf.GetFolderName() + "=" + sf.GetFolderLocation() + "=" + sf.GetMainFolderNumber());
                }
            }
        }
    }

    public static void RemoveSubFolder(int foldernumber)
    {
        //clear sub folder file
        string clearsubpath = @"SubFolders.txt";
        File.WriteAllText(clearsubpath, String.Empty);

        //save to the file after clearing
        string subpath = @"SubFolders.txt";
        using (StreamWriter sw = File.AppendText(subpath))
        {
            sw.WriteLine("SubFolderNumber=FolderName=FolderLocation=MainFolderNumber");
            foreach (SubFolder sf in _allowedSubs)
            {
                if (sf.GetFolderNumber() != foldernumber)
                {
                    sw.WriteLine(sf.GetFolderNumber() + "=" + sf.GetFolderName() + "=" + sf.GetFolderLocation() + "=" + sf.GetMainFolderNumber());
                }
            }
        }
    }

    public static void RemoveFileExtension(int filetypeid,int extensionnumber)
    {
        //clear sub folder file
        string clearsubpath = @"FileExtensions.txt";
        File.WriteAllText(clearsubpath, String.Empty);

        //save to the file after clearing
        string subpath = @"FileExtensions.txt";
        using (StreamWriter sw = File.AppendText(subpath))
        {
            sw.WriteLine("ExtensionNumber=Name=FileTypeID");
            
            foreach (Archives v in _archiveExtensions)
            {
                if ((v.GetExtensionNumber() == extensionnumber) && (v.GetFileTypeID() == filetypeid))
                {
                    
                }
                else
                {
                    sw.WriteLine(v.GetExtensionNumber() + "=" + v.GetExtension() + "=" + v.GetFileTypeID());
                }
            }

            foreach (Documents v in _documentExtensions)
            {
                if ((v.GetExtensionNumber() == extensionnumber) && (v.GetFileTypeID() == filetypeid))
                {
                    
                }
                else
                {
                    sw.WriteLine(v.GetExtensionNumber() + "=" + v.GetExtension() + "=" + v.GetFileTypeID());
                }
            }

            foreach (Music v in _musicExtensions)
            {
                if ((v.GetExtensionNumber() == extensionnumber) && (v.GetFileTypeID() == filetypeid))
                {
                    
                }
                else
                {
                    sw.WriteLine(v.GetExtensionNumber() + "=" + v.GetExtension() + "=" + v.GetFileTypeID());
                }
            }

            foreach (Images v in _imageExtensions)
            {
                if ((v.GetExtensionNumber() == extensionnumber) && (v.GetFileTypeID() == filetypeid))
                {
                    
                }
                else
                {
                    sw.WriteLine(v.GetExtensionNumber() + "=" + v.GetExtension() + "=" + v.GetFileTypeID());
                }
            }

            foreach (Movies v in _movieExtensions)
            {
                if ((v.GetExtensionNumber() == extensionnumber) && (v.GetFileTypeID() == filetypeid))
                {
                    
                }
                else
                {
                    sw.WriteLine(v.GetExtensionNumber() + "=" + v.GetExtension() + "=" + v.GetFileTypeID());
                }
            }

            foreach (Programs v in _programExtensions)
            {
                if ((v.GetExtensionNumber() == extensionnumber) && (v.GetFileTypeID() == filetypeid))
                {
                    
                }
                else
                {
                    sw.WriteLine(v.GetExtensionNumber() + "=" + v.GetExtension() + "=" + v.GetFileTypeID());
                }
            }
        }
    }

    public static string GetFolderNameByFolderNumber(int foldernumber)
    {
        string response = "";
        foreach (MainFolder folder in _mainFolders)
        {
            if (folder.GetFolderNumber() == foldernumber)
            {
                response = folder.GetFolderName();
            }
        }
        return response;
    }

    public static string GetFolderLocationByFolderNumber(int foldernumber)
    {
        string response = "";
        foreach (MainFolder folder in _mainFolders)
        {
            if (folder.GetFolderNumber() == foldernumber)
            {
                response = folder.GetFolderLocation();
            }
        }
        return response;
    }

    public static void AddMainFolder()
    {
        Console.WriteLine("");

        int _folderNumber = NewMainFolderNumber();
        string _folderName = getEnteredString("Enter Folder Name:");
        string _folderLocation = getEnteredString("Enter Folder Location URL:");
        if (Directory.Exists(@_folderLocation) == true)
        {
            string str = @"\";
            if (_folderLocation.EndsWith(str) == false)
            {
                _folderLocation = _folderLocation + str;
            }
            string AllowArchives = getYesOrNo("Allow archives in this folder (yes/no) ?");
            string AllowDocs = getYesOrNo("Allow documents in this folder (yes/no) ?");
            string AllowImages = getYesOrNo("Allow images in this folder (yes/no) ?");
            string AllowMovies = getYesOrNo("Allow movie files in this folder (yes/no) ?");
            string AllowMusic = getYesOrNo("Allow music files in this folder (yes/no) ?");
            string AllowPrograms = getYesOrNo("Allow other program files in this folder (yes/no) ?");

            string path = @"MainFolders.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                //pauseProgram(f.GetFolderNumber() + " : " + f.GetFolderName() + " : " + f.GetFolderLocation() + " : " + f.GetArchivesAllowed() + " : " + f.GetDocsAllowed() + " : " + f.GetImagesAllowed() + " : " + f.GetMoviesAllowed() + " : " + f.GetMusicAllowed() + " : " + f.GetProgramsAllowed());
                sw.WriteLine(_folderNumber + "=" + _folderName + "=" + _folderLocation + "=" + AllowArchives + "=" + AllowDocs + "=" + AllowImages + "=" + AllowMovies + "=" + AllowMusic + "=" + AllowPrograms);
            }
            pauseProgram("Done adding folder. Press enter to proceed");
        }
        else
        {
            Console.WriteLine("");
            pauseProgram("Folder does not exist. Create the folder or write the correct folder location. Press enter to proceed.");
        }
    }

    public static void AddSubFolder(int mainfoldernumber)
    {
        Console.WriteLine("");

        int _folderNumber = NewSubFolderNumber();
        string _folderName = getEnteredString("Enter Folder Name:");
        string _folderLocation = GetFolderLocationByFolderNumber(mainfoldernumber);
        if (Directory.Exists(@_folderLocation) == true)
        {
            string str = @"\";
            if (_folderLocation.EndsWith(str) == false)
            {
                _folderLocation = _folderLocation + str;
            }
            
            //save to the file after clearing
            string path = @"SubFolders.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(_folderNumber + "=" + _folderName + "=" + _folderLocation + "=" + mainfoldernumber);
            }
            
            pauseProgram("Done adding folder. Press enter to proceed");
        }
        else
        {
            Console.WriteLine("");
            pauseProgram("Main Folder does not exist. Create the folder or write the correct folder location. Press enter to proceed.");
        }
    }

    public static void AddFileExtension(int filetypeid)
    {
        Console.WriteLine("");

        int _extensionNumber = NewExtensionNumber();
        string _extension = getEnteredString("Enter Extension:");
        if (_extension.StartsWith(".") == true)
        {
            _extension = _extension.Replace(".","");
        }
        
        //save to the file after clearing
        string path = @"FileExtensions.txt";
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(_extensionNumber + "=" + _extension + "=" + filetypeid);
        }
        
        pauseProgram("Done adding extension. Press enter to proceed");
    }
    public static int NewMainFolderNumber()
    {
        int num = 0;
        foreach (MainFolder folder in _mainFolders)
        {
            num = folder.GetFolderNumber();
        }
        return num + 1;
    }
    public static int NewSubFolderNumber()
    {
        int num = 0;
        string[] entrylines = System.IO.File.ReadAllLines("SubFolders.txt");
        foreach (string line in entrylines)
        {
            string[] columns = line.Split("=");

            string firsttext = columns[0];
            if (firsttext != "SubFolderNumber")
            {
                num = int.Parse(columns[0]);
            }
        }
        return num + 1;
    }

    public static int NewExtensionNumber()
    {
        int num = 0;
        string[] entrylines = System.IO.File.ReadAllLines("FileExtensions.txt");
        foreach (string line in entrylines)
        {
            string[] columns = line.Split("=");

            string firsttext = columns[0];
            if (firsttext != "ExtensionNumber")
            {
                num = int.Parse(columns[0]);
            }
        }
        return num + 1;
    }
    public static void LoadMainFolders()
    {
        _mainFolders.Clear();

        string[] entrylines = System.IO.File.ReadAllLines("MainFolders.txt");
        foreach (string line in entrylines)
        {
            string[] columns = line.Split("=");

            string firsttext = columns[0];
            if (firsttext != "MainFolderNumber")
            {
                int _folderNumber = int.Parse(columns[0]);
                string _folderName = columns[1];
                string _folderLocation = columns[2];
                string AllowArchives = columns[3];
                string AllowDocs = columns[4];
                string AllowImages = columns[5];
                string AllowMovies = columns[6];
                string AllowMusic = columns[7];
                string AllowPrograms = columns[8];

                //pauseProgram(_folderNumber + " : " + _folderName + " : " + _folderLocation + " : " + AllowArchives + " : " + AllowDocs + " : " + AllowImages + " : " + AllowMovies + " : " + AllowMusic + " : " + AllowPrograms);
                _mainFolders.Add(new MainFolder(_folderNumber,_folderName,_folderLocation,AllowArchives,AllowDocs,AllowImages,AllowMovies,AllowMusic,AllowPrograms));
            }
        }
        LoadSubFoldersToMainFolder();
    }

    public static void LoadSubFoldersToMainFolder()
    {
        _allowedSubs.Clear();

        //get sub folders and load them to the allowed subs variable of each main folder
        string[] entrylines = System.IO.File.ReadAllLines("SubFolders.txt");
        foreach (string line in entrylines)
        {
            string[] columns = line.Split("=");

            string firsttext = columns[0];
            if (firsttext != "SubFolderNumber")
            {
                int _folderNumber = int.Parse(columns[0]);
                string _folderName = columns[1];
                string _folderLocation = columns[2];
                int _mainfoldernumber = int.Parse(columns[3]);

                _allowedSubs.Add(new SubFolder(_folderNumber,_folderName,_folderLocation,_mainfoldernumber));
            }
        }
    }

    public static void LoadExtensions()
    {
        _archiveExtensions.Clear();
        _documentExtensions.Clear();
        _musicExtensions.Clear();
        _movieExtensions.Clear();
        _programExtensions.Clear();
        _imageExtensions.Clear();
        
        //get sub folders and load them to the allowed subs variable of each main folder
        string[] entrylines = System.IO.File.ReadAllLines("FileExtensions.txt");
        foreach (string line in entrylines)
        {
            string[] columns = line.Split("=");

            string firsttext = columns[0];
            if (firsttext != "ExtensionNumber")
            {
                int _extensionNumber = int.Parse(columns[0]);
                string _extension = columns[1];
                int _filetypeid = int.Parse(columns[2]);

                if (_filetypeid == 1)
                {
                   _archiveExtensions.Add(new Archives(_extensionNumber,_extension,_filetypeid));

                }
                if (_filetypeid == 2)
                {
                    _documentExtensions.Add(new Documents(_extensionNumber,_extension,_filetypeid));
                }
                if (_filetypeid == 3)
                {
                    _musicExtensions.Add(new Music(_extensionNumber,_extension,_filetypeid));
                }
                if (_filetypeid == 4)
                {
                    _programExtensions.Add(new Programs(_extensionNumber,_extension,_filetypeid));
                }
                if (_filetypeid == 5)
                {
                    _movieExtensions.Add(new Movies(_extensionNumber,_extension,_filetypeid));
                }
                if (_filetypeid == 6)
                {
                    _imageExtensions.Add(new Images(_extensionNumber,_extension,_filetypeid));
                }
            }
        }
    }
    public static void ViewMainFolders()
    {
        Console.WriteLine("");
        foreach (MainFolder f in _mainFolders)
        {
            f.DisplayFolderDetails();
        }
    }

    public static void ViewSubFolders(int mainfoldernumber)
    {
        Console.WriteLine("");
        Console.WriteLine("******Sub folders from " + GetFolderNameByFolderNumber(mainfoldernumber) + "******");
        
        foreach (SubFolder f in _allowedSubs)
        {
            if (f.GetMainFolderNumber() == mainfoldernumber)
            {
                f.DisplayFolderDetails();
            }
        }
    }

    public static void SetMainFoldersMenu()
    {
        _foldersMenue.Clear();
        int count = 0;
        foreach (MainFolder folder in _mainFolders)
        {
            count = count + 1;
           _foldersMenue.Add(new Menue(count,folder.GetFolderName(),folder.GetFolderNumber().ToString()));
        }
    }

    public static void SetSubFoldersMenu(int mainfoldernumber)
    {
        _subFoldersMenue.Clear();
        int count = 0;
        foreach (SubFolder folder in _allowedSubs)
        {
            if (folder.GetMainFolderNumber() == mainfoldernumber)
            {
                count = count + 1;
                _subFoldersMenue.Add(new Menue(count,folder.GetFolderName(),folder.GetFolderNumber().ToString()));
            }
        }
    }

    public static void SetFileTypesMenu()
    {
        _fileTypeMenue.Clear();
        _fileTypeMenue.Add(new Menue(1,"Archives","1"));
        _fileTypeMenue.Add(new Menue(2,"Documents","2"));
        _fileTypeMenue.Add(new Menue(3,"Music","3"));
        _fileTypeMenue.Add(new Menue(4,"Programs","4"));
        _fileTypeMenue.Add(new Menue(5,"Movies","5"));
        _fileTypeMenue.Add(new Menue(6,"Images","6"));
    }

    public static void SetFileExtensionssMenu(int fileypeid)
    {
        _extensionsMenue.Clear();
        int count = 0;
        if (fileypeid == 1)
        {
            count = 0;
            foreach (Archives v in _archiveExtensions)
            {
                count =count + 1;
                _extensionsMenue.Add(new Menue(count,v.GetExtension(),v.GetFileTypeID().ToString()));
            }
        }
        else if (fileypeid == 2)
        {
            count =0;
            foreach (Documents v in _documentExtensions)
            {
                count = count + 1;
                _extensionsMenue.Add(new Menue(count,v.GetExtension(),v.GetFileTypeID().ToString()));
            }
        }
        else if (fileypeid == 3)
        {
            count =0;
            foreach (Music v in _musicExtensions)
            {
                count = count + 1;
                _extensionsMenue.Add(new Menue(count,v.GetExtension(),v.GetFileTypeID().ToString()));
            }
        }
        else if (fileypeid == 4)
        {
            count =0;
            foreach (Images v in _imageExtensions)
            {
                count = count + 1;
                _extensionsMenue.Add(new Menue(count,v.GetExtension(),v.GetFileTypeID().ToString()));
            }
        }
        else if (fileypeid == 5)
        {
            count =0;
            foreach (Movies v in _movieExtensions)
            {
                count = count + 1;
                _extensionsMenue.Add(new Menue(count,v.GetExtension(),v.GetFileTypeID().ToString()));
            }
        }
        else if (fileypeid == 6)
        {
            count =0;
            foreach (Programs v in _programExtensions)
            {
                count = count + 1;
                _extensionsMenue.Add(new Menue(count,v.GetExtension(),v.GetFileTypeID().ToString()));
            }
        }
    }

    public static void ViewFileExtensions()
    {
        Console.WriteLine("");
        Console.WriteLine("******File Extensions******");
        
        Console.WriteLine("");

        int count =0;
        Console.WriteLine("A. Archives");
        foreach (Archives v in _archiveExtensions)
        {
            count = count + 1;
            v.DisplaExtension(count);
        }

        Console.WriteLine("B. Documents");
        count =0;
        foreach (Documents v in _documentExtensions)
        {
            count = count + 1;
            v.DisplaExtension(count);
        }

        Console.WriteLine("C. Music");
        count =0;
        foreach (Music v in _musicExtensions)
        {
            count = count + 1;
            v.DisplaExtension(count);
        }

        Console.WriteLine("D. Images");
        count =0;
        foreach (Images v in _imageExtensions)
        {
            count = count + 1;
            v.DisplaExtension(count);
        }

        Console.WriteLine("E. Movies");
        count =0;
        foreach (Movies v in _movieExtensions)
        {
            count = count + 1;
            v.DisplaExtension(count);
        }

        Console.WriteLine("F. Programs");
        count =0;
        foreach (Programs v in _programExtensions)
        {
            count = count + 1;
            v.DisplaExtension(count);
        }

    }

    public static void DisplayMenue(string whichmenue)
    {
        Console.WriteLine("");
        
        if(whichmenue == "Main")
        {
            Console.WriteLine("");
            Console.WriteLine($"Menue Options:");
            foreach (Menue item in _menueItems)
            {
                item.DisplayItem();
            }
            _selectedMainMenuNumber = getSelectedMenuNumber(_menueItems.Count());
        }
        else if(whichmenue == "Folders")
        {
            SetMainFoldersMenu();

            Console.WriteLine("");
            Console.WriteLine($"Folders Options:");
            foreach (Menue item in _foldersMenue)
            {
                item.DisplayItem();
            }
            _selectedFolderMenuNumber = getSelectedMenuNumber(_foldersMenue.Count());

            foreach (Menue item in _foldersMenue)
            {
                if (item.GetItemNumber() ==_selectedFolderMenuNumber)
                {
                    _selectedFolderNumber = int.Parse(item.GetIdentify());
                }
            }
        }
        else if(whichmenue == "Sub Folders")
        {
            SetSubFoldersMenu(_selectedFolderNumber);

            Console.WriteLine("");
            Console.WriteLine($"Sub Folders Options:");
            foreach (Menue item in _subFoldersMenue)
            {
                item.DisplayItem();
            }
            _selectedSubFolderMenuNumber = getSelectedMenuNumber(_subFoldersMenue.Count());

            foreach (Menue item in _subFoldersMenue)
            {
                if (item.GetItemNumber() ==_selectedSubFolderMenuNumber)
                {
                    _selectedSubFolderNumber = int.Parse(item.GetIdentify());
                }
            }
        }
        else if(whichmenue == "File Types")
        {
            SetFileTypesMenu();

            Console.WriteLine("");
            Console.WriteLine($"File Types Options:");
            foreach (Menue item in _fileTypeMenue)
            {
                item.DisplayItem();
            }
            _selectedFileTypeNumber = getSelectedMenuNumber(_fileTypeMenue.Count());
        }
        else if(whichmenue == "File Extensions")
        {
            SetFileExtensionssMenu(_selectedFileTypeNumber);

            Console.WriteLine("");
            Console.WriteLine($"File Extensions Options:");
            foreach (Menue item in _extensionsMenue)
            {
                item.DisplayItem();
            }
            _selectedExtensionNumber = getSelectedMenuNumber(_extensionsMenue.Count());

            foreach (Menue item in _extensionsMenue)
            {
                if (item.GetItemNumber() ==_selectedExtensionNumber)
                {
                    _selectedFileTypeID = int.Parse(item.GetIdentify());
                }
            }
        }
    }

    static int getSelectedMenuNumber(int menucount)
    {
        Boolean _itemSelected = false;
        int num = 0;

        while (_itemSelected == false)
        {
            Console.Write($"Please select menu item (Enter number between 1 and {menucount}):");
            try
            {
                num = int.Parse(Console.ReadLine());
                if (num == 0)
                {
                    _itemSelected = false;
                }
                else
                {
                    if (num > 0)
                    {
                        if ( num <= menucount)
                        {
                             _itemSelected = true;
                        }
                    }
                }
            }
            catch
            {
                _itemSelected = false;
            }
        }
        return num;
    }

    static string pauseProgram(string displaytext)
    {
        Console.WriteLine("");
        Console.WriteLine(displaytext);
        string response = "";
        response = Console.ReadLine();
        return response;
    }

    static string getEnteredString(string displaytext)
    {
        Boolean _textEntered = false;
        string response = "";

        while (_textEntered == false)
        {
            Console.Write(displaytext);
            try
            {
                response = Console.ReadLine();
                if (response == "")
                {
                    _textEntered = false;
                }
                else
                {
                    _textEntered = true;
                }
            }
            catch
            {
                 _textEntered = false;
            }
        }
        return response;
    }

    static string getYesOrNo(string displaytext)
    {
        Boolean _textEntered = false;
        string response = "";

        while (_textEntered == false)
        {
            Console.Write(displaytext);
            try
            {
                response = Console.ReadLine().ToLower();
                if (response == "")
                {
                    _textEntered = false;
                }
                else if (response == "yes")
                {
                    _textEntered = true;
                }
                else if (response == "no")
                {
                    _textEntered = true;
                }
                else
                {
                    _textEntered = false;
                }
            }
            catch
            {
                 _textEntered = false;
            }
        }
        return response;
    }
}