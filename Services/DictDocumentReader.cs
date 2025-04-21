
class DictDocumentReader()
{
    public DictDocument ReadFromDocument(string filePath)
    {
        if (!Helpers.IsFileExist(filePath))
        {   
            return new DictDocument(); // empty document
        }
        
        string[] lines = File.ReadAllLines(filePath);
        var wordFreq = WordCount(lines);

        return new DictDocument
        {
            Lines = lines,
            WordFreq = wordFreq
        };
        
    }


    public Dictionary<string, int> WordCount(string[] lines)
    {
        Dictionary<string, int> wordFreq = [];
        char[] delimiters = [' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*'];
        foreach (string line in lines)
        {
            foreach (string word in line.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries)
                                        .Select(w => w.ToLower()))
            {
                if (wordFreq.TryGetValue(word, out int value))
                {
                    wordFreq[word] = ++value;
                }
                else
                {
                    wordFreq[word] = 1;
                }
            }
        }
        return wordFreq;
    }
}