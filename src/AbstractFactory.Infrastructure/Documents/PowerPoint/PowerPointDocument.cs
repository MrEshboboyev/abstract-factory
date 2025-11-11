namespace AbstractFactory.Infrastructure.Documents.PowerPoint;

/// <summary>
/// PowerPoint document implementation
/// </summary>
public class PowerPointDocument : BaseDocument
{
    /// <summary>
    /// Gets the document type
    /// </summary>
    public override string DocumentType => "PowerPoint";
    
    /// <summary>
    /// Generates the PowerPoint document content
    /// </summary>
    /// <returns>The generated PowerPoint document content</returns>
    public override string GenerateContent()
    {
        var themeInfo = _appliedTheme != null ? $" with {_appliedTheme.ThemeName} theme" : "";
        return $"Generated PowerPoint Presentation{themeInfo}: {_content}";
    }
}
