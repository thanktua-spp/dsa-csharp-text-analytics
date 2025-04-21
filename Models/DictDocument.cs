
public class DictDocument: IDocument
{   
    public string[] Lines { get; set; } = []; 
    public Dictionary<string, int> WordFreq { get; set; } = [];
}