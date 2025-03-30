using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO.Enumeration;

class Program
{
    static void Main()
    {
        string fileName = "/perfect.txt"; 
        string basePath = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string filePathString = basePath + fileName;

        DocumentProcessor docProcessor = new(filePathString); // solution 1.
        docProcessor.DisplayText(); 
        //docProcessor.DisplayWordsAndLineCounts(); // solution 2. and 3.0
        //docProcessor.DisplayWordFrequency("any"); // solution 4.
        //docProcessor.DisplayWordFrequency("ascending"); // solution 5.1
        //docProcessor.DisplayWordFrequency("descending"); // solution 5.2
        //docProcessor.LongestWordFrequency(); // solution 6.
        //docProcessor.SearchMostFrequentWord(); // solution 7.
        docProcessor.FindWordLineNumber("he"); // solution 8  //todo. add word not found
        docProcessor.SearchWordFrequency("he"); // solution 9. //todo. add word not found
    }
}

class DocumentProcessor
{
    private readonly DocumentReader reader;
    private readonly DocumentAnalyser analyser;
    private readonly string[] textCopus;
    private Dictionary<string, int> wordFreqMapping;

    public DocumentProcessor(string filePath)
    {
        reader = new DocumentReader();
        analyser = new DocumentAnalyser();
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

class DocumentAnalyser
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

    public Dictionary<string, int> WordCountMapping(string[] extractedText)
    {
        Dictionary<string, int> wordFreq = [];
        char[] delimiters = [' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*'];
        foreach (string line in extractedText)
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


class DocumentReader()
{
    public static bool IsFileExist(string filePathName)
    {
        if (File.Exists(filePathName))
        {
            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine($"Reading from file {Path.GetFileName(filePathName)}");
            Console.WriteLine("**********************************");
            Console.WriteLine();
            return true;
        }
        else
        {
            Console.WriteLine($" File {filePathName} Not Found");
            return false;
        }
    }

    public string[] ReadFromDocument(string filePathName)
    {
        if (IsFileExist(filePathName))
        {   
            return File.ReadAllLines(filePathName);
        }
        return [];
    }
}






























// partial class Program
// {
//     [GeneratedRegex(@"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase, "en-GB")]
//     private static partial Regex MyRegex();
// }





// static int CountWords(string extractedText)
// {
//     int numberWords = 0;
//     //delimiters are chars that split words in a text file
//     char[] delimiters = { ' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*' };
//     foreach (string line in linesInFile) //take each line string form the file one at a time
//     {
//         lineNumber++; //increment the current line number
//         //split up line into separate words using any delimiter - array of strings, each element is a word on the current line
//         string[] wordsInLine = line.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
//         Console.Write(lineNumber + ":"); //display file line number
//         foreach (string word in wordsInLine)
//         {
//             if (isWord(word))
//             {
//                 numberWords++;
//                 Console.Write(word.ToLower() + ","); //display lowercase version of word
//             }
//         }
//         return numberWords;
//     }
// }
