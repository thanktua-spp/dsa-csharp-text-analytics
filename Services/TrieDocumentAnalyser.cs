public class TrieDocumentAnalyser : IDocumentAnalyser<TrieDocument>
{
    public int CountLines(TrieDocument document)
    {
        return document.Lines.Length;
    }

    public int CountWords(TrieDocument document)
    {
        return document.Root.GetAllWordsFrequency().Count;
    }

    public Dictionary<string, int> GetWordFrequency(TrieDocument document)
    {
        return document.Root.GetAllWordsFrequency();
    }
    public int ComputeWordFrequency(string word, TrieDocument document)
    {
        return document.Root.GetFrequency(word.ToLower());
    }

    public KeyValuePair<string, int> MaxWordCount(TrieDocument document)
    {
        var allwords = document.Root.GetAllWordsFrequency();
        return allwords.MaxBy(pair => pair.Value);
    }

    public KeyValuePair<string, int> MaxWordLength(TrieDocument document)
    {
        var allwords = document.Root.GetAllWordsFrequency();
        return allwords.MaxBy(pair => pair.Key.Length);
    }
}