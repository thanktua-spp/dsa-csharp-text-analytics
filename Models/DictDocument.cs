
public class DictDocument
{
    public string[] TextLines { get; set; }
    public Dictionary<string, int> WordFreqMapping { get; set; }

    public DictDocument(string[] textLines, Dictionary<string, int> wordFreqMapping)
    {
        TextLines = textLines;
        WordFreqMapping = wordFreqMapping;
    }
}