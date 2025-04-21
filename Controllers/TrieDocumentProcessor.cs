public class TrieDocumentProcessor : BaseDocumentProcessor<TrieDocument, TrieDocumentAnalyser>
{
    public TrieDocumentProcessor(string filePath)
        : base(new TrieDocumentReader().ReadFromDocument(filePath))
    {
    }
}
