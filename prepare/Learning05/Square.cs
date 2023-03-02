class Square : Shape
{
    private int _side = 0;

    public Square(string color,int side) : base(color)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return _side * 2;
    }

}
