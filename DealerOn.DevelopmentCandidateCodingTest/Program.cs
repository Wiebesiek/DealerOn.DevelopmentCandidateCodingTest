using DealerOn.DevelopmentCandidateCodingTest.Graph;
using DealerOn.DevelopmentCandidateCodingTest.Utilities;

var input = Environment.GetCommandLineArgs().Length > 1 ?
    File.ReadAllText(Environment.GetCommandLineArgs()[1]) : Prompts.GetInput();
var graph = new Graph(input);   

// Question 1
ParsingHelper.QuestionOutput(1, graph.GetRouteDistance(new []{'A', 'B', 'C'}).ToString());

// Question 2
ParsingHelper.QuestionOutput(2, graph.GetRouteDistance(new []{'A', 'D'}).ToString());

// Question 3
ParsingHelper.QuestionOutput(3, graph.GetRouteDistance(new []{'A', 'D', 'C'}).ToString());

// Question 4
ParsingHelper.QuestionOutput(4, graph.GetRouteDistance(new []{'A', 'E', 'B', 'C', 'D'}).ToString());

// Question 5 - An error should be thrown as no path exists
try
{
    graph.GetRouteDistance(new[] {'A', 'E', 'D'});
}
catch (Exception e)
{
    ParsingHelper.QuestionOutput(5, e.Message);
}

// Question 6
ParsingHelper.QuestionOutput(6, graph.GetNumberOfRoutes('C', 'C', 3).ToString());

// Question 7
var routesWith4Stops = graph.GetNumberOfRoutes('A', 'C', 4);
var routesWith3Stops = graph.GetNumberOfRoutes('A', 'C', 3);
var routesWithExactly4Stops = routesWith4Stops - routesWith3Stops;

ParsingHelper.QuestionOutput(7, routesWithExactly4Stops.ToString());

// Question 8
ParsingHelper.QuestionOutput(8, graph.GetShortestRouteDistance('A', 'C').ToString());

// Question 9
ParsingHelper.QuestionOutput(9, graph.GetShortestRouteDistance('B', 'B').ToString());

// Question 10
ParsingHelper.QuestionOutput(10, graph.GetNumberOfRoutes('C', 'C', maxDistance:30).ToString());