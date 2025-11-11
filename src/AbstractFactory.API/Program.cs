using AbstractFactory.Application.Documents;
using AbstractFactory.Domain.Documents;
using AbstractFactory.Infrastructure.Documents;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Register services
builder.Services.AddScoped<IDocumentFactory, UniversalDocumentFactory>(); // Default factory
builder.Services.AddScoped<DocumentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Document generation endpoint
app.MapPost("/generate-document", (DocumentRequest request, DocumentService documentService) =>
{
    try
    {
        var result = documentService.GenerateThemedDocument(request.DocumentType, request.ThemeType, request.Content);
        return Results.Ok(new { Document = result });
    }
    catch (NotSupportedException ex)
    {
        return Results.BadRequest(new { Error = ex.Message });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { Error = ex.Message });
    }
})
.WithName("GenerateDocument")
.WithOpenApi();

// Factory info endpoint
app.MapGet("/factory-info", (DocumentService documentService) =>
{
    var info = documentService.GetFactoryInfo();
    return Results.Ok(new { FactoryInfo = info });
})
.WithName("GetFactoryInfo")
.WithOpenApi();

app.Run();

/// <summary>
/// Request model for document generation
/// </summary>
/// <param name="DocumentType">The type of document to generate</param>
/// <param name="ThemeType">The type of theme to apply</param>
/// <param name="Content">The content for the document</param>
public record DocumentRequest(string DocumentType, string ThemeType, string Content);
