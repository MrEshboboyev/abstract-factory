namespace AbstractFactory.Infrastructure.Documents.PDF;

using AbstractFactory.Domain.Documents;
using AbstractFactory.Infrastructure.Documents.Themes;

public class ModernPdfFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new PdfDocument();
    }

    public ITheme CreateTheme()
    {
        return new ModernTheme();
    }
} 