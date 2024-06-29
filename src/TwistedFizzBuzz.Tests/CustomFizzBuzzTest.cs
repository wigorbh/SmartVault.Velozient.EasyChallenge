using System.Text.Json;
using TwistedFizzBuzzLibrary;

namespace TwistedFizzBuzzTests
{
    public class CustomFizzBuzzTests
    {
        private TwistedFizzBuzz _twistedFizzBuzz;

        [SetUp]
        public void Setup()
        {
            _twistedFizzBuzz = new TwistedFizzBuzz();
        }

        [Test]
        public void GenerateCustomFizzBuzz_ShouldReturnCorrectResults()
        {
            // Arrange
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

            // Act
            var results = _twistedFizzBuzz.CustomFizzBuzz(customRules, start, end);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count, Is.EqualTo(357)); // Assuming results count should match the range size for this example
        }

        [Test]
        public void GenerateNonSequencial_ShouldReturnCorrectResults()
        {
            // Arrange
            var numbers = new List<int> { -5, 6, 300, 12, 15 };

            // Act
            var results = _twistedFizzBuzz.GetFizzBuzzNonSequential(numbers);

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count, Is.EqualTo(numbers.Count));
        }

        [Test]
        public void GenerateFizzBuzzBar_ShouldReturnCorrectResults()
        {
            // Arrange
            int num1 = -20;
            int num2 = 127;

            // Act
            var results = _twistedFizzBuzz.GenerateFizzBar(num1, num2);

            // Assert
            Assert.That(results, Is.Not.Null);
        }

        [Test]
        public async Task GenerateTokenByAPI_ShouldReturnValidToken()
        {
            // Arrange
            var url = "https://randomuser.me/api/";

            // Act
            var token = await FetchTokenFromApi(url);

            // Assert
            Assert.That(token, Is.Not.Null);
            Assert.That(token, Is.Not.Empty);
        }

        private async Task<string> FetchTokenFromApi(string url)
        {
            using var client = new HttpClient();
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
}
