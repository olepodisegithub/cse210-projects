using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public String _fileLocation = "";
  
    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveJournal()
    {
        using (StreamWriter outputFile = new StreamWriter(_fileLocation))
        {     
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptDescription}|{entry._response}");
            }
        }
    }

    public void LoadJournal()
    {
        _entries.Clear();

        string[] entrylines = System.IO.File.ReadAllLines(_fileLocation);

        foreach (string entry in entrylines)
        {
            string[] parts = entry.Split("|");

            string firstName = parts[0];
            string lastName = parts[1];

            Entry ent1 = new Entry();
            ent1._date = parts[0];
            ent1._promptDescription = parts[1];
            ent1._response = parts[2];
                       
           _entries.Add(ent1);
        }
    }  
}