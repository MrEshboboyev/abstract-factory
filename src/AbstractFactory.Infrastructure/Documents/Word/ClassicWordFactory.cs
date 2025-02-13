namespace AbstractFactory.Infrastructure.Documents.Word;

using AbstractFactory.Domain.Documents;
using AbstractFactory.Infrastructure.Documents.Themes;

public class ClassicWordFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new WordDocument();
    }

    public ITheme CreateTheme()
    {
        return new ClassicTheme();
    }
} 