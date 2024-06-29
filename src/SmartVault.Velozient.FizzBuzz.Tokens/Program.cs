using TwistedFizzBuzzLibrary;
public class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for input
        Console.WriteLine("Enter the start of the range:");
        string startInput = Console.ReadLine();

        Console.WriteLine("Enter the end of the range:");
        string endInput = Console.ReadLine();

        TwistedFizzBuzz twistedFizzBuzz = new TwistedFizzBuzz();


        if (int.TryParse(startInput, out int start) && int.TryParse(endInput, out int end))
        {
            ValidateSpecificRange(start, end);

            var result = twistedFizzBuzz.GetFizzBuzzRange(start, end);

            Console.WriteLine(result);
        }
    }

    private static void ValidateSpecificRange(int start, int end)
    {
        if (start < -20 || end > 127)
        {
            throw new ArgumentOutOfRangeException("Invalid range: values should be between -20 and 127.");
        }
    }
}

