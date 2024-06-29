using System.Collections.Generic;
using System.Threading.Tasks;


namespace TwistedFizzBuzzLibrary
{
    public class TwistedFizzBuzz
    {
        /// <summary>
        /// Generates a list of FizzBuzz results for a range of numbers.
        /// </summary>
        /// <param name="start">The starting number of the range. </param>
        /// <param name="end">The ending number of the range. </param>
        /// <returns>A list of strings containing the FizzBuzz results for each number in the range.</returns>
        /// <remarks>
        /// The method iterates through each number in the specified range and generates a FizzBuzz result for each number.
        /// FizzBuzz results are added to a list and returned at the end.
        /// </remarks>
        public List<string> GenerateFizzBuzz(int start, int end)
        {
            var results = new List<string>();

            for (int i = start; i <= end; i++)
            {
                results.Add(GetFizzBuzz(i));
            }

            return results;
        }

        public List<string> GetFizzBuzzNonSequential(IEnumerable<int> numbers)
        {
            var results = new List<string>();

            foreach (int number in numbers)
            {
                results.Add(GetFizzBuzz(number));
            }

            return results;
        }

        private string GetFizzBuzz(int number)
        {
            const string Fizz = "Fizz";
            const string Buzz = "Buzz";
            const string FizzBuzz = "FizzBuzz";

            bool isDivisibleBy3 = (number % 3 == 0);
            bool isDivisibleBy5 = (number % 5 == 0);

            if (isDivisibleBy3 && isDivisibleBy5)
            {
                return FizzBuzz;
            }
            else if (isDivisibleBy3)
            {
                return Fizz;
            }
            else if (isDivisibleBy5)
            {
                return Buzz;
            }
            else
            {
                return number.ToString();
            }
        }

        public List<string> GenerateFizzBar(int start, int end)
        {
            const string Fizz = "Fizz";
            const string Buzz = "Buzz";
            const string Bar = "Bar";

            var output = new List<string>();

            for (int i = start; i <= end; i++)
            {
                string result = "";

                if (i % 5 == 0)
                    result += Fizz;
                if (i % 9 == 0)
                    result += Buzz;
                if (i % 27 == 0)
                    result += Bar;

                if (string.IsNullOrEmpty(result))
                    result = i.ToString();

                output.Add(result);
            }

            return output;
        }

        /// <summary>
        /// Generates a list of strings based on rules of divisors and corresponding tokens.
        /// For each integer in the range from 'start' to 'end', it checks the divisibility
        /// by each rule's divisor. If divisible, it appends the corresponding token.
        /// If no rule applies, the integer itself is added as a string.
        /// </summary>
        /// <param name="rules">A list of tuples containing divisors and tokens.</param>
        /// <param name="start">The starting integer of the range.</param>
        /// <param name="end">The ending integer of the range.</param>
        /// <returns>A list of strings representing the result of the custom FizzBuzz operation.</returns>
        public List<string> CustomFizzBuzz(List<(int divisor, string token)> rules, int start, int end)
        {
            var result = new List<string>();

            for (int i = start; i <= end; i++)
            {
                string output = "";
                foreach (var rule in rules)
                {
                    if (i % rule.divisor == 0)
                        output = rule.token;
                }

                result.Add(string.IsNullOrEmpty(output) ? i.ToString() : output);
            }

            return result;
        }
    }
}