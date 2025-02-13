namespace AbstractFactory.Infrastructure.Documents.Themes;

using AbstractFactory.Domain.Documents;

public class ModernTheme : ITheme
{
    public string ApplyTheme()
    {
        return "Modern Theme Applied";
    }
} 