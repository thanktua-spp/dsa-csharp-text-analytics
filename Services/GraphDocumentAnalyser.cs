public class GraphDocumentAnalyser : IDocumentAnalyser<GraphDocument>
{
    public int CountLines(GraphDocument document)
    {
        return document.Lines.Length;
    }

    public int CountWords(GraphDocument document)
    {
        return document.GetWordsFrequency().Values.Sum();
    }

    public Dictionary<string, int> GetWordFrequency(GraphDocument document)
    {
        return document.GetWordsFrequency();
    }

    public KeyValuePair<string, int> MaxWordLength(GraphDocument document)
    {
        var frequencies = document.GetWordsFrequency();
        
        var maxLengthQuery = 
            from word in frequencies.Keys
            let length = word.Length
            orderby length descending
            select new KeyValuePair<string, int>(word, length);

        return maxLengthQuery.FirstOrDefault();
    }

    public KeyValuePair<string, int> MaxWordCount(GraphDocument document)
    {
        var frequencies = document.GetWordsFrequency();
        
        var maxCountQuery =
            from kv in frequencies
            orderby kv.Value descending
            select kv;

        return maxCountQuery.FirstOrDefault();
    }

    public int ComputeWordFrequency(string word, GraphDocument document)
    {
        var frequencies = document.GetWordsFrequency();
        return frequencies.TryGetValue(word, out int freq) ? freq : 0;
    }
}
