namespace TwistedFizzBuzzTests
{
    public class StandardFizzBuzzTests
    {
        public void PrintResult_ShouldPrintResults()
        {
            // Arrange
            var results = new List<string> { "Fizz", "Buzz", "FizzBuzz" };
            var expectedOutput = "*********** RESULT *********: \nFizz\nBuzz\nFizzBuzz";

            // Act
            var printedOutput = CaptureConsoleOutput(() => StandardFizzBuzz.PrintResult(results));

            // Assert
            Assert.That(printedOutput, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ValidateRange_ValidRange_ShouldNotThrowException()
        {
            // Arrange
            var start = 1;
            var end = 100;

            // Act & Assert
            Assert.DoesNotThrow(() => StandardFizzBuzz.ValidateRange(start, end));
        }

        [Test]
        public void ValidateRange_StartGreaterThanEnd_ShouldThrowArgumentException()
        {
            // Arrange
            var start = 101;
            var end = 100;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => StandardFizzBuzz.ValidateRange(start, end));
        }

        [Test]
        public void ValidateRange_StartLessThanOne_ShouldThrowArgumentException()
        {
            // Arrange
            var start = 0;
            var end = 100;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => StandardFizzBuzz.ValidateRange(start, end));
        }

        [Test]
        public void ValidateRange_EndGreaterThanHundred_ShouldThrowArgumentException()
        {
            // Arrange
            var start = 1;
            var end = 101;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => StandardFizzBuzz.ValidateRange(start, end));
        }

        private string CaptureConsoleOutput(Action action)
        {
            var consoleOut = Console.Out;
            using (var sw = new RedirectedConsoleOutput())
            {
                sw.Redirect();
                action.Invoke();
                return sw.Capture();
            }
        }

        private class RedirectedConsoleOutput : IDisposable
        {
            private StringWriter sw;
            private TextWriter originalOutput;

            public void Redirect()
            {
                sw = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(sw);
            }

            public string Capture()
            {
                return sw.ToString().Trim();
            }

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                sw.Dispose();
            }
        }
    }
}
