using Microsoft.AspNetCore.Mvc;
using UnitConverter.Api.Models;
using UnitConverter.Core.Models;
using UnitConverter.Core.Services;

namespace UnitConverter.Api.Controllers;

[ApiController]       // so that ASP.NET knows this is an API controller
[Route("api/[controller]")]          // base route for this controller, e.g., /api/conversion
public class ConversionController : ControllerBase
{
    private readonly IConversionService _conversionService;

    public ConversionController(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    [HttpPost("convert")]           // responds to POST /api/conversion/convert
    public IActionResult Convert([FromBody] ConversionRequest request)
    {
        try
        {
            var result = _conversionService.Convert(request);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = "Invalid Unit specified",
                Details = ex.Message
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = "Incompatible unit categories",
                Details = ex.Message
            });
        }
    }
}