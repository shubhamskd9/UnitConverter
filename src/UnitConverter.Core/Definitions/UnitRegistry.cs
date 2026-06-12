namespace UnitConverter.Core.Definitions;

public static class UnitRegistry
{
    public static readonly List<UnitDefinition> Units = new()
    {
        // Length (base unit: meter)
        new UnitDefinition { Name = "meter",      Symbol = "m",   Category = "length",      ToBaseFactor = 1.0 },
        new UnitDefinition { Name = "kilometer",  Symbol = "km",  Category = "length",      ToBaseFactor = 1000.0 },
        new UnitDefinition { Name = "centimeter", Symbol = "cm",  Category = "length",      ToBaseFactor = 0.01 },
        new UnitDefinition { Name = "millimeter", Symbol = "mm",  Category = "length",      ToBaseFactor = 0.001 },
        new UnitDefinition { Name = "mile",       Symbol = "mi",  Category = "length",      ToBaseFactor = 1609.344 },
        new UnitDefinition { Name = "yard",       Symbol = "yd",  Category = "length",      ToBaseFactor = 0.9144 },
        new UnitDefinition { Name = "foot",       Symbol = "ft",  Category = "length",      ToBaseFactor = 0.3048 },
        new UnitDefinition { Name = "inch",       Symbol = "in",  Category = "length",      ToBaseFactor = 0.0254 },

        // ── Weight (base unit: kilogram) ───────────────────────
        new UnitDefinition { Name = "kilogram",   Symbol = "kg",  Category = "weight",      ToBaseFactor = 1.0 },
        new UnitDefinition { Name = "gram",       Symbol = "g",   Category = "weight",      ToBaseFactor = 0.001 },
        new UnitDefinition { Name = "milligram",  Symbol = "mg",  Category = "weight",      ToBaseFactor = 0.000001 },
        new UnitDefinition { Name = "pound",      Symbol = "lb",  Category = "weight",      ToBaseFactor = 0.453592 },
        new UnitDefinition { Name = "ounce",      Symbol = "oz",  Category = "weight",      ToBaseFactor = 0.0283495 },
        new UnitDefinition { Name = "tonne",      Symbol = "t",   Category = "weight",      ToBaseFactor = 1000.0 },

        // ── Temperature (base unit: kelvin) ────────────────────
        new UnitDefinition { Name = "kelvin",     Symbol = "K",   Category = "temperature", ToBaseFactor = 1.0,   Offset = 0 },
        new UnitDefinition { Name = "celsius",    Symbol = "°C",  Category = "temperature", ToBaseFactor = 1.0,   Offset = 273.15 },
        new UnitDefinition { Name = "fahrenheit", Symbol = "°F",  Category = "temperature", ToBaseFactor = 5.0/9.0, Offset = 255.3722222 },
    };
    public static UnitDefinition? FindUnit(String nameOrSymbol)
    {
        var input = nameOrSymbol.Trim().ToLowerInvariant();
        return Units.FirstOrDefault(u =>
            u.Name.ToLowerInvariant() == input ||
            u.Symbol.ToLowerInvariant() == input);
    }
}