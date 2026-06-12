namespace UnitConverter.Core.Models;

public class ConversionResult
{
    public double OriginalValue { get; set; }
    public string FromUnit { get; set; } = string.Empty;
    public double ConvertedValue { get; set; }
    public string ToUnit { get; set; } = string.Empty;
}