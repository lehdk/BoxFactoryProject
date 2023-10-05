using BoxFactoryAPI.Exceptions;
using BoxFactoryAPI.Extensions;
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
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Getting all boxes");

        var allBoxes = await _boxService.GetAllBoxes();

        var result = allBoxes.ToDto();

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(BoxDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        _logger.LogInformation("Getting box with id {id}", id);

        var result = await _boxService.GetBoxById(id);

        if(result is null)
            return NotFound();

        return Ok(result.ToDto());
    }

    [HttpPost]
    [ProducesResponseType(typeof(BoxDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] ModifyObject postObject)
    {
        _logger.LogInformation("Creating a new box");

        var result = await _boxService.Create(postObject.Width, postObject.Height, postObject.Length, postObject.Weight, postObject.Color);

        if (result is null)
            throw new Exception("Could not create a new box");

        return Ok(result.ToDto());
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(typeof(BoxDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Patch(int id, [FromBody] ModifyObject patchObject)
    {
        _logger.LogInformation("Patching box with id {id} with data {data}", id, patchObject);

        var result = await _boxService.UpdateBox(
            id,
            patchObject.Width,
            patchObject.Height,
            patchObject.Length,
            patchObject.Weight,
            patchObject.Color,
            patchObject.Price
        );

        if(result is null)
            return NotFound();

        return Ok(result.ToDto());
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation("Deleting box with id {id}", id);

        var result = await _boxService.DeleteBoxById(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}