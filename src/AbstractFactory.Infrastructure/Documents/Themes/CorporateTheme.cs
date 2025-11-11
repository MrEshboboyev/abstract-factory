using AbstractFactory.Domain.Documents;

namespace AbstractFactory.Infrastructure.Documents.Themes;

/// <summary>
/// Corporate theme implementation
/// </summary>
public class CorporateTheme : ITheme
{
    /// <summary>
    /// Gets the theme name
    /// </summary>
    public string ThemeName => "Corporate";
    
    /// <summary>
    /// Applies the corporate theme
    /// </summary>
    /// <returns>A string representation of the applied corporate theme</returns>
    public string ApplyTheme()
    {
        return "Corporate Theme Applied";
    }
}
