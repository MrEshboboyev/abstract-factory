namespace AbstractFactory.Infrastructure.Documents.Themes;

using AbstractFactory.Domain.Documents;

public class ClassicTheme : ITheme
{
    public string ApplyTheme()
    {
        return "Classic Theme Applied";
    }
} 