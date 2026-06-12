# Unit Converter API

A RESTful API built with ASP.NET Core 9 that converts numerical values between different units of measurement.

## Supported Categories

| Category    | Units                                                  |
|-------------|--------------------------------------------------------|
| Temperature | Celsius, Fahrenheit, Kelvin                            |
| Length      | Meter, Kilometer, Centimeter, Millimeter, Mile, Yard, Foot, Inch |
| Weight      | Kilogram, Gram, Milligram, Pound, Ounce, Tonne         |
| Volume      | Liter, Milliliter, Centiliter, Gallon, Quart, Pint, Cup, Fluid Ounce |

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)

## How to Run Locally

**1. Clone the repository:**
```bash
git clone <your-repo-url>
cd UnitConverter
```

**2. Build the solution:**
```bash
dotnet build
```

**3. Run the API:**
```bash
dotnet run --project src/UnitConverter.Api
```

**4. Open Swagger UI in your browser:**

The port is displayed in the terminal when the API starts, 
e.g.: Now listening on: http://localhost:5081

Navigate to `http://localhost:<port>/swagger`




## How to Run Tests

```bash
dotnet test
```

## API Usage

### Endpoint

`POST /api/conversion/convert`

### Request Body

```json
{
  "fromUnit": "celsius",
  "toUnit": "fahrenheit",
  "value": 100
}
```

### Success Response (200)

```json
{
  "originalValue": 100,
  "fromUnit": "celsius",
  "convertedValue": 212,
  "toUnit": "fahrenheit"
}
```

### Error Response (400)

```json
{
  "message": "Invalid unit specified",
  "details": "Unknown unit: 'xyz'"
}
```

### Supported Unit Names

Units can be referenced by full name (e.g. `celsius`) or symbol (e.g. `°C`).

## Project Structure

UnitConverter/

├── src/

│   ├── UnitConverter.Api/          # Web API layer (controllers, config)

│   └── UnitConverter.Core/         # Business logic (models, services)

│       ├── Definitions/            # Unit registry and definitions

│       ├── Models/                 # Request and response models

│       └── Services/               # Conversion logic

├── tests/

│   └── UnitConverter.Tests/        # xUnit test project

└── README.md




## Design Decisions

### Base Unit Conversion Strategy
All conversions go through a base unit (meters for length, kilograms for weight, Kelvin for temperature). This means any unit can be converted to any other unit in the same category in exactly two steps: `source → base → target`. This approach scales easily to hundreds of units without requiring explicit formulas for every possible pair.

### Separation of Concerns
The solution is split into two projects:
- **UnitConverter.Core** — pure C# business logic with no dependency on ASP.NET. Easy to test and reuse.
- **UnitConverter.Api** — handles HTTP concerns only (routing, validation responses, Swagger).

### Dependency Injection
`ConversionService` is registered via ASP.NET Core's built-in DI container and injected into the controller. This makes the controller easy to test and the implementation easy to swap.

### Extensibility
To add a new unit, simply add a new entry to `UnitRegistry.cs` — no other code needs to change. To add a new category, add entries with a new category name and they are automatically supported.