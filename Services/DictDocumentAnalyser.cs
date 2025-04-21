public class DictDocumentAnalyser : IDocumentAnalyser<DictDocument>
{    
    public int CountLines(DictDocument document) => document.Lines.Length;
    public int CountWords(DictDocument document) => document.WordFreq.Values.Sum();

    public Dictionary<string, int> GetWordFrequency(DictDocument doc) => doc.WordFreq;
    public int ComputeWordFrequency(string word, DictDocument document)
    {
        return document.WordFreq.TryGetValue(word.ToLower(), out int count) ? count : 0; // assumes words are not case sensitive
    }

    public KeyValuePair<string, int> MaxWordCount(DictDocument document)
    {
        return document.WordFreq.MaxBy(kvp => kvp.Value); //using Linq
    }
    public KeyValuePair<string, int> MaxWordLength(DictDocument document)
    {
        var maxFreqWordCount = document.WordFreq.First();
        foreach (var entry in document.WordFreq)
        {
            if (entry.Key.Length > maxFreqWordCount.Key.Length)
            {
                maxFreqWordCount = entry;
            }
        }
        return maxFreqWordCount;
    }
}