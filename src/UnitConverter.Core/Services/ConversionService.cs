using UnitConverter.Core.Definitions;
using UnitConverter.Core.Models;

namespace UnitConverter.Core.Services;

public class ConversionService : IConversionService
{
    public ConversionResult Convert(ConversionRequest request)
    {
        var fromUnit = UnitRegistry.FindUnit(request.FromUnit);
        var toUnit = UnitRegistry.FindUnit(request.ToUnit);

        if(fromUnit == null)
        {
            throw new ArgumentException($"Unknown unit: '{request.FromUnit}'");
        }

        if(toUnit == null)
        {
            throw new ArgumentException($"Unknown unit: '{request.ToUnit}'");
        }

        if(fromUnit.Category != toUnit.Category)
        {
            throw new InvalidOperationException(
                $"Cannot convert between '{fromUnit.Category}' and '{toUnit.Category}'");
        }

        // Convert to base unit
        var valueInBase = (request.Value * fromUnit.ToBaseFactor) + fromUnit.Offset;
        // Convert to target unit
        var convertedValue = (valueInBase - toUnit.Offset) / toUnit.ToBaseFactor;

        return new ConversionResult
        {
            OriginalValue = request.Value,
            FromUnit = fromUnit.Name,
            ConvertedValue = Math.Round(convertedValue, 6),
            ToUnit = toUnit.Name
        };
    }
}