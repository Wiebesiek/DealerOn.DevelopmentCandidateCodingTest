using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace DealerOn.DevelopmentCandidateCodingTest.Tests;

public class GraphTests
{
    internal readonly Graph.Graph Graph;
    
    public GraphTests()
    {
        Graph = _initialiseGraph();    
    }

    private static string _getTestFilePath()
    {
        // Gets ...\bin\Debug
        var workingDirectory = Environment.CurrentDirectory;
        // Gets ...\bin
        var binDirectory = Directory.GetParent(workingDirectory)!.Parent!.FullName;
        // Gets Current Project Directory
        var projectDirectory = Directory.GetParent(binDirectory)!.FullName;       
        return Path.Combine(projectDirectory, "DefaultInput.txt");
    }

    private Graph.Graph _initialiseGraph()
    {
        var input = File.ReadAllText(_getTestFilePath());
        return new Graph.Graph(input);
    }

    [Fact]
    public void GraphShouldCreateFromFile()
    {
        // Arrange, Act and Assert
        Graph.Nodes.Count.Should().Be(5);
        Graph.Nodes.Select(n => n.Edges.Count).Sum().Should().Be(9);
    }
    
    [Fact]
    public void GraphShouldCreateFromString()
    {
        // Arrange
        var input = " AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7  ";
        // Act
        var graph = new Graph.Graph(input);
        // Assert
        graph.Nodes.Count.Should().Be(5);
        graph.Nodes.Select(n => n.Edges.Count).Sum().Should().Be(9);
    }
}