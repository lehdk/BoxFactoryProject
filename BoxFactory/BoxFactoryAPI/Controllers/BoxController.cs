using BoxFactoryAPI.TransferModels;
using BoxFactoryApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoxFactoryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoxController : ControllerBase
{
    private readonly ILogger<BoxController> _logger;
    private readonly IBoxService _boxService;

    public BoxController(ILogger<BoxController> logger, IBoxService boxService)
    {
        _logger = logger;
        _boxService = boxService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<BoxDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all boxes");

        var result = _boxService.GetAllBoxes();

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(BoxDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        _logger.LogInformation("Getting box with id {id}", id);

        var result = _boxService.GetBoxById(id);

        return Ok(result);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(typeof(BoxDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Patch(int id, [FromBody] PatchObject patchObject)
    {
        _logger.LogInformation("Patching box with id {id} with data {@data}", id, patchObject);

        var result = _boxService.UpdateBox();

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deleting box with id {id}", id);

        _boxService.DeleteBoxById(id);

        return NoContent();
    }
}