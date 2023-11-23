using Newtonsoft.Json;
using System.Diagnostics;

namespace LeetCode.TestService.Solutions
{
    public class RemoveElement : ITestRunner
    {
        public string Name { get; } = "[27] Remove Element";
        
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
                    var result = RemoveElementRun(input.Nums, input.Value);
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

        private List<RemoveElementInput> GetInputs()
        {
            return new List<RemoveElementInput>
            {
                new RemoveElementInput
                { 
                     Nums = new int[]{ 3, 2, 2, 3},
                     Value = 3
                },
                new RemoveElementInput
                {
                    Nums = new int[]{ 0,1,2,2,3,0,4,2},
                    Value = 2
                }
            };
        }

        private int RemoveElementRun(int[] nums, int val)
        {
            return 0;
        }
    }

    public class RemoveElementInput
    {
        public int[] Nums { get; set; }
        public int Value { get; set; }
    }
}
