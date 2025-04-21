public class TrieDocument : IDocument
{
    public string[] Lines { get; set; } = [];
    public TrieNode Root { get; set; } = new();
}
public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; } = [];
    public bool IsEndOfWord { get; set; } = false;
    public int Frequency { get; set; } = 0;

    // Insert word into the Trie
    public void InsertWord(string word)
    {
        TrieNode current = this;
        foreach (char c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children[c] = new TrieNode();
            }
            current = current.Children[c];
        }
        current.IsEndOfWord = true;
        current.Frequency++;
    }

    // Get frequency of a specific word
    public int GetFrequency(string word)
    {
        TrieNode current = this;
        foreach (char c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                return 0;
            }
            current = current.Children[c];
        }
        return current.IsEndOfWord ? current.Frequency : 0;
    }

    // Recursively collect all words and their frequencies
    public Dictionary<string, int> GetAllWordsFrequency()
    {
        Dictionary<string, int> results = new();
        CollectWords(this, "", results);
        return results;
    }

    private void CollectWords(TrieNode node, string currentWord, Dictionary<string, int> results)
    {
        if(node.IsEndOfWord)
        {
            results[currentWord] = node.Frequency;
        }

        // use preorder node traversal
        foreach (var child in node.Children)
        {
            CollectWords(child.Value, currentWord + child.Key, results);
        }
    }
}