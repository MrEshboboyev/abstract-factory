namespace AbstractFactory.Infrastructure.Documents.Word;

using AbstractFactory.Domain.Documents;

public class WordDocument : IDocument
{
    private string _content = string.Empty;
    
    public string GenerateDocument()
    {
        return $"Generated Word Document with content: {_content}";
    }

    public void SetContent(string content)
    {
        _content = content;
    }
} 