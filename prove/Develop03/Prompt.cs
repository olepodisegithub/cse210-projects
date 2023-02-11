public class Prompt
{
    public Scripture _scripture = new Scripture();
    public List<int> _clearedWords = new List<int>();
    public Prompt()
    {
        
    }

    public Prompt(Scripture script)
    {
        _scripture = script;
    }
    public void DisplayPrompt(int disappearcount)
    {
        string newScriptureText = "";
        int recordedCount = 0;
        var rnd = new Random();
        int index = 0;
        

        while (recordedCount < disappearcount)
        {
            rnd = new Random();
            index = rnd.Next(_scripture._words.Count);
            
            if (_clearedWords.Contains(index) == false)
            {
                recordedCount = recordedCount + 1;
                _clearedWords.Add(index);
                 if (_clearedWords.Count == _scripture._words.Count)
                 {
                    recordedCount = disappearcount;
                 }
            }
        }

        foreach (Word w in _scripture._words)
        {
            if (_clearedWords.Contains(_scripture._words.IndexOf(w)) == true)
            {
                newScriptureText = $"{newScriptureText} {CreateSpaces(w.getWordText())}";
            }
            else
            {
                newScriptureText = $"{newScriptureText} {w.getWordText()}";
            }
        }
        _scripture.DisplayScripture(newScriptureText);
    }  

    private string CreateSpaces(string wordtext)
    {
        string spacesTest = "";
        foreach (char letter in wordtext)
        {
            spacesTest = $"{spacesTest}_";
        }
        return spacesTest;
    }
}