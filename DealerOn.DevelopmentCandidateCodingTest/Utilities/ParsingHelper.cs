namespace DealerOn.DevelopmentCandidateCodingTest.Utilities;

public static class ParsingHelper
{
    public static List<string> SplitInput(string input)
    {
        // PDF had a new line present in the input
        var separators = new[] {' ', ',', '\n', '\r' };
        return input.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public static void QuestionOutput(int questionNumber, string output)
    {
        Console.WriteLine($"Output #{questionNumber}: {output}");
    }
}