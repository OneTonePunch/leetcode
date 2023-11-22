using Newtonsoft.Json;
using System.Diagnostics;

namespace LeetCode.TestService.Solutions
{
    public class PalindromeNumber : ITestRunner
    {
        public string Name { get; } = "[9] Palindrome Number";
        
        public TestJournal Run()
        {
            var journal = new TestJournal(Name);
            var validInputs = GetValidInputs();
            var invalidInputs = GetInvalidInputs();

            var inputs = new List<int>().Concat(validInputs).Concat(invalidInputs);
            var stopWatch = new Stopwatch();
            foreach (var input in inputs) 
            {
                try
                {
                    stopWatch.Start();
                    var isPalindrome = IsPalindrome(input);
                    stopWatch.Stop();

                    var journalItem = new TestJournalItem
                    {
                        Input = JsonConvert.SerializeObject(input),
                        Output = JsonConvert.SerializeObject(isPalindrome),
                        Ellapsed = stopWatch.ElapsedTicks
                    };

                    journal.Add(journalItem);
                }
                catch (Exception ex)
                {
                    var journalItem = new TestJournalItem
                    {
                        Input = JsonConvert.SerializeObject(input),
                        Ellapsed = stopWatch.ElapsedTicks,
                        Error = ex.ToString(),
                    };

                    journal.Add(journalItem);
                }
                finally 
                {
                    stopWatch.Stop();
                }
                
            }


            return journal;

        }

        private List<int> GetValidInputs()
        {
            return new List<int>
            {
                543345,
                121,
                123454321
            };
        }

        private List<int> GetInvalidInputs()
        {
            return new List<int>
            {
                543645,
                -121,
                123453321
            };
        }
        private bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            int n = 0;
            int number = x;
            while (number > 0)
            {
                n = n * 10 + number % 10;
                number = number / 10;
            }
            return n == x;
        }
    }
}
