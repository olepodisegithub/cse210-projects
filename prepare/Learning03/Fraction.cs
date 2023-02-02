public class Fraction
{
    //Create a class to hold fraction.
    //The class should be in its own file.
    //The class should have two attributes for the top and bottom numbers.
    //Make sure the attributes are private.

    private int _numerator = 0;
    private int _denominator = 0;

    //Constructor that has no parameters that initializes the number to 1/1.
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    //Constructor that has one parameter for the top and that initializes the denominator to 1. So that if you pass in the number 5, the fraction would be initialized to 5/1.
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    //Constructor that has two parameters, one for the top and one for the bottom.
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    //Create getters and setters for both the top and the bottom values.
    public int GetNumerator()
    {
        return _numerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public void SetDenominator(int denominator)
    {
        _denominator = denominator;
    }

    //Create a method called GetFractionString that returns the fraction in the form 3/4.
    public string GetFractionString()
    {
        return _numerator + "/" + _denominator;
    }

    //Create a method called GetDecimalValue that returns a double that is the result of 
    //dividing the top number by the bottom number, such as 0.75.
    public double GetDecimalValue()
    {
        return _numerator / _denominator;
    }
}

