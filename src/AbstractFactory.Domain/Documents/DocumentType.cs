namespace AbstractFactory.Domain.Documents;

/// <summary>
/// Enum representing the supported document types
/// </summary>
public enum DocumentType
{
    /// <summary>
    /// PDF document
    /// </summary>
    PDF,
    
    /// <summary>
    /// Word document
    /// </summary>
    Word,
    
    /// <summary>
    /// Excel spreadsheet
    /// </summary>
    Excel,
    
    /// <summary>
    /// PowerPoint presentation
    /// </summary>
    PowerPoint
}
