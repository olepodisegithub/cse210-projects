using System;
class Program
{
     public static List<Shape> _shapes = new List<Shape>();
    static void Main(string[] args)
    {
        Square sq = new Square("Red",5);
        Rectangle rec = new Rectangle("White",5,10);
        Circle cir = new Circle("Blue",10);
        
        _shapes.Add(sq);
        _shapes.Add(rec);
        _shapes.Add(cir);
     
        Console.Clear();
        foreach(Shape sh in _shapes)
        {
            Console.WriteLine($"The area of the {sh.GetColor()} shape is {sh.GetArea()}");
        } 
        Console.WriteLine();     
    }
}