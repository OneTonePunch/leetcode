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
            //TODO
            var result = new ListNode();
            //var lis1Values = GetValues(list1);
            //var lis2Values = GetValues(list2);

            var resultedList = new List<int>();


            while (list1!=null||list2!=null)
            {
                if (list1 == null)
                {
                    resultedList.Add(list2.val);
                    list2 = list2.next;
                }

                if (list2 == null)
                {
                    resultedList.Add(list1.val);
                    list1 = list1.next;
                }

                if (list1.val == list2.val)
                {
                    resultedList.Add(list1.val);
                    resultedList.Add(list2.val);

                    list1 = list1.next;
                    list2 = list2.next;
                    continue;
                }

                if (list1.val < list2.val)
                {
                    resultedList.Add(list1.val);
                    list1 = list1.next;
                    continue;
                }
                else
                {
                    resultedList.Add(list2.val);
                    list2 = list2.next;
                    continue;
                }
            }
            result = CreateNode(resultedList);
            return result;
        }

        private ListNode CreateNode(List<int> collection)
        {
            var index = collection.Count - 1;
            ListNode child = null;
            while (index >= 0)
            {
                var node = new ListNode
                {
                    val = collection[index],
                    next = child,
                };

                index--;
                child = node;
            }

            return child;
        }
        private List<int> GetValues(ListNode list1)
        {

            var result = new List<int> { list1.val };
            
            var current = list1;
            while (current.next != null)
            {
                result.Add(current.next.val);
                current = current.next;
            }

            return result;
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
