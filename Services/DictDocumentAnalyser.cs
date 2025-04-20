class DictDocumentAnalyser
{    
    static Boolean IsWord(string str)
    {
        return true; //MyRegex().IsMatch(str);
    }

    public int CountLines(string[] extractedText) => extractedText.Length;
    public int CountWords(Dictionary<string, int> wordFreqDict) => wordFreqDict.Count;

    public int ComputeWordFrequency(string word, Dictionary<string, int> wordFreqDict)
    {
        return wordFreqDict.TryGetValue(word.ToLower(), out int count) ? count : 0; // assumes words are not case sensitive
    }

    private bool IsWordInLineNumber(string word, string line)
    {
        return line.Split().Contains(word);
    }

    public List<int> LinesWithWord(string word, string[] extractedText)
    {
        List<int> lineNumbers = [];
        foreach (var (line, index) in extractedText.Select((line, index) => (line, index)))
        {
            if (IsWordInLineNumber(word, line))
            {
                lineNumbers.Add(index + 1);
            }
        }
        return lineNumbers;
    }

    public KeyValuePair<string, int> MaxWordCount(Dictionary<string, int> wordFreqDict)
    {
        return wordFreqDict.MaxBy(kvp => kvp.Value); //using Linq
    }
    public KeyValuePair<string, int> MaxWordLength(Dictionary<string, int> wordFreqDict)
    {
        var maxFreqWordCount = wordFreqDict.First();
        foreach (var entry in wordFreqDict)
        {
            if (entry.Key.Length > maxFreqWordCount.Key.Length)
            {
                maxFreqWordCount = entry;
            }
        }
        return maxFreqWordCount;
    }
}