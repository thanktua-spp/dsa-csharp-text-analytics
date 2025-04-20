public class TrieDocument
{
    public string[] TextLines { get; set; } = [];

    public TrieNode Root { get; set; } = new TrieNode();

    public void InsertWord(string word)
    {
        TrieNode current = Root;
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

    public int GetFrequency(string word)
    {
        TrieNode current = Root;
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

}
public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; } = [];
    public bool IsEndOfWord { get; set; } = false;
    public int Frequency { get; set; }
}