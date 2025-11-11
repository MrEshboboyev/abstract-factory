using AbstractFactory.Domain.Documents;

namespace AbstractFactory.Infrastructure.Documents;

/// <summary>
/// Base implementation for documents
/// </summary>
public abstract class BaseDocument : IDocument
{
    protected string _content = string.Empty;
    protected ITheme? _appliedTheme;
    
    /// <summary>
    /// Gets the document type
    /// </summary>
    public abstract string DocumentType { get; }
    
    /// <summary>
    /// Sets the content for the document
    /// </summary>
    /// <param name="content">The content to set</param>
    public void SetContent(string content)
    {
        _content = content ?? throw new ArgumentNullException(nameof(content));
    }
    
    /// <summary>
    /// Applies a theme to the document
    /// </summary>
    /// <param name="theme">The theme to apply</param>
    public void ApplyTheme(ITheme theme)
    {
        _appliedTheme = theme ?? throw new ArgumentNullException(nameof(theme));
    }
    
    /// <summary>
    /// Generates the document content
    /// </summary>
    /// <returns>The generated document content</returns>
    public abstract string GenerateContent();
}
