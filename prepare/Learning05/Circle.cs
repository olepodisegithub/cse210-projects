class Circle : Shape
{
    private double _radius = 0;

    public Circle(string color,double radius) : base(color)
    {
        _radius = radius;
    }
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

}
