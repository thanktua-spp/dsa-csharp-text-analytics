public class GraphDocument : IDocument
{
    public string[] Lines {get; set; } = [];
    public Dictionary<string, GraphNode> Nodes { get; set; } = [];

    public Dictionary<string, int> GetWordsFrequency()
    {
        var visited = new HashSet<string>();
        var freq = new Dictionary<string, int>();

        foreach (var startNode in Nodes.Values)
        {
            if (visited.Contains(startNode.Word))
                continue;

            var stack = new Stack<GraphNode>();
            stack.Push(startNode);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (visited.Contains(current.Word))
                    continue;

                visited.Add(current.Word);
                freq[current.Word] = current.Neighbors.Values.Sum();

                foreach (var neighborWord in current.Neighbors.Keys)
                {
                    if (Nodes.TryGetValue(neighborWord, out var neighborNode) && !visited.Contains(neighborWord))
                    {
                        stack.Push(neighborNode);
                    }
                }
            }
        }

        return freq;
    }
}

public class GraphNode
{
    public string Word { get; set; }
    public Dictionary<string, int> Neighbors { get; set; } = [];

    public GraphNode(string word)
    {
        Word = word;
    }
    
    public void AddNeighbor(string neighbor)
    {
        if (Neighbors.ContainsKey(neighbor))
            Neighbors[neighbor]++;
        else
            Neighbors[neighbor] = 1;
    }
}