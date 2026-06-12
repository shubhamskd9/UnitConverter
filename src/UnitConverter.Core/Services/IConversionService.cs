using UnitConverter.Core.Models;

namespace UnitConverter.Core.Services;

public interface IConversionService
{
    ConversionResult Convert(ConversionRequest request);
}