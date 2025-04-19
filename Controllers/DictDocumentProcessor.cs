class DictDocumentProcessor
{
    private readonly DictDocumentReader reader;
    private readonly DictDocumentAnalyser analyser;
    private readonly string[] textCopus;
    private Dictionary<string, int> wordFreqMapping;

    public DictDocumentProcessor(string filePath)
    {
        reader = new DictDocumentReader();
        analyser = new DictDocumentAnalyser();
        textCopus = reader.ReadFromDocument(filePath);
        wordFreqMapping = analyser.WordCountMapping(textCopus); // solution 3
    }

    public void DisplayText()
    {
        Array.ForEach(textCopus, Console.WriteLine);
    }

    public void DisplayWordsAndLineCounts()
    {
        int numberLines = analyser.CountLines(textCopus);
        int numberWords = analyser.CountWords(wordFreqMapping);
        Console.WriteLine();
        Console.WriteLine($"Number of Lines in text : {numberLines}");
        Console.WriteLine($"Number of Words in text : {numberWords}");
    }

    public void FindWordLineNumber(string word)
    {

        List<int> wordLineNumbers = analyser.LinesWithWord(word.ToLower(), textCopus);
        string lineNumbers = string.Join(", ", wordLineNumbers);
        Console.WriteLine($"'{word}' appears in lineNumbers : {lineNumbers}");
    }

    public void SearchMostFrequentWord()
    {
        var mostFreqWord = analyser.MaxWordCount(wordFreqMapping);
        Console.WriteLine($"Most frequent word : '{mostFreqWord.Key}', with count : {mostFreqWord.Value}");
    }

    public void LongestWordFrequency()
    {
        var longestWordFreq = analyser.MaxWordLength(wordFreqMapping);
        Console.WriteLine($"Longest word : '{longestWordFreq.Key}' , with count : {longestWordFreq.Value}");
    }

    public void SearchWordFrequency(string word)
    {
        int wordFrequencyCount = analyser.ComputeWordFrequency(word, wordFreqMapping);
        Console.WriteLine($"'{word}' appears {wordFrequencyCount} times");
    }

    public void DisplayWordFrequency(string order = "any")
    {
        Console.WriteLine();
        if (order.ToLower() == "any")
        {
            foreach (var entry in wordFreqMapping)
            {
                Console.Write($"{entry.Key} : {entry.Value} , ");
            }
        }
        else if (order.ToLower() == "descending")
        {
            var sortedDescending = wordFreqMapping.OrderByDescending(pair => pair.Key);
            foreach (var entry in sortedDescending)
            {
                Console.Write($"{entry.Key} : {entry.Value} , ");
            }
        }
        else if (order.ToLower() == "ascending")
        {
            var sortedAscending = wordFreqMapping.OrderBy(pair => pair.Key);
            foreach (var entry in sortedAscending)
            {
                Console.Write($"{entry.Key} : {entry.Value} , ");
            }
        }
        else
        {
            Console.WriteLine("Invilid order selection");
        }
    }
}