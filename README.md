# Abstract Factory Pattern Implementation

This repository demonstrates a practical implementation of the Abstract Factory design pattern in C#. The project showcases how to create families of related objects (documents and themes) without specifying their concrete classes.

## Table of Contents
- [Overview](#overview)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Design Patterns](#design-patterns)
- [Features](#features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Usage Examples](#usage-examples)
- [Testing](#testing)
- [Extending the System](#extending-the-system)

## Overview

The Abstract Factory pattern provides an interface for creating families of related or dependent objects without specifying their concrete classes. This implementation creates various document types (PDF, Word, Excel, PowerPoint) with different themes (Classic, Modern, Corporate, Minimalist).

## Architecture

The solution follows a clean architecture approach with separate layers:

1. **Domain Layer** (`AbstractFactory.Domain`) - Contains interfaces and enums defining the core business concepts
2. **Infrastructure Layer** (`AbstractFactory.Infrastructure`) - Implements concrete document and theme classes
3. **Application Layer** (`AbstractFactory.Application`) - Contains business logic for document generation
4. **Presentation Layer** (`AbstractFactory.API`) - REST API exposing document generation functionality

## Project Structure

```
src/
├── AbstractFactory.API/              # REST API endpoints
├── AbstractFactory.Application/      # Business logic
├── AbstractFactory.Domain/           # Core interfaces and enums
└── AbstractFactory.Infrastructure/   # Concrete implementations
tests/
└── AbstractFactory.Tests/            # Unit tests
```

### Domain Layer
- `IDocument` - Interface for all document types
- `ITheme` - Interface for all theme types
- `IDocumentFactory` - Abstract factory interface for creating documents and themes
- `DocumentType` - Enum defining supported document types
- `ThemeType` - Enum defining supported theme types

### Infrastructure Layer
- `UniversalDocumentFactory` - Concrete factory implementation
- Document implementations: `PdfDocument`, `WordDocument`, `ExcelDocument`, `PowerPointDocument`
- Theme implementations: `ClassicTheme`, `ModernTheme`, `CorporateTheme`, `MinimalistTheme`

### Application Layer
- `DocumentService` - Orchestrates document creation and theming

### Presentation Layer
- REST API with endpoints for document generation

## Design Patterns

### Abstract Factory
The core pattern implemented here allows creating families of related objects (documents + themes) without coupling client code to concrete classes.

### Dependency Injection
The system uses .NET's built-in DI container to inject the document factory into services.

### Single Responsibility Principle
Each class has a single purpose, making the system easy to maintain and extend.

## Features

- Create multiple document types: PDF, Word, Excel, PowerPoint
- Apply different themes: Classic, Modern, Corporate, Minimalist
- REST API for document generation
- Extensible design for adding new document types or themes
- Comprehensive unit test coverage

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- IDE with C# support (Visual Studio, VS Code, Rider)

### Running the Application

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```bash
   cd abstract-factory
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Build the project:
   ```bash
   dotnet build
   ```

5. Run the API:
   ```bash
   dotnet run --project src/AbstractFactory.API/
   ```

The API will start on `https://localhost:5001` and `http://localhost:5000`.

## API Endpoints

### Generate Document
```
POST /generate-document
```

Generates a document with the specified type and theme.

**Request Body:**
```json
{
  "documentType": "pdf",
  "themeType": "modern",
  "content": "Sample content for the document"
}
```

**Response:**
```json
{
  "document": "Generated document content..."
}
```

### Get Factory Info
```
GET /factory-info
```

Returns information about the current document factory being used.

**Response:**
```json
{
  "factoryInfo": "Using factory: Universal Document Factory"
}
```

## Usage Examples

### Creating a Themed Document Programmatically

```csharp
// Create the factory
IDocumentFactory factory = new UniversalDocumentFactory();

// Create document service
var documentService = new DocumentService(factory);

// Generate a themed document
var documentContent = documentService.GenerateThemedDocument(
    "pdf", 
    "modern", 
    "Hello, World!"
);

Console.WriteLine(documentContent);
```

### Adding New Document Types

1. Create a new class that implements [IDocument](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.Domain/Documents/IDocument.cs#L6-L30)
2. Update the [UniversalDocumentFactory](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.Infrastructure/Documents/UniversalDocumentFactory.cs#L13-L75) to handle the new document type
3. Add the document type to the supported documents list in [CanCreateDocument](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.Infrastructure/Documents/UniversalDocumentFactory.cs#L59-L63)

## Testing

Run the unit tests with:

```bash
dotnet test
```

The test suite includes:
- Document factory tests
- Document service tests
- Individual document tests

## Extending the System

### Adding a New Theme

1. Create a new class that implements [ITheme](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.Domain/Documents/ITheme.cs#L6-L18)
2. Update the [UniversalDocumentFactory](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.Infrastructure/Documents/UniversalDocumentFactory.cs#L13-L75) to handle the new theme type
3. Add the theme type to the supported themes list in [CanCreateTheme](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.Infrastructure/Documents/UniversalDocumentFactory.cs#L70-L74)

### Creating a Specialized Factory

To create a factory that only supports specific document/theme combinations:

1. Create a new class that implements [IDocumentFactory](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.Domain/Documents/IDocumentFactory.cs#L6-L40)
2. Implement the factory methods to only support specific combinations
3. Register your new factory in [Program.cs](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.API/Program.cs#L5-L65) by replacing the [UniversalDocumentFactory](file:///c%3A/Users/dev/source/repos/abstract-factory/src/AbstractFactory.Infrastructure/Documents/UniversalDocumentFactory.cs#L13-L75) registration

This design makes it easy to swap out different factory implementations while maintaining the same interface.