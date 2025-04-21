
using System.Data;

public static class Helpers
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

    public static void SortWords(Dictionary<string, int> mapping, string order)
    {
        var sorted = order.ToLower() switch
        {
            "descending" => mapping.OrderByDescending(pair => pair.Key).AsEnumerable(),
            "ascending" => mapping.OrderBy(pair => pair.Key).AsEnumerable(),
            "any" => mapping,
            _ => null
        };

        if (sorted == null)
        {
            Console.WriteLine("Invalid order selection");
            return;
        }

        Console.WriteLine($"Sorting words in {order} order: ");
        foreach (var entry in sorted)
        {
            Console.Write($"{entry.Key} : {entry.Value} , ");
        }
        Console.WriteLine("\n");
    }

    public static List<int> LinesWithWord(string word, IDocument document)
    {
        List<int> lineNumbers = [];
        foreach (var (line, index) in document.Lines.Select((line, index) => (line, index)))
        {
            if (line.Split().Contains(word))
            {
                lineNumbers.Add(index + 1);
            }
        }
        return lineNumbers;
    }
}
