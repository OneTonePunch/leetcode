﻿// See https://aka.ms/new-console-template for more information
using LeetCode.TestService;
using LeetCode.TestService.Solutions;

Console.WriteLine("Start Runing Tests...");
List<ITestRunner> tests = new List<ITestRunner>
{ 
     new PalindromeNumber(),
};

foreach (var test in tests)
{
    var journal = test.Run();
    Console.WriteLine($"Run test {journal.TestName}");
    foreach (var journalItem in journal.Items)
    {
        Console.WriteLine($"\tInput: {journalItem.Input}");
        Console.WriteLine($"\tOutput: {journalItem.Output}");
        Console.WriteLine($"\tEllapsed Ticks: {journalItem.Ellapsed}");

        if (!string.IsNullOrEmpty(journalItem.Error))
            Console.WriteLine($"\tErrors: {journalItem.Error}");

        Console.WriteLine($"-----------");
    }
}

Console.WriteLine("End Runing Tests...");
Console.ReadLine();
