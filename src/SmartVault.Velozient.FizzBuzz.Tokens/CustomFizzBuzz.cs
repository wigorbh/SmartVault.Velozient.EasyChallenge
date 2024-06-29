using TwistedFizzBuzzLibrary;
public class CustomFizzBuzz
{
    static void Main(string[] args)
    {
        var twistedFizzBuzz = new TwistedFizzBuzz();

        GenerateCustomFizzBuzz(twistedFizzBuzz);

        GenerateNonSequencial(twistedFizzBuzz);

        GenerateFizzBuzzBar(twistedFizzBuzz);
    }

    private static void GenerateCustomFizzBuzz(TwistedFizzBuzz twistedFizzBuzz)
    {
        var start = 1;
        var end = 357;

        var customRules = new List<(int divisor, string token)>
        {
            (7, "Poem"),
            (17, "Writer"),
            (3, "College"),
            (119, "PoemWriter"),
            (51, "WriterCollege"),
            (21, "PoemCollege"),
            (357, "PoemWriterCollege")
        };

        var results = twistedFizzBuzz.CustomFizzBuzz(customRules, start, end);

        Console.WriteLine("*********** RESULT CustomTokens *********:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }

    }

    private static void GenerateNonSequencial(TwistedFizzBuzz twistedFizzBuzz)
    {
        var numbers = new List<int> { -5, 6, 300, 12, 15 };
        var results = twistedFizzBuzz.GetFizzBuzzNonSequential(numbers);

        Console.WriteLine("*********** RESULT NonSequential *********:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    private static void GenerateFizzBuzzBar(TwistedFizzBuzz twistedFizzBuzz)
    {
        int num1 = -20;
        int num2 = 127;

        var results = twistedFizzBuzz.GenerateFizzBar(num1, num2);

        Console.WriteLine("*********** RESULT FizzBuzzBar *********:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}

