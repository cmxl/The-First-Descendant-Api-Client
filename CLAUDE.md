# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

TFDTool is a C# client library for The First Descendant API provided by Nexon. The project consists of:

- **TheFirstDescendant.csproj** - Main API client library targeting .NET 9.0
- **TheFirstDescendant.sln** - Visual Studio solution file

## Development Commands

### Building
```bash
dotnet build
```

### Building specific configuration
```bash
dotnet build -c Release
dotnet build -c Debug
```

### Restore packages
```bash
dotnet restore
```

## Architecture

### Core Components

1. **TheFirstDescendantApiClient.cs** - Low-level HTTP client generated from OpenAPI spec
   - Direct API calls with full parameter control
   - Handles HTTP requests, serialization, and error handling
   - Base URL: `https://open.api.nexon.com/`

2. **TheFirstDescendantService.cs** - High-level service wrapper
   - English-first API (automatically uses `LanguageCode.En`)
   - Simplified method signatures for common use cases
   - Wraps the raw API client for easier consumption

3. **Models/** - Generated data models from OpenAPI specification
   - Strongly typed C# classes for all API responses
   - Each endpoint has corresponding model and response classes
   - Pattern: `{EntityName}.cs` and `{EntityName}Response.cs`

### Key Design Patterns

- **Service Layer Pattern**: `TheFirstDescendantService` provides a simplified interface over the raw API client
- **Default Language**: All service methods default to English (`en`) language code
- **Cancellation Token Support**: All async methods support cancellation tokens
- **Generated Code**: API client and models are generated from `tfd-openapi.yaml` OpenAPI specification

### Dependencies

- `Microsoft.Extensions.Http` (v9.0.9) - For IHttpClientFactory integration
- `System.Text.Json` (v9.0.9) - JSON serialization

### API Structure

The API provides metadata for The First Descendant game elements:
- Descendants, Weapons, Modules, Reactors
- External Components, Rewards, Stats
- Void Battles, Titles, Materials, Research
- Weapon Types, Fellows, Tiers, Core Slots
- Customizing Items, Medals, Vehicles
- Level details, Mastery ranks, Acquisition details

All endpoints follow the pattern: `/static/tfd/meta/{language_code}/{endpoint}.json`

### Usage Patterns

The service class provides both convenience methods (English-only) and raw client access:

```csharp
// Convenience method (English only)
var descendants = await service.GetDescendantsAsync();

// Raw client access (full control)
var rawClient = service.GetRawClient();
var koreandDescendants = await rawClient.GetDescendantsAsync(LanguageCode.Ko);
```