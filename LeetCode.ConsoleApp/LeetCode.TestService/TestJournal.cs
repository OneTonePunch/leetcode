namespace LeetCode.TestService
{
    public class TestJournal
    {
        public TestJournal(string testName)
        {
            TestName = testName;
        }
        public string TestName { get; private set; }
        public List<TestJournalItem> Items { get; private set; }

        public void Add(TestJournalItem item)
        {
            if (Items == null)
                Items = new List<TestJournalItem>();

            Items.Add(item);
        }
    }

    public class TestJournalItem
    {
        public TestJournalItem()
        {
            CreatedDate = DateTime.Now;
        }
        
        public string Input { get; set; }
        public string Output { get; set; }
        public string Error { get; set; }
        public DateTime CreatedDate { get; private set; }
        public long Ellapsed { get; set; }
    }
}
