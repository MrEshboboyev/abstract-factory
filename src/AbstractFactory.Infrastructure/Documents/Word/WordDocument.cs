using AbstractFactory.Infrastructure.Documents;

namespace AbstractFactory.Infrastructure.Documents.Word;

/// <summary>
/// Word document implementation
/// </summary>
public class WordDocument : BaseDocument
{
    /// <summary>
    /// Gets the document type
    /// </summary>
    public override string DocumentType => "Word";
    
    /// <summary>
    /// Generates the Word document content
    /// </summary>
    /// <returns>The generated Word document content</returns>
    public override string GenerateContent()
    {
        var themeInfo = _appliedTheme != null ? $" with {_appliedTheme.ThemeName} theme" : "";
        return $"Generated Word Document{themeInfo}: {_content}";
    }
}
