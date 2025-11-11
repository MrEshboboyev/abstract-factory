namespace AbstractFactory.Domain.Documents;

/// <summary>
/// Represents a document that can be generated
/// </summary>
public interface IDocument
{
    /// <summary>
    /// Gets the document type
    /// </summary>
    string DocumentType { get; }
    
    /// <summary>
    /// Generates the document content
    /// </summary>
    /// <returns>The generated document content</returns>
    string GenerateContent();
    
    /// <summary>
    /// Sets the content for the document
    /// </summary>
    /// <param name="content">The content to set</param>
    void SetContent(string content);
    
    /// <summary>
    /// Applies a theme to the document
    /// </summary>
    /// <param name="theme">The theme to apply</param>
    void ApplyTheme(ITheme theme);
}
