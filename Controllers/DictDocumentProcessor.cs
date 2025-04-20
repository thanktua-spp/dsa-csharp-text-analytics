class DictDocumentProcessor
{
    private readonly DictDocumentReader reader;
    private readonly DictDocumentAnalyser analyser;
    private readonly DictDocument document;
    private Dictionary<string, int> wordFreqMapping;

    public DictDocumentProcessor(string filePath)
    {
        reader = new DictDocumentReader();
        analyser = new DictDocumentAnalyser();

        var lines = reader.ReadFromDocument(filePath);
        wordFreqMapping = analyser.WordCountMapping(lines); // solution 3

        document = new DictDocument(lines, wordFreqMapping);
    }

    public void DisplayText()
    {
        Array.ForEach(document.TextLines, Console.WriteLine);
    }

    public void DisplayWordsAndLineCounts()
    {
        int numberLines = analyser.CountLines(document.TextLines);
        int numberWords = analyser.CountWords(document.WordFreqMapping);
        Console.WriteLine();
        Console.WriteLine($"Number of Lines in text : {numberLines}");
        Console.WriteLine($"Number of Words in text : {numberWords}");
    }

    public void FindWordLineNumber(string word)
    {

        List<int> wordLineNumbers = analyser.LinesWithWord(word.ToLower(), document.TextLines);
        string lineNumbers = string.Join(", ", wordLineNumbers);
        Console.WriteLine($"'{word}' appears in lineNumbers : {lineNumbers}");
    }

    public void SearchMostFrequentWord()
    {
        var mostFreqWord = analyser.MaxWordCount(document.WordFreqMapping);
        Console.WriteLine($"Most frequent word : '{mostFreqWord.Key}', with count : {mostFreqWord.Value}");
    }

    public void LongestWordFrequency()
    {
        var longestWordFreq = analyser.MaxWordLength(document.WordFreqMapping);
        Console.WriteLine($"Longest word : '{longestWordFreq.Key}' , with count : {longestWordFreq.Value}");
    }

    public void SearchWordFrequency(string word)
    {
        int wordFrequencyCount = analyser.ComputeWordFrequency(word, document.WordFreqMapping);
        Console.WriteLine($"'{word}' appears {wordFrequencyCount} times");
    }

    public void DisplayWordFrequency(string order = "any")
    {
        Console.WriteLine();
        if (order.ToLower() == "any")
        {
            foreach (var entry in document.WordFreqMapping)
            {
                Console.Write($"{entry.Key} : {entry.Value} , ");
            }
        }
        else if (order.ToLower() == "descending")
        {
            var sortedDescending = document.WordFreqMapping.OrderByDescending(pair => pair.Key);
            foreach (var entry in sortedDescending)
            {
                Console.Write($"{entry.Key} : {entry.Value} , ");
            }
        }
        else if (order.ToLower() == "ascending")
        {
            var sortedAscending = document.WordFreqMapping.OrderBy(pair => pair.Key);
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