using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace DealerOn.DevelopmentCandidateCodingTest.Tests;

public class ParsingHelperTests
{
    [Theory]
    [InlineData("AB1, CD2, EF3")]
    [InlineData("AB1,   CD2,EF3")]
    [InlineData("AB1,CD2 \nEF3")]
    [InlineData("AB1, CD2, \nEF3")]
    public void SplitInputShouldReturnCorrectValues(string input)
    {
        // Arrange
        var expected = new List<string> { "AB1", "CD2", "EF3" };
        
        // Act
        var result = Utilities.ParsingHelper.SplitInput(input);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}