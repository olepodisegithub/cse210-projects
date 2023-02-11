public class Reference
{
    private String _bookName = "";
    private int _chapter = 0;
    private int _startVerse = 0;
    private int _endVerse = 0;

    public Reference()
    {
        
    }  

    public Reference(string bookName,int chapter,int startVerse)
    {
        _bookName = bookName;
        _chapter = chapter;
        _startVerse = startVerse;
    }  

    public Reference(string bookName,int chapter,int startVerse,int endVerse)
    {
        _bookName = bookName;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string getReference()
    {
        if (_endVerse > 0)
        {
            return _bookName + " " + _chapter + ":" + _startVerse + "-" + _endVerse;
        }
        else
        {
            return _bookName + " " + _chapter + ":" + _startVerse;
        }
    }  

    public void SetBookName(string name)
    {
        _bookName = name;
    }

    public string GetBookName()
    {
        return _bookName;
    }

    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public void SetStartVerse(int position)
    {
        _startVerse = position;
    }

    public int GetStartVerse()
    {
        return _startVerse;
    }

    public void SetEndVerse(int position)
    {
        _endVerse = position;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }
}