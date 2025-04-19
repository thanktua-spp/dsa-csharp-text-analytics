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

        DictDocumentProcessor docProcessor = new(filePathString); // solution 1.
        docProcessor.DisplayText(); 
        //docProcessor.DisplayWordsAndLineCounts(); // solution 2. and 3.0
        //docProcessor.DisplayWordFrequency("any"); // solution 4.
        //docProcessor.DisplayWordFrequency("ascending"); // solution 5.1
        //docProcessor.DisplayWordFrequency("descending"); // solution 5.2
        //docProcessor.LongestWordFrequency(); // solution 6.
        //docProcessor.SearchMostFrequentWord(); // solution 7.
        docProcessor.FindWordLineNumber("the"); // solution 8  //todo. add word not found
        docProcessor.SearchWordFrequency("the"); // solution 9. //todo. add word not found
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
