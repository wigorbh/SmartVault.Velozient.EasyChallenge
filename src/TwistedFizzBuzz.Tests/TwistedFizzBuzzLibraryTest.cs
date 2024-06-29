using TwistedFizzBuzzLibrary;

namespace TwistedFizzBuzzTests
{
    public class TwistedFizzBuzzTests
    {
        private TwistedFizzBuzz twistedFizzBuzz;

        [SetUp]
        public void Setup()
        {
            twistedFizzBuzz = new TwistedFizzBuzz();
        }

        [Test]
        public void GenerateFizzBuzz_ShouldGenerateCorrectResults()
        {
            // Arrange
            int start = 1;
            int end = 15;
            var expectedResults = new List<string>
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"
            };

            // Act
            var results = twistedFizzBuzz.GenerateFizzBuzz(start, end);

            // Assert
            Assert.That(results, Is.EqualTo(expectedResults));
        }

        [Test]
        public void GetFizzBuzzNonSequential_ShouldGenerateCorrectResults()
        {
            // Arrange
            IEnumerable<int> numbers = new List<int> { 3, 5, 15 };
            var expectedResults = new List<string> { "Fizz", "Buzz", "FizzBuzz" };

            // Act
            var results = twistedFizzBuzz.GetFizzBuzzNonSequential(numbers);

            // Assert
            Assert.That(results, Is.EqualTo(expectedResults));
        }

        [Test]
        public void GenerateFizzBar_ShouldGenerateCorrectResults()
        {
            // Arrange
            int start = 1;
            int end = 30; // Exemplo, você pode ajustar conforme necessário

            // Act
            List<string> result = twistedFizzBuzz.GenerateFizzBar(start, end);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(30));
            Assert.That(result[4], Is.EqualTo("Fizz"));
            Assert.That(result[8], Is.EqualTo("Buzz"));
        }

        [Test]
        public void CustomFizzBuzz_ShouldGenerateCorrectResults()
        {
            // Arrange
            int start = 1;
            int end = 15;
            List<(int divisor, string token)> rules = new List<(int divisor, string token)>
            {
                (3, "CustomFizz"),
                (5, "CustomBuzz"),
                (15, "CustomFizzBuzz")
            };
            var expectedResults = new List<string>
            {
                "1", "2", "CustomFizz", "4", "CustomBuzz", "CustomFizz", "7", "8", "CustomFizz", "CustomBuzz", "11", "CustomFizz", "13", "14", "CustomFizzBuzz"
            };

            // Act
            var results = twistedFizzBuzz.CustomFizzBuzz(rules, start, end);

            // Assert
            Assert.That(results, Is.EqualTo(expectedResults));
        }

    }
}
