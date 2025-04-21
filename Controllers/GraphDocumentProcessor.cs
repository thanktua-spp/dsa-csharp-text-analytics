public class GraphDocumentProcessor : BaseDocumentProcessor<GraphDocument, GraphDocumentAnalyser>
{
    public GraphDocumentProcessor(string filePath)
        : base(new GraphDocumentReader().ReadFromDocument(filePath))
    {
    }
}
