namespace LeetCode.TestService
{
    public interface ITestRunner
    {
        string Name { get; }
        TestJournal Run();
    }
}
