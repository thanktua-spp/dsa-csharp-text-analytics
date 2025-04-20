
class DictDocumentReader()
{
    public DictDocument ReadFromDocument(string filePathName)
    {
        if (!FileHelper.IsFileExist(filePathName))
        {   
            return new DictDocument;
        }
        
        
    }



    public Dictionary<string, int> WordCountMapping(string[] extractedText)
    {
        Dictionary<string, int> wordFreqDict = [];
        char[] delimiters = [' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*'];
        foreach (string line in extractedText)
        {
            foreach (string word in line.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries)
                                        .Select(w => w.ToLower()))
            {
                if (wordFreqDict.TryGetValue(word, out int value))
                {
                    wordFreqDict[word] = ++value;
                }
                else
                {
                    wordFreqDict[word] = 1;
                }
            }
        }
        return wordFreqDict;
    }
}