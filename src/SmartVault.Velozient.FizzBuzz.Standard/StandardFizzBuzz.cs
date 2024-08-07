﻿using TwistedFizzBuzzLibrary;
public class StandardFizzBuzz
{
    static void Main(string[] args)
    {
        var start = 1;
        var end = 100;

        TwistedFizzBuzz twistedFizzBuzz = new TwistedFizzBuzz();

        ValidateRange(start, end);

        var results = twistedFizzBuzz.GenerateFizzBuzz(start, end);

        PrintResult(results);
    }

    public static void PrintResult(List<string> results)
    {
        Console.WriteLine("*********** RESULT *********:");
        foreach (var fizzBuzz in results)
        {
            Console.WriteLine(fizzBuzz);
        }
    }

    public static void ValidateRange(int start, int end)
    {
        if (start > end || start < 1 || end > 100)
        {
            throw new ArgumentException("The start number must be less than or equal to the end number and within the range of 1 to 100.");
        }
    }
}