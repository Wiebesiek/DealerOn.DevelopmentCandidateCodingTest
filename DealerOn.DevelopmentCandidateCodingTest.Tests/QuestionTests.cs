using System;
using FluentAssertions;
using Xunit;

namespace DealerOn.DevelopmentCandidateCodingTest.Tests;

public class QuestionTests : GraphTests
{
    [Fact]
    public void Question1()
    {
        // Arrange 
        var route = new[] {'A', 'B', 'C'};
        
        // Act
        var distance = Graph.GetRouteDistance(route);
        
        // Assert
        distance.Should().Be(9);
    }
    
    [Fact]
    public void Question2()
    {
        // Arrange 
        var route = new[] {'A', 'D'};
        
        // Act
        var distance = Graph.GetRouteDistance(route);
        
        // Assert
        distance.Should().Be(5);
    }

    [Fact]
    public void Question3()
    {
        // Arrange 
        var route = new [] {'A', 'D', 'C'};
        
        // Act
        var distance = Graph.GetRouteDistance(route);
        
        // Assert
        distance.Should().Be(13);
    }

    [Fact]
    public void Question4()
    {
        // Arrange 
        var route = new [] {'A', 'E', 'B', 'C', 'D'};
        
        // Act
        var distance = Graph.GetRouteDistance(route);
        
        // Assert
        distance.Should().Be(22);
    }
    
    [Fact]
    public void Question5()
    {
        // Arrange 
        var route = new [] {'A', 'E', 'D'};
        
        // Act
        Action act = () => Graph.GetRouteDistance(route);
        
        // Assert
        act.Should().Throw<Exception>().WithMessage("NO SUCH ROUTE"); 
    }

    [Fact]
    public void Question6()
    {
        // Arrange and Act
        var numberOfRoutes = Graph.GetNumberOfRoutes('C', 'C', 3);
        
        // Assert
        numberOfRoutes.Should().Be(2);
    }

    [Fact]
    public void Question7()
    {
        // Arrange 
        var routesWith3Stops = Graph.GetNumberOfRoutes('A', 'C', 3);
        var routesWith4Stops = Graph.GetNumberOfRoutes('A', 'C', 4);
        
        // Act
        var routesWithExactly4Stops = routesWith4Stops - routesWith3Stops;

        // Assert
        routesWithExactly4Stops.Should().Be(3);
    }

    [Fact]
    public void Question8()
    {
        // Arrange And Act
        var shortestRouteFromAtoC = Graph.GetShortestRouteDistance('A', 'C');
        
        // Assert
        shortestRouteFromAtoC.Should().Be(9);
    }
    
    [Fact]
    public void Question9()
    {
        // Arrange And Act
        var shortestRouteFromBtoB = Graph.GetShortestRouteDistance('B', 'B');
        
        // Assert
        shortestRouteFromBtoB.Should().Be(9);
    }

    [Fact]
    public void Question10()
    {
        // Arrange and Act
        var routesWithDistanceLessThan30 = Graph.GetNumberOfRoutes('C', 'C', maxDistance:30);
        
        // Act
        routesWithDistanceLessThan30.Should().Be(7);
    }
}