using AbstractFactory.Application.Documents;
using AbstractFactory.Infrastructure.Documents;
using Xunit;

namespace AbstractFactory.Tests;

public class DocumentServiceTests
{
    [Fact]
    public void DocumentService_GenerateThemedDocument_Successfully()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var service = new DocumentService(factory);
        var documentType = "pdf";
        var themeType = "modern";
        var content = "Test content";
        
        // Act
        var result = service.GenerateThemedDocument(documentType, themeType, content);
        
        // Assert
        Assert.NotNull(result);
        Assert.Contains("PDF", result);
        Assert.Contains("Modern", result);
        Assert.Contains(content, result);
    }
    
    [Fact]
    public void DocumentService_GetFactoryInfo_ReturnsCorrectInfo()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var service = new DocumentService(factory);
        
        // Act
        var info = service.GetFactoryInfo();
        
        // Assert
        Assert.NotNull(info);
        Assert.Contains("Universal Document Factory", info);
    }
    
    [Fact]
    public void DocumentService_ThrowsException_ForEmptyDocumentType()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var service = new DocumentService(factory);
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => service.GenerateThemedDocument("", "modern", "content"));
    }
    
    [Fact]
    public void DocumentService_ThrowsException_ForEmptyThemeType()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var service = new DocumentService(factory);
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => service.GenerateThemedDocument("pdf", "", "content"));
    }
    
    [Fact]
    public void DocumentService_ThrowsException_ForEmptyContent()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var service = new DocumentService(factory);
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => service.GenerateThemedDocument("pdf", "modern", ""));
    }
    
    [Fact]
    public void DocumentService_ThrowsException_ForUnsupportedDocumentType()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var service = new DocumentService(factory);
        
        // Act & Assert
        Assert.Throws<NotSupportedException>(() => service.GenerateThemedDocument("unknown", "modern", "content"));
    }
    
    [Fact]
    public void DocumentService_ThrowsException_ForUnsupportedThemeType()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var service = new DocumentService(factory);
        
        // Act & Assert
        Assert.Throws<NotSupportedException>(() => service.GenerateThemedDocument("pdf", "unknown", "content"));
    }
}
