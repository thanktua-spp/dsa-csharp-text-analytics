public class GraphDocumentReader
{
    public GraphDocument ReadFromDocument(string filePath)
    {
        if (!Helpers.IsFileExist(filePath))
        {
            return new GraphDocument();
        }
        
        var lines = File.ReadAllLines(filePath);
        var document = new GraphDocument { Lines = lines };

        string? previousWord = null;

        foreach (string line in lines)
        {
            string[] words = line
                .ToLower()
                .Split([' ', ',', '.', '!', '?', ':', ';', '-', '"', '\'', '*'], 
                StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in words)
            {
                string currentWord = word;

                if (!document.Nodes.ContainsKey(currentWord))
                    document.Nodes[currentWord] = new GraphNode(currentWord);

                if (previousWord != null)
                    document.Nodes[previousWord].AddNeighbor(currentWord);
                
                previousWord = currentWord;
            }
        }
        return document;
    }
}