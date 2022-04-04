namespace DealerOn.DevelopmentCandidateCodingTest.Utilities;

public static class Prompts
{
    public static string? GetInput()
    {
        Console.WriteLine(@"Enter edge values seperated by commas.");
        return Console.ReadLine();
    }
}