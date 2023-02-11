public class Word
{
    private String _wordText = "";

    public Word(string wordtext)
    {
        _wordText = wordtext;
    }  

    public void SetWordText(string text)
    {
        _wordText = text;
    }  

    public string getWordText()
    {
       return _wordText;
    }  
}