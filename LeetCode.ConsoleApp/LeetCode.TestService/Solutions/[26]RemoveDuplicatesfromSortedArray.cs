using Newtonsoft.Json;
using System.Diagnostics;

namespace LeetCode.TestService.Solutions
{
    public class RemoveDuplicatesfromSortedArray : ITestRunner
    {
        public string Name { get; } = "[26] Remove Duplicates fromSorted Array";
        
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
                    var result = RemoveDuplicates(input);
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

        private List<int[]> GetInputs()
        {
            return new List<int[]>
            {
                new int[]{ 1, 1, 2},
                new int[]{ 0,0,1,1,1,2,2,3,3,4},
            };
        }

        private int RemoveDuplicates2(int[] nums)
        {
            int counter = 0;
            int nextValIndex = 0;
            int leftIndex = 0;
            int rightIndex = nums.Length-1;
            while (leftIndex <= nums.Length - 1)
            {
                while (nums[leftIndex] != nums[rightIndex])
                {
                    rightIndex--;                    
                }

                nums[nextValIndex] = nums[leftIndex];
                nextValIndex++;
                leftIndex = rightIndex+1;
                rightIndex = nums.Length-1;
                counter++;
            }

            return counter;
        }

        //best solution
        private int RemoveDuplicates(int[] nums)
        {
            int counter = 0;
            int nextValIndex = 0;
            int leftIndex = 0;
            int rightIndex = leftIndex;
            while (leftIndex <=nums.Length - 1)
            {
                while (rightIndex < nums.Length&&nums[leftIndex] == nums[rightIndex])
                {
                    rightIndex++;
                }

                nums[nextValIndex] = nums[leftIndex];
                nextValIndex++;
                leftIndex = rightIndex;
                counter++;
            }

            return counter;
        }
    }
}
