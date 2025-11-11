namespace AbstractFactory.Domain.Documents;

/// <summary>
/// Represents a theme that can be applied to documents
/// </summary>
public interface ITheme
{
    /// <summary>
    /// Gets the theme name
    /// </summary>
    string ThemeName { get; }
    
    /// <summary>
    /// Applies the theme
    /// </summary>
    /// <returns>A string representation of the applied theme</returns>
    string ApplyTheme();
}
