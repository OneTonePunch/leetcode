using Newtonsoft.Json;
using System.Diagnostics;

namespace LeetCode.TestService.Solutions
{
    public class LongestCommonPrefix : ITestRunner
    {
        public string Name { get; } = "[14] Longest Common Prefix";
        
        public TestJournal Run()
        {
            var journal = new TestJournal(Name);

            var inputs = GetInputs();
            var stopWatch = new Stopwatch();
            foreach (var input in inputs) 
            {
                try
                {
                    stopWatch.Start();
                    var result = LongestCommonPrefixRun(input);
                    stopWatch.Stop();

                    var journalItem = new TestJournalItem
                    {
                        Input = JsonConvert.SerializeObject(input),
                        Output = JsonConvert.SerializeObject(result),
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

        private List<string[]> GetInputs()
        {
            return new List<string[]>
            {
                new string[] { "flower", "flow", "flight" },
                new string[] { "dog", "racecar", "car" },
                new string[] { "a"},
                new string[] { "" },
                new string[] { "ab", "a" }
            };
        }

        private string LongestCommonPrefixRun(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;

            if (strs.Length == 1)
                return strs[0];

            var prefix = strs[0];
            for (var i = 1; i < strs.Length; i++)
            {
                if (prefix.Length == 0)
                    break;

                if (prefix.Length > strs[i].Length)
                    prefix = prefix.Substring(0, strs[i].Length);

                var leftIndex = 0;
                var rightIndex = prefix.Length - 1;

                while (leftIndex <= rightIndex)
                {
                    if (strs[i][leftIndex] == prefix[leftIndex])
                        leftIndex++;
                    else
                    {
                        prefix = prefix.Substring(0, leftIndex);
                        break;
                    }


                    if (strs[i][rightIndex] == prefix[rightIndex])
                        rightIndex--;
                    else
                    {
                        prefix = prefix.Substring(0, rightIndex);
                        rightIndex--;
                    }

                }
            }

            return prefix;
        }
    }
}
