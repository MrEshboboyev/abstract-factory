using AbstractFactory.Domain.Documents;

namespace AbstractFactory.Infrastructure.Documents;

/// <summary>
/// Base implementation for document factories
/// </summary>
public abstract class BaseDocumentFactory : IDocumentFactory
{
    /// <summary>
    /// Gets the factory name
    /// </summary>
    public abstract string FactoryName { get; }
    
    /// <summary>
    /// Creates a document of the specified type
    /// </summary>
    /// <param name="documentType">The type of document to create</param>
    /// <returns>A new document instance</returns>
    public abstract IDocument CreateDocument(string documentType);
    
    /// <summary>
    /// Creates a theme of the specified type
    /// </summary>
    /// <param name="themeType">The type of theme to create</param>
    /// <returns>A new theme instance</returns>
    public abstract ITheme CreateTheme(string themeType);
    
    /// <summary>
    /// Checks if this factory can create the specified document type
    /// </summary>
    /// <param name="documentType">The document type to check</param>
    /// <returns>True if the factory can create this document type, false otherwise</returns>
    public abstract bool CanCreateDocument(string documentType);
    
    /// <summary>
    /// Checks if this factory can create the specified theme type
    /// </summary>
    /// <param name="themeType">The theme type to check</param>
    /// <returns>True if the factory can create this theme type, false otherwise</returns>
    public abstract bool CanCreateTheme(string themeType);
}
