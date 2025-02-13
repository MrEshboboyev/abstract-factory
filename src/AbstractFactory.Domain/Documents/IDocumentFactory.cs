namespace AbstractFactory.Domain.Documents;

public interface IDocumentFactory
{
    IDocument CreateDocument();
    ITheme CreateTheme();
} 