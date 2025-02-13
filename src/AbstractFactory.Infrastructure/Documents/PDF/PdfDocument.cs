namespace AbstractFactory.Infrastructure.Documents.PDF;

using AbstractFactory.Domain.Documents;

public class PdfDocument : IDocument
{
    private string _content = string.Empty;
    
    public string GenerateDocument()
    {
        return $"Generated PDF Document with content: {_content}";
    }

    public void SetContent(string content)
    {
        _content = content;
    }
} 