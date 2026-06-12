namespace UnitConverter.Core.Models;

public class ConversionRequest
{
    public string FromUnit { get; set; } = string.Empty;
    public string ToUnit { get; set; } = string.Empty;
    public double Value { get; set; }
}