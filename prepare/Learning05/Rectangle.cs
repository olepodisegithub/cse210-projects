class Rectangle : Shape
{
    private int _length = 0;
    private int _width = 0;

    public Rectangle(string color,int length,int width) : base(color)
    {
        _length = length;
        _width = width;
    }
    public override double GetArea()
    {
        return _length * _width;
    }

}
