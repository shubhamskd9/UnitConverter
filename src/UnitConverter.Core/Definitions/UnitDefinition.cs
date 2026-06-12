namespace UnitConverter.Core.Definitions;

public class UnitDefinition
{
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public double ToBaseFactor { get; set; }
    public double Offset { get; set; } = 0; // For units like Celsius that require an offset
}