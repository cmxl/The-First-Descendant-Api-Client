# TFDTool - The First Descendant API Client

A C# client library for The First Descendant API provided by Nexon.

## Features

- **Strongly typed** C# client generated from OpenAPI specification
- **English-first** - All API calls automatically use English (`en`) language code
- **Async/await** support with cancellation tokens
- **Comprehensive test coverage** with xUnit, FluentAssertions, and NSubstitute
- Targets **.NET 9.0** with C# preview language features
- **Central Package Management** for consistent dependency versions across projects

## Solution Structure

- **TheFirstDescendant** (`src/TheFirstDescendant/`) - Main API client library
- **TheFirstDescendant.Tests** (`tests/TheFirstDescendant.Tests/`) - Unit tests with xUnit
- **TheFirstDescendant.Sample** (`samples/TheFirstDescendant.Sample/`) - Interactive console demo with Spectre.Console

## Quick Start

### 1. Basic Usage

```csharp
using TheFirstDescendant;

var httpClient = new HttpClient();
var service = new TheFirstDescendantService(httpClient);

// Get all descendants
var descendants = await service.GetDescendantsAsync();

// Get all weapons
var weapons = await service.GetWeaponsAsync();

// Get stats metadata
var stats = await service.GetStatsAsync();
```

### 2. Using the Raw Client

For advanced scenarios requiring language selection or direct API control:

```csharp
var rawClient = service.GetRawClient();

// Get Korean language data
var koreanDescendants = await rawClient.GetDescendantsAsync(LanguageCode.Ko);
```

## Available Endpoints

All service methods automatically use English (`en`) as the language code. Each returns a strongly-typed collection:

### Core Game Data
- `GetDescendantsAsync()` - Descendant characters and their stats/skills
- `GetWeaponsAsync()` - Weapon data including stats and types
- `GetModulesAsync()` - Module metadata for character/weapon customization
- `GetReactorsAsync()` - Reactor data and skill power coefficients
- `GetExternalComponentsAsync()` - External component metadata and base stats

### Progression & Rewards
- `GetRewardsAsync()` - Difficulty level reward information
- `GetVoidBattlesAsync()` - Void battle metadata and battle zones
- `GetResearchsAsync()` - Research recipes, costs, and results
- `GetAmorphousRewardsAsync()` - Amorphous material rewards
- `GetTitlesAsync()` - Player title metadata

### Items & Customization
- `GetConsumableMaterialsAsync()` - Consumable material data
- `GetCustomizingItemsAsync()` - Customizing item metadata with evolution stages
- `GetMedalsAsync()` - Medal metadata and details
- `GetVehiclesAsync()` - Vehicle data

### System & Reference Data
- `GetStatsAsync()` - Stat type definitions
- `GetWeaponTypesAsync()` - Weapon type metadata
- `GetFellowsAsync()` - Fellow (companion) data
- `GetTiersAsync()` - Tier level information
- `GetCoreSlotsAsync()` - Core slot metadata
- `GetCoreTypesAsync()` - Core type definitions

### Level & Progression Details
- `GetDescendantLevelDetailAsync()` - Level progression details for descendants
- `GetMasteryRankLevelDetailsAsync()` - Mastery rank progression data
- `GetFellowLevelDetailsAsync()` - Fellow level progression data
- `GetDescendantGroupsAsync()` - Descendant group metadata
- `GetAdaptLevelsAsync()` - Adaptation level data

### Advanced Systems
- `GetArcheTuningBoardGroupsAsync()` - Arche tuning board groups
- `GetArcheTuningBoardsAsync()` - Arche tuning board configurations
- `GetArcheTuningNodesAsync()` - Arche tuning node data and effects
- `GetAmorphousOpenConditionDescriptionsAsync()` - Amorphous opening conditions
- `GetAcquisitionDetailsAsync()` - Item acquisition details

## Architecture

### Core Components

1. **TheFirstDescendantApiClient** (`TheFirstDescendantApiClient.cs`)
   - Low-level HTTP client for direct API access
   - Supports all language codes (`en`, `ko`, etc.)
   - Full parameter control for advanced scenarios
   - Base URL: `https://open.api.nexon.com/`

2. **TheFirstDescendantService** (`TheFirstDescendantService.cs`)
   - High-level service wrapper with English defaults
   - Simplified method signatures for common use cases
   - Provides `GetRawClient()` for advanced access

3. **Models/** - Strongly-typed data models
   - Generated from OpenAPI specification
   - Full IntelliSense support
   - JSON serialization configured

## Requirements

- **.NET 9.0 SDK** or later
- No API keys required (public metadata endpoints)

## Building

```bash
# Build the entire solution
dotnet build

# Build in Release mode
dotnet build -c Release

# Run tests
dotnet test
```

## Running the Sample

The sample application demonstrates the API with an interactive Spectre.Console UI:

```bash
cd samples/TheFirstDescendant.Sample
dotnet run
```

Features:
- Visual descendant browser with images
- Stat progression tables
- Skill information display
- Parallel image downloading with progress

## Development

### Solution Structure

```
TFDTool/
├── src/
│   └── TheFirstDescendant/          # Main library
│       ├── Models/                  # Generated data models
│       ├── TheFirstDescendantApiClient.cs
│       └── TheFirstDescendantService.cs
├── tests/
│   └── TheFirstDescendant.Tests/    # xUnit tests
├── samples/
│   └── TheFirstDescendant.Sample/   # Demo application
├── Directory.Build.props            # Shared build configuration
├── Directory.Packages.props         # Central package versions
└── global.json                      # SDK version pinning
```

### Testing

Tests use:
- **xUnit** - Test framework
- **FluentAssertions** - Readable assertions
- **NSubstitute** - Mocking framework

### Package Information

**NuGet Package**: `TheFirstDescendant.Client`
- **Version**: 1.0.0
- **Assembly**: `TheFirstDescendant.Client.dll`
- **Repository**: https://github.com/cmxl/TheFirstDescendant.Client

## API Documentation

Based on The First Descendant OpenAPI specification from Nexon:
- Specification: `tfd-openapi.yaml` (in repository)
- Official API: https://openapi.nexon.com/

## License

This project is for educational and development purposes. Please review Nexon's terms of service for API usage guidelines.