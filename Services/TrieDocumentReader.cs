public class TrieDocumentReader
{
    public TrieDocument ReadFromDocument(string filePath)
    {
        if (!Helpers.IsFileExist(filePath))
        {
            return new TrieDocument();
        }
        
        string[] lines = File.ReadAllLines(filePath);
        TrieNode root = new();

        foreach (string line in lines)
        {
            string[] words = line.Split([' ', ',', '.', '!', '?', ':', ';', '-', '"', '\'', '*'], 
            StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                root.InsertWord(word.ToLower());
            }
        }

        return new TrieDocument
        {
            Lines = lines,
            Root = root
        };
    }
}