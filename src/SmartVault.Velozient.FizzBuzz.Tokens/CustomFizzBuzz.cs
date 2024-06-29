using System.Text.Json;
using TwistedFizzBuzzLibrary;
public class CustomFizzBuzz
{
    static void Main(string[] args)
    {
        var twistedFizzBuzz = new TwistedFizzBuzz();

        GenerateCustomFizzBuzz(twistedFizzBuzz);

        GenerateNonSequencial(twistedFizzBuzz);

        GenerateFizzBuzzBar(twistedFizzBuzz);

        GenerateTokenByAPI(twistedFizzBuzz);
    }

    private static void GenerateTokenByAPI(TwistedFizzBuzz twistedFizzBuzz)
    {
        try
        {
            var start = 1;
            var end = 100;

            // this one does not work: https://rich-red-cocoon-veil.cyclic.app/
            
            // this one is a simple case to return a name like a token
            var token = FetchTokenFromApi("https://randomuser.me/api/").GetAwaiter().GetResult();
            
            var rules = new List<(int divisor, string token)> { (3, token) };
            var results = twistedFizzBuzz.CustomFizzBuzz(rules, start, end);

            Console.WriteLine("*********** RESULT Fetch Token *********:");
            results.ForEach(Console.WriteLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
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

        // This method may work with all token scenarios, but the complexity of its algorithm may not be ideal for simple cases.
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

    static async Task<string> FetchTokenFromApi(string url)
    {
        var client = new HttpClient();
        var response = await client.GetStringAsync(url);

        if (response == null)
        {
            throw new InvalidOperationException("Failed to fetch data from the API.");
        }

        var jsonDoc = JsonDocument.Parse(response);
        var firstName = jsonDoc.RootElement
            .GetProperty("results")[0]
            .GetProperty("name")
            .GetProperty("first")
            .GetString();
       

        return firstName ?? "Test";
    }
}

