using System;

public class Fraction
{
    private readonly int _numerator;
    private readonly int _denominator;

    public Fraction() : this(1, 1) { }

    public Fraction(int wholeNumber) : this(wholeNumber, 1) { }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator == 0 ? 1 : denominator;
    }

    public string ToFractionString() => $"{_numerator}/{_denominator}";

    // Returns the decimal value of the fraction
    public double ToDecimal() => (double)_numerator / _denominator;
}
