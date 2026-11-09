using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Create fractions with each constructor.
        Fraction whole = new Fraction();
        Fraction five = new Fraction(5);
        Fraction threeQuarters = new Fraction(3, 4);
        Fraction oneThird = new Fraction(1, 3);

        // Demonstrate getters and setters.
        Console.WriteLine($"Initial top: {threeQuarters.GetTop()}");
        Console.WriteLine($"Initial bottom: {threeQuarters.GetBottom()}");
        threeQuarters.SetTop(3);
        threeQuarters.SetBottom(4);
        Console.WriteLine($"Updated fraction: {threeQuarters.GetFractionString()}");
        Console.WriteLine();

        // Display the fractional and decimal forms.
        DisplayFraction(whole);
        DisplayFraction(five);
        DisplayFraction(threeQuarters);
        DisplayFraction(oneThird);
    }

    private static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}
