using Newtonsoft.Json;
using System.Diagnostics;

namespace LeetCode.TestService.Solutions
{
    public class MergeTwoSortedLists : ITestRunner
    {
        public string Name { get; } = "[21] Merge Two Sorted Lists";
        
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
                    var result = MergeTwoLists(input[0], input[1]);
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

        private ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
                return null;

            var current = new ListNode();
            if (list1 == null)
            {
                current.val = list2.val;
                current.next = MergeTwoLists(list1, list2.next);
            }
            else if (list2 == null)
            {
                current.val = list1.val;
                current.next = MergeTwoLists(list1.next, list2);
            }
            else if (list1.val == list2.val)
            {
                current.val = list1.val;
                current.next = new ListNode
                {
                    val = list2.val,
                };

                current.next.next = MergeTwoLists(list1.next, list2.next);
            }
            else if (list1.val < list2.val)
            {
                current.val = list1.val;
                current.next = MergeTwoLists(list1.next, list2);
            }
            else if (list1.val > list2.val)
            {
                current.val = list2.val;
                current.next = MergeTwoLists(list1, list2.next);
            }

            return current;
        }

        private List<List<ListNode>> GetInputs()
        {
            var result = new List<List<ListNode>>();

            var input1 = new List<ListNode>
            {
                new ListNode{
                     val = 1,
                      next = new ListNode{ 
                        val=2,
                        next = new ListNode{ val = 4}
                      }
                },

                new ListNode{ 
                    val = 1,
                    next = new ListNode
                    {
                        val = 3,
                        next = new ListNode{ val = 4}
                    }
                }
            };

            result.Add(input1);
            return result;
        }
       

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
