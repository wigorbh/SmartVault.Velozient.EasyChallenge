using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace TwistedFizzBuzzLibrary
{
    public class TwistedFizzBuzz
    {
        private readonly HttpClient _client;

        public TwistedFizzBuzz()
        {
            _client = new HttpClient();
        }

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
        public List<string> GetFizzBuzzRange(int start, int end)
        {
            List<string> results = new List<string>();

            for (int i = start; i <= end; i++)
            {
                results.Add(GenerateFizzBuzz(i));
            }

            return results;
        }


        private string GenerateFizzBuzz(int number)
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
    }
}