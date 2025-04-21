public class DictDocumentProcessor : BaseDocumentProcessor<DictDocument, DictDocumentAnalyser>
{
    public DictDocumentProcessor(string filePath)
        : base(new DictDocumentReader().ReadFromDocument(filePath))
    {
    }
}
