using AbstractFactory.Domain.Documents;
using AbstractFactory.Infrastructure.Documents.Excel;
using AbstractFactory.Infrastructure.Documents.PDF;
using AbstractFactory.Infrastructure.Documents.PowerPoint;
using AbstractFactory.Infrastructure.Documents.Themes;
using AbstractFactory.Infrastructure.Documents.Word;

namespace AbstractFactory.Infrastructure.Documents;

/// <summary>
/// Universal document factory that can create all supported document types
/// </summary>
public class UniversalDocumentFactory : IDocumentFactory
{
    /// <summary>
    /// Gets the factory name
    /// </summary>
    public string FactoryName => "Universal Document Factory";
    
    /// <summary>
    /// Creates a document of the specified type
    /// </summary>
    /// <param name="documentType">The type of document to create</param>
    /// <returns>A new document instance</returns>
    public IDocument CreateDocument(string documentType)
    {
        return documentType.ToLower() switch
        {
            "pdf" => new PdfDocument(),
            "word" => new WordDocument(),
            "excel" => new ExcelDocument(),
            "powerpoint" => new PowerPointDocument(),
            _ => throw new NotSupportedException($"Document type '{documentType}' is not supported by {FactoryName}")
        };
    }
    
    /// <summary>
    /// Creates a theme of the specified type
    /// </summary>
    /// <param name="themeType">The type of theme to create</param>
    /// <returns>A new theme instance</returns>
    public ITheme CreateTheme(string themeType)
    {
        return themeType.ToLower() switch
        {
            "classic" => new ClassicTheme(),
            "modern" => new ModernTheme(),
            "corporate" => new CorporateTheme(),
            "minimalist" => new MinimalistTheme(),
            _ => throw new NotSupportedException($"Theme type '{themeType}' is not supported by {FactoryName}")
        };
    }
    
    /// <summary>
    /// Checks if this factory can create the specified document type
    /// </summary>
    /// <param name="documentType">The document type to check</param>
    /// <returns>True if the factory can create this document type, false otherwise</returns>
    public bool CanCreateDocument(string documentType)
    {
        var supportedDocuments = new[] { "pdf", "word", "excel", "powerpoint" };
        return supportedDocuments.Contains(documentType.ToLower());
    }
    
    /// <summary>
    /// Checks if this factory can create the specified theme type
    /// </summary>
    /// <param name="themeType">The theme type to check</param>
    /// <returns>True if the factory can create this theme type, false otherwise</returns>
    public bool CanCreateTheme(string themeType)
    {
        var supportedThemes = new[] { "classic", "modern", "corporate", "minimalist" };
        return supportedThemes.Contains(themeType.ToLower());
    }
}
