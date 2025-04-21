using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "/Data/perfect.txt"; 
        string basePath = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string filePathString = basePath + fileName;

        //// Using A Dictionary Model
        Console.WriteLine("Result from Dictionary Docs");
        DictDocumentProcessor dictDocProcessor = new(filePathString); // solution 1.
        //dictDocProcessor.DisplayText();  // works
        dictDocProcessor.DisplayWordsAndLineCounts(); // solution 2. and 3.0  //works
        dictDocProcessor.DisplayWordFrequency("any"); // solution 4.
        dictDocProcessor.DisplayWordFrequency("ascending"); // solution 5.1
        dictDocProcessor.DisplayWordFrequency("descending"); // solution 5.2 // all works
        dictDocProcessor.LongestWordFrequency(); // solution 6. // works
        dictDocProcessor.SearchMostFrequentWord(); // solution 7.
        dictDocProcessor.FindWordLineNumber("the"); // solution 8  //works
        dictDocProcessor.SearchWordFrequency("1"); // solution 9. //works

        //// Using A Tree Model
        Console.WriteLine();
        Console.WriteLine("Result from Trie Docs");
        TrieDocumentProcessor trieDocProcessor = new(filePathString); // solution 1.
        //trieDocProcessor.DisplayText(); // works
        trieDocProcessor.DisplayWordsAndLineCounts(); // solution 2. and 3.0 //works
        trieDocProcessor.DisplayWordFrequency("any"); // solution 4.
        trieDocProcessor.DisplayWordFrequency("ascending"); // solution 5.1
        trieDocProcessor.DisplayWordFrequency("descending"); // solution 5.2 // all works
        trieDocProcessor.LongestWordFrequency(); // solution 6. // works
        trieDocProcessor.SearchMostFrequentWord(); // solution 7.
        trieDocProcessor.FindWordLineNumber("the"); // solution 8  //works
        trieDocProcessor.SearchWordFrequency("1"); // solution 9. //works

        //// Using A Graph Model
        Console.WriteLine();
        Console.WriteLine("Result from Graph Docs");
        GraphDocumentProcessor graphDocProcessor = new(filePathString); // solution 1.
        //graphDocProcessor.DisplayText(); // works
        graphDocProcessor.DisplayWordsAndLineCounts(); // solution 2. and 3.0 //works
        graphDocProcessor.DisplayWordFrequency("any"); // solution 4.
        graphDocProcessor.DisplayWordFrequency("ascending"); // solution 5.1
        graphDocProcessor.DisplayWordFrequency("descending"); // solution 5.2 // all works
        graphDocProcessor.LongestWordFrequency(); // solution 6. // works
        graphDocProcessor.SearchMostFrequentWord(); // solution 7.
        graphDocProcessor.FindWordLineNumber("the"); // solution 8  //works
        graphDocProcessor.SearchWordFrequency("1"); // solution 9. //works
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
