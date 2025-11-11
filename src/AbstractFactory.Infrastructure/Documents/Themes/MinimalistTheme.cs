using AbstractFactory.Domain.Documents;

namespace AbstractFactory.Infrastructure.Documents.Themes;

/// <summary>
/// Minimalist theme implementation
/// </summary>
public class MinimalistTheme : ITheme
{
    /// <summary>
    /// Gets the theme name
    /// </summary>
    public string ThemeName => "Minimalist";
    
    /// <summary>
    /// Applies the minimalist theme
    /// </summary>
    /// <returns>A string representation of the applied minimalist theme</returns>
    public string ApplyTheme()
    {
        return "Minimalist Theme Applied";
    }
}
