using DealerOn.DevelopmentCandidateCodingTest.Utilities;

namespace DealerOn.DevelopmentCandidateCodingTest.Graph;

public class Graph
{
    public List<Node> Nodes { get; }
    
    /// <summary>
    /// Constructor based on a series of weighted edges
    /// </summary>
    /// <param name="weightedEdges">
    /// Weighted edges to be added to the graph
    /// </param>
    public Graph(string weightedEdges)
    {
        Nodes = new List<Node>();
        var weightedEdgesList = ParsingHelper.SplitInput(weightedEdges);
        
        foreach (var weightedEdge in weightedEdgesList)
        {
            var nodeName = weightedEdge[0];

            var edge = new Edge
            {
                Destination = weightedEdge[1],
                Weight = int.Parse(weightedEdge.Substring(2,1))
            };

            var node = _getNode(nodeName, true);
            node.Edges.Add(edge);
        }
    }

    private Node _getNode(char name, bool createNodeIfNotFound = false)
    {
        var result =  Nodes.FirstOrDefault(n => n.Name == name);
        if (result != null) return result;
        if (createNodeIfNotFound == false)
        {
            throw new Exception("Node not found");
        }
        result = new Node
        {
            Name = name
        };
        Nodes.Add(result);
        return result;
    }

    private int _getNumberOfRoutesHelper(char start, char end, int maxStops, int maxDistance, int currentStops, int currentDistance,int routes)
    {
        if (start == end && currentStops > 0 && currentDistance < maxDistance) routes++;

        // Stop cases
        if (currentStops == maxStops) return routes;
        if (currentDistance >= maxDistance) return routes;
        
        var startNode = _getNode(start);

        foreach(var edge in startNode.Edges)
        {
            routes = _getNumberOfRoutesHelper(edge.Destination, end, maxStops, maxDistance, currentStops + 1, currentDistance + edge.Weight, routes);
        }
        return routes;
    }

    /// <summary>
    /// Gets the distance of a specified route
    /// </summary>
    /// <param name="route">Route denoted by array of characters</param>
    /// <returns></returns>
    /// <exception cref="Exception">General exception is thrown if route does not exist</exception>
    public int GetRouteDistance(char[] route)
    {
        var distance = 0;
        var previousNode = _getNode(route[0]);
        for (var i = 1; i < route.Length; i++)
        {
            var currentNode = _getNode(route[i]);
            var edge = previousNode.Edges.FirstOrDefault(e => e.Destination == currentNode.Name);
            if (edge == null)
            {
                throw new Exception("NO SUCH ROUTE");
            }
            distance += edge.Weight;
            previousNode = currentNode;
        }

        return distance;
    }

    /// <summary>
    /// Gets the total number of routes between two nodes
    /// </summary>
    /// <param name="start">Start node as represented by a character</param>
    /// <param name="end">End node as represented by a character</param>
    /// <param name="maxStops">Maximum number of allowed stops</param>
    /// <param name="maxDistance">Maximum allowed distance</param>
    /// <returns>Total number routes</returns>
    public int GetNumberOfRoutes(char start, char end , int maxStops = 100, int maxDistance = 100)
    {
        return _getNumberOfRoutesHelper(start, end, maxStops, maxDistance, 0, 0, 0);
    }

    /// <summary>
    /// Gets the shortest distance between two nodes
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns>Distance of the shortest path</returns>
    /// <exception cref="Exception">General exception is thrown if route does not exist</exception>
    public int GetShortestRouteDistance(char start, char end)
    {
        var nodeQueue = new Queue<Node>();
        nodeQueue.Enqueue(_getNode(start));
        
        // -1 is used to denote that the node has not been visited 
        var shortestDistancePerNode = Nodes.ToDictionary(node => node.Name, _ => -1);
        
        // initialize the first node shortest distance to 0
        shortestDistancePerNode[start] = 0;
        while (nodeQueue.Count > 0)
        {
            var currentNode = nodeQueue.Dequeue();
            foreach (var edge in currentNode.Edges)
            {
                // first we check if the node has been visited
                if (shortestDistancePerNode[edge.Destination] <= 0 ||
                    shortestDistancePerNode[edge.Destination] > shortestDistancePerNode[currentNode.Name] + edge.Weight)
                {
                    shortestDistancePerNode[edge.Destination] = shortestDistancePerNode[currentNode.Name] + edge.Weight;
                    nodeQueue.Enqueue(_getNode(edge.Destination));
                }
            }
        }

        if (shortestDistancePerNode[end] == -1)
            throw new Exception("NO SUCH ROUTE");
        return shortestDistancePerNode[end];
    }
}