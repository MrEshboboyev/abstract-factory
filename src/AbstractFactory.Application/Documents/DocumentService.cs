namespace AbstractFactory.Application.Documents;

using AbstractFactory.Domain.Documents;

/// <summary>
/// Service for generating themed documents
/// </summary>
/// <remarks>
/// Initializes a new instance of the DocumentService class
/// </remarks>
/// <param name="documentFactory">The document factory to use</param>
public class DocumentService(IDocumentFactory documentFactory)
{
    /// <summary>
    /// Generates a themed document of the specified type
    /// </summary>
    /// <param name="documentType">The type of document to generate</param>
    /// <param name="themeType">The type of theme to apply</param>
    /// <param name="content">The content for the document</param>
    /// <returns>The generated themed document content</returns>
    public string GenerateThemedDocument(string documentType, string themeType, string content)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(documentType))
            throw new ArgumentException("Document type cannot be null or empty", nameof(documentType));
            
        if (string.IsNullOrWhiteSpace(themeType))
            throw new ArgumentException("Theme type cannot be null or empty", nameof(themeType));
            
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be null or empty", nameof(content));
        
        // Check if factory can create the requested document and theme types
        if (!documentFactory.CanCreateDocument(documentType))
            throw new NotSupportedException($"Factory '{documentFactory.FactoryName}' cannot create document type '{documentType}'");
            
        if (!documentFactory.CanCreateTheme(themeType))
            throw new NotSupportedException($"Factory '{documentFactory.FactoryName}' cannot create theme type '{themeType}'");
        
        // Create document and theme
        var document = documentFactory.CreateDocument(documentType);
        var theme = documentFactory.CreateTheme(themeType);
        
        // Set content and apply theme
        document.SetContent(content);
        document.ApplyTheme(theme);
        
        // Generate and return the document content
        return document.GenerateContent();
    }
    
    /// <summary>
    /// Gets information about the current factory
    /// </summary>
    /// <returns>Factory information</returns>
    public string GetFactoryInfo()
    {
        return $"Using factory: {documentFactory.FactoryName}";
    }
}
