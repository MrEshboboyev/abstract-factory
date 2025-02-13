namespace AbstractFactory.Application.Documents;

using AbstractFactory.Domain.Documents;

public class DocumentService(IDocumentFactory documentFactory)
{
    private readonly IDocumentFactory _documentFactory = documentFactory;

    public string GenerateThemedDocument(string content)
    {
        var document = _documentFactory.CreateDocument();
        var theme = _documentFactory.CreateTheme();

        document.SetContent(content);
        var documentContent = document.GenerateDocument();
        var themedContent = theme.ApplyTheme();

        return $"{documentContent} with {themedContent}";
    }
} 