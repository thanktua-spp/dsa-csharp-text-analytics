public interface IDocumentAnalyser<T> where T : IDocument
{
    int CountLines(T document);
    int CountWords(T document);
    Dictionary<string, int> GetWordFrequency(T document);
    KeyValuePair<string, int> MaxWordLength(T document);
    KeyValuePair<string, int> MaxWordCount(T document);
    int ComputeWordFrequency(string word, T document);
}
