using AbstractFactory.Domain.Documents;

namespace AbstractFactory.Infrastructure.Documents.Themes;

/// <summary>
/// Modern theme implementation
/// </summary>
public class ModernTheme : ITheme
{
    /// <summary>
    /// Gets the theme name
    /// </summary>
    public string ThemeName => "Modern";
    
    /// <summary>
    /// Applies the modern theme
    /// </summary>
    /// <returns>A string representation of the applied modern theme</returns>
    public string ApplyTheme()
    {
        return "Modern Theme Applied";
    }
}
