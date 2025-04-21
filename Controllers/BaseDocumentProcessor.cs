public abstract class BaseDocumentProcessor<TDocument, TAnalyser>
    where TDocument : IDocument
    where TAnalyser : IDocumentAnalyser<TDocument>, new()
{
    protected readonly TDocument _document;
    protected readonly TAnalyser _analyser = new();

    protected BaseDocumentProcessor(TDocument document)
    {
        _document = document;
    }

    public void DisplayText()
    {
        Array.ForEach(_document.Lines, Console.WriteLine);
        Console.WriteLine();
    }

    public void DisplayWordsAndLineCounts()
    {
        int lineCount = _analyser.CountLines(_document);
        int wordCount = _analyser.CountWords(_document);

        Console.WriteLine($"Number of Lines in text : {lineCount}");
        Console.WriteLine($"Number of Words in text : {wordCount}");
        Console.WriteLine();
    }

    public void DisplayWordFrequency(string order = "any")
    {
        var mapping = _analyser.GetWordFrequency(_document);
        Helpers.SortWords(mapping, order);
    }

    public void LongestWordFrequency()
    {
        var longest = _analyser.MaxWordLength(_document);
        Console.WriteLine($"Longest word : '{longest.Key}' , with count : {longest.Value}");
        Console.WriteLine();
    }

    public void SearchMostFrequentWord()
    {
        var freq = _analyser.MaxWordCount(_document);
        Console.WriteLine($"Most frequent word : '{freq.Key}', with count : {freq.Value}");
        Console.WriteLine();
    }

    public void FindWordLineNumber(string word)
    {
        var lines = Helpers.LinesWithWord(word.ToLower(), _document);
        Console.WriteLine($"'{word}' appears in lineNumbers : {string.Join(", ", lines)}");
        Console.WriteLine();
    }

    public void SearchWordFrequency(string word)
    {
        int count = _analyser.ComputeWordFrequency(word, _document);
        Console.WriteLine($"'{word}' appears {count} times");
        Console.WriteLine();
    }
}
