namespace DealerOn.DevelopmentCandidateCodingTest.Graph;

public class Node
{
    public readonly List<Edge> Edges = new();
    public char Name { get; init; }
}