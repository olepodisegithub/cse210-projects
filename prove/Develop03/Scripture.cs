public class Scripture
{
    public Reference _ref = new Reference();
    private string _scriptureText = "";
    public List<Word> _words = new List<Word>();

    public Scripture()
    {
        
    }
    
    public Scripture(string text,string bookName,int chapter,int startVerse)
    {
        _scriptureText = text;
        _ref = new Reference(bookName,chapter,startVerse);
        GenerateWords();
    }  

    public Scripture(string text,string bookName,int chapter,int startVerse,int endVerse)
    {
        _scriptureText = text;
        _ref = new Reference(bookName,chapter,startVerse,endVerse);
        GenerateWords();
    }

    public void SetScriptureText(string text)
    {
        _scriptureText = text;
    }  

    public string GetScriptureText()
    {
        return _scriptureText;
    } 

    public void DisplayScripture(string script)
    {
        Console.WriteLine($"{_ref.getReference()} {script}");
    }

    private void GenerateWords() 
    {
        string[] words = _scriptureText.Split(' ');

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }
}