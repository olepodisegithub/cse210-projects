public class Files
{
    private String _fileName = "";
    private String _fileExtension = "";

    public Files(string name,string extension)
    {
        _fileName = name;
        _fileExtension = extension;
    }
    public string GetFileName()
    {
        return _fileName;
    }
    public string GetFileExtension()
    {
        return _fileExtension;
    }

    public int getFileTypeID()
    {
        int num = 0;
        try
        {
            string[] entrylines = System.IO.File.ReadAllLines("FileExtensions.txt");
            foreach (string line in entrylines)
            {
                string[] columns = line.Split("=");

                string text = columns[1];
                if (text.ToLower() == _fileExtension.ToLower())
                {
                    num = int.Parse(columns[2]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception Message:", ex.Message);
            Console.WriteLine("Exception source:", ex.Source);
        }
        return num;
    }
}