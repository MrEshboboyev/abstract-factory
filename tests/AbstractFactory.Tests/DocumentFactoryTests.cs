using AbstractFactory.Infrastructure.Documents;
using AbstractFactory.Infrastructure.Documents.PDF;
using AbstractFactory.Infrastructure.Documents.Word;
using Xunit;

namespace AbstractFactory.Tests;

public class DocumentFactoryTests
{
    [Fact]
    public void ModernPdfFactory_CreatesPdfDocument_Successfully()
    {
        // Arrange
        var factory = new ModernPdfFactory();
        
        // Act
        var document = factory.CreateDocument("pdf");
        
        // Assert
        Assert.NotNull(document);
        Assert.Equal("PDF", document.DocumentType);
    }
    
    [Fact]
    public void ModernPdfFactory_CreatesModernTheme_Successfully()
    {
        // Arrange
        var factory = new ModernPdfFactory();
        
        // Act
        var theme = factory.CreateTheme("modern");
        
        // Assert
        Assert.NotNull(theme);
        Assert.Equal("Modern", theme.ThemeName);
    }
    
    [Fact]
    public void ClassicWordFactory_CreatesWordDocument_Successfully()
    {
        // Arrange
        var factory = new ClassicWordFactory();
        
        // Act
        var document = factory.CreateDocument("word");
        
        // Assert
        Assert.NotNull(document);
        Assert.Equal("Word", document.DocumentType);
    }
    
    [Fact]
    public void ClassicWordFactory_CreatesClassicTheme_Successfully()
    {
        // Arrange
        var factory = new ClassicWordFactory();
        
        // Act
        var theme = factory.CreateTheme("classic");
        
        // Assert
        Assert.NotNull(theme);
        Assert.Equal("Classic", theme.ThemeName);
    }
    
    [Fact]
    public void UniversalDocumentFactory_CreatesAllDocumentTypes_Successfully()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var documentTypes = new[] { "pdf", "word", "excel", "powerpoint" };
        
        // Act & Assert
        foreach (var docType in documentTypes)
        {
            var document = factory.CreateDocument(docType);
            Assert.NotNull(document);
            Assert.Equal(docType, document.DocumentType, true);
        }
    }
    
    [Fact]
    public void UniversalDocumentFactory_CreatesAllThemeTypes_Successfully()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        var themeTypes = new[] { "classic", "modern", "corporate", "minimalist" };
        
        // Act & Assert
        foreach (var themeType in themeTypes)
        {
            var theme = factory.CreateTheme(themeType);
            Assert.NotNull(theme);
            Assert.Equal(themeType, theme.ThemeName, true);
        }
    }
    
    [Fact]
    public void DocumentFactory_CanCreateDocument_ReturnsCorrectly()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        
        // Act
        var canCreatePdf = factory.CanCreateDocument("pdf");
        var canCreateUnknown = factory.CanCreateDocument("unknown");
        
        // Assert
        Assert.True(canCreatePdf);
        Assert.False(canCreateUnknown);
    }
    
    [Fact]
    public void DocumentFactory_CanCreateTheme_ReturnsCorrectly()
    {
        // Arrange
        var factory = new UniversalDocumentFactory();
        
        // Act
        var canCreateModern = factory.CanCreateTheme("modern");
        var canCreateUnknown = factory.CanCreateTheme("unknown");
        
        // Assert
        Assert.True(canCreateModern);
        Assert.False(canCreateUnknown);
    }
    
    [Fact]
    public void DocumentFactory_ThrowsException_ForUnsupportedDocumentType()
    {
        // Arrange
        var factory = new ModernPdfFactory();
        
        // Act & Assert
        Assert.Throws<NotSupportedException>(() => factory.CreateDocument("word"));
    }
    
    [Fact]
    public void DocumentFactory_ThrowsException_ForUnsupportedThemeType()
    {
        // Arrange
        var factory = new ClassicWordFactory();
        
        // Act & Assert
        Assert.Throws<NotSupportedException>(() => factory.CreateTheme("minimalist"));
    }
}
