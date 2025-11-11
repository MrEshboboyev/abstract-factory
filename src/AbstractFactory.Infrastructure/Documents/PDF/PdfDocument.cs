namespace AbstractFactory.Infrastructure.Documents.PDF;

/// <summary>
/// PDF document implementation
/// </summary>
public class PdfDocument : BaseDocument
{
    /// <summary>
    /// Gets the document type
    /// </summary>
    public override string DocumentType => "PDF";
    
    /// <summary>
    /// Generates the PDF document content
    /// </summary>
    /// <returns>The generated PDF document content</returns>
    public override string GenerateContent()
    {
        var themeInfo = _appliedTheme != null ? $" with {_appliedTheme.ThemeName} theme" : "";
        return $"Generated PDF Document{themeInfo}: {_content}";
    }
}
