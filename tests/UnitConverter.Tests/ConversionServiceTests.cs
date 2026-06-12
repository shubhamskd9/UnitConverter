using UnitConverter.Core.Models;
using UnitConverter.Core.Services;

namespace UnitConverter.Tests;

public class ConversionServiceTests
{
    private readonly ConversionService _service;

    public ConversionServiceTests()
    {
        _service = new ConversionService();
    }

    // ── Temperature Tests ──────────────────────────────────────

    [Fact]
    public void Convert_CelsiusToFahrenheit_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "celsius", ToUnit = "fahrenheit", Value = 100 };
        var result = _service.Convert(request);
        Assert.Equal(212, result.ConvertedValue, precision: 2);
    }

    [Fact]
    public void Convert_FahrenheitToCelsius_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "fahrenheit", ToUnit = "celsius", Value = 32 };
        var result = _service.Convert(request);
        Assert.Equal(0, result.ConvertedValue, precision: 2);
    }

    [Fact]
    public void Convert_CelsiusToKelvin_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "celsius", ToUnit = "kelvin", Value = 0 };
        var result = _service.Convert(request);
        Assert.Equal(273.15, result.ConvertedValue, precision: 2);
    }

    // ── Length Tests ───────────────────────────────────────────

    [Fact]
    public void Convert_KilometersToMiles_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "kilometer", ToUnit = "mile", Value = 1 };
        var result = _service.Convert(request);
        Assert.Equal(0.621371, result.ConvertedValue, precision: 4);
    }

    [Fact]
    public void Convert_MeterToFoot_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "meter", ToUnit = "foot", Value = 1 };
        var result = _service.Convert(request);
        Assert.Equal(3.28084, result.ConvertedValue, precision: 4);
    }

    // ── Weight Tests ───────────────────────────────────────────

    [Fact]
    public void Convert_KilogramToPound_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "kilogram", ToUnit = "pound", Value = 1 };
        var result = _service.Convert(request);
        Assert.Equal(2.204624, result.ConvertedValue, precision: 4);
    }

    // ── Volume Tests ───────────────────────────────────────────

    [Fact]
    public void Convert_GallonToLiter_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "gallon", ToUnit = "liter", Value = 1 };
        var result = _service.Convert(request);
        Assert.Equal(3.78541, result.ConvertedValue, precision: 4);
    }

    [Fact]
    public void Convert_LiterToMilliliter_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "liter", ToUnit = "milliliter", Value = 1 };
        var result = _service.Convert(request);
        Assert.Equal(1000, result.ConvertedValue, precision: 2);
    }

    [Fact]
    public void Convert_CupToFluidOunce_ReturnsCorrectValue()
    {
        var request = new ConversionRequest { FromUnit = "cup", ToUnit = "fluid ounce", Value = 1 };
        var result = _service.Convert(request);
        Assert.Equal(8, result.ConvertedValue, precision: 2);
    }

    // ── Validation Tests ───────────────────────────────────────

    [Fact]
    public void Convert_InvalidFromUnit_ThrowsArgumentException()
    {
        var request = new ConversionRequest { FromUnit = "xyz", ToUnit = "meter", Value = 1 };
        Assert.Throws<ArgumentException>(() => _service.Convert(request));
    }

    [Fact]
    public void Convert_InvalidToUnit_ThrowsArgumentException()
    {
        var request = new ConversionRequest { FromUnit = "meter", ToUnit = "xyz", Value = 1 };
        Assert.Throws<ArgumentException>(() => _service.Convert(request));
    }

    [Fact]
    public void Convert_IncompatibleCategories_ThrowsInvalidOperationException()
    {
        var request = new ConversionRequest { FromUnit = "meter", ToUnit = "kilogram", Value = 1 };
        Assert.Throws<InvalidOperationException>(() => _service.Convert(request));
    }
}