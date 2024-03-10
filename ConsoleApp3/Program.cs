using ConsoleApp3;

var nodes = new Dictionary<string, Node>
{
    ["A"] = new Node("A"),
    ["B"] = new Node("B"),
    ["C"] = new Node("C"),
    ["D"] = new Node("D"),


};

nodes["A"].AddEdge(nodes["D"], 1).AddEdge(nodes["B"], 3).AddEdge(nodes["C"], 3);
nodes["B"].AddEdge(nodes["A"], 3).AddEdge(nodes["D"], 1).AddEdge(nodes["C"], 3);
nodes["C"].AddEdge(nodes["B"], 3).AddEdge(nodes["D"], 1).AddEdge(nodes["A"], 3);
nodes["D"].AddEdge(nodes["A"], 1).AddEdge(nodes["B"], 1).AddEdge(nodes["C"], 1);


var finalNode = nodes["C"];



var distances = nodes.ToDictionary(kvp => kvp.Value, kvp => (int?)int.MaxValue);
var parents = new Dictionary<Node, Node>();
var undiscoveredNodes = new HashSet<Node>(nodes.Values);

distances[nodes["A"]] = 0;

while (undiscoveredNodes.Count > 0)
{
    var current = undiscoveredNodes.MinBy(node => distances[node]); undiscoveredNodes.Remove(current);
    if (current == finalNode)
        break;
    foreach (var (adjacentNode, distance) in current.Edges)
    {
        var subDistance = distances[current] + distance;
        if (subDistance < distances[adjacentNode])
        {
            distances[adjacentNode] = subDistance;
            parents[adjacentNode] = current;
        }
    }
}


var pathNodes = new List<Node>();
var currentNode = finalNode;

while (currentNode is not null)
{
    pathNodes.Insert(0, currentNode);
    currentNode = parents.TryGetValue(currentNode, out var parentNode) ? parentNode : null;
}

Console.WriteLine(string.Join(" ->", pathNodes.Select(i => i.Name)));

Console.WriteLine("Total Distance: {0}", distances[finalNode]);

Console.ReadLine();