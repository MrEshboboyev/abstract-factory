using AbstractFactory.Infrastructure.Documents.PDF;
using AbstractFactory.Infrastructure.Documents.Themes;
using AbstractFactory.Infrastructure.Documents.Word;
using Xunit;

namespace AbstractFactory.Tests;

public class DocumentTests
{
    [Fact]
    public void PdfDocument_SetContent_And_GenerateContent_Successfully()
    {
        // Arrange
        var document = new PdfDocument();
        var content = "Test PDF content";
        
        // Act
        document.SetContent(content);
        var result = document.GenerateContent();
        
        // Assert
        Assert.NotNull(result);
        Assert.Contains(content, result);
        Assert.Contains("PDF", result);
    }
    
    [Fact]
    public void WordDocument_SetContent_And_GenerateContent_Successfully()
    {
        // Arrange
        var document = new WordDocument();
        var content = "Test Word content";
        
        // Act
        document.SetContent(content);
        var result = document.GenerateContent();
        
        // Assert
        Assert.NotNull(result);
        Assert.Contains(content, result);
        Assert.Contains("Word", result);
    }
    
    [Fact]
    public void Document_ApplyTheme_Successfully()
    {
        // Arrange
        var document = new PdfDocument();
        var theme = new ModernTheme();
        var content = "Test content";
        
        // Act
        document.SetContent(content);
        document.ApplyTheme(theme);
        var result = document.GenerateContent();
        
        // Assert
        Assert.NotNull(result);
        Assert.Contains(content, result);
        Assert.Contains("Modern", result);
    }
    
    [Fact]
    public void Document_ThrowsException_ForNullContent()
    {
        // Arrange
        var document = new PdfDocument();
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => document.SetContent(null));
    }
    
    [Fact]
    public void Document_ThrowsException_ForNullTheme()
    {
        // Arrange
        var document = new PdfDocument();
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => document.ApplyTheme(null));
    }
}
