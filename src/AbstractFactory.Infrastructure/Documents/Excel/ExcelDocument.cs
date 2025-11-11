namespace AbstractFactory.Infrastructure.Documents.Excel;

using AbstractFactory.Infrastructure.Documents;

/// <summary>
/// Excel document implementation
/// </summary>
public class ExcelDocument : BaseDocument
{
    /// <summary>
    /// Gets the document type
    /// </summary>
    public override string DocumentType => "Excel";
    
    /// <summary>
    /// Generates the Excel document content
    /// </summary>
    /// <returns>The generated Excel document content</returns>
    public override string GenerateContent()
    {
        var themeInfo = _appliedTheme != null ? $" with {_appliedTheme.ThemeName} theme" : "";
        return $"Generated Excel Spreadsheet{themeInfo}: {_content}";
    }
}
