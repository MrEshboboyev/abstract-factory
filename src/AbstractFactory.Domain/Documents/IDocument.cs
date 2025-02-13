namespace AbstractFactory.Domain.Documents;

public interface IDocument
{
    string GenerateDocument();
    void SetContent(string content);
} 