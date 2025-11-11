using AbstractFactory.Domain.Documents;
using AbstractFactory.Infrastructure.Documents.Themes;

namespace AbstractFactory.Infrastructure.Documents.PDF;

/// <summary>
/// Modern PDF factory implementation
/// </summary>
public class ModernPdfFactory : IDocumentFactory
{
    /// <summary>
    /// Gets the factory name
    /// </summary>
    public string FactoryName => "Modern PDF Factory";
    
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
            "modern" => new ModernTheme(),
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
        return documentType.Equals("pdf", StringComparison.CurrentCultureIgnoreCase);
    }
    
    /// <summary>
    /// Checks if this factory can create the specified theme type
    /// </summary>
    /// <param name="themeType">The theme type to check</param>
    /// <returns>True if the factory can create this theme type, false otherwise</returns>
    public bool CanCreateTheme(string themeType)
    {
        var supportedThemes = new[] { "modern", "minimalist" };
        return supportedThemes.Contains(themeType.ToLower());
    }
}
