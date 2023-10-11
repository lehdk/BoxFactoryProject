using BoxFactoryAPI.TransferModels;
using BoxFactoryApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BoxFactoryAPI.Extensions;
using BoxFactoryDomain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using BoxFactoryDomain.Entities;

namespace BoxFactoryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoxOrdersController : ControllerBase
{
    private readonly ILogger<BoxOrdersController> _logger;
    private readonly IBoxOrderService _boxOrderService;

    public BoxOrdersController(ILogger<BoxOrdersController> logger, IBoxOrderService boxOrderService)
    {
        _logger = logger;
        _boxOrderService = boxOrderService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<BoxOrderDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOrders()
    {
        _logger.LogInformation("Getting all orders");

        var result = (await _boxOrderService.GetAllOrders()).ToDto();

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BoxOrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto data)
    {
        _logger.LogInformation("Creating new order");

        BoxOrder? result;
        try
        {
            result = await _boxOrderService.CreateOrder(
                data.Street,
                data.Number,
                data.City,
                data.Zip,
                data.OrderLines.Parse()
            );
        } catch(EmptyListException e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }

        if(result is null)
        {
            throw new Exception("Could not create the odrder");
        }

        return Ok(result.ToDto());
    }

    [HttpDelete("{orderId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteOrderById(int orderId)
    {
        _logger.LogInformation("Deleting order with id {id}", orderId);

        var result = await _boxOrderService.DeleteOrderById(orderId);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPatch("ship/{orderId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(DateTime), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> ShipOrder(int orderId)
    {
        _logger.LogInformation("Shipping order with orderId {orderId}", orderId);
        try
        {
            var result = await _boxOrderService.ShipOrder(orderId);
            
            return Ok(result);
        } catch (NotFoundException e)
        {
            return NotFound();
        } catch (AlreadyShippedException e)
        {
            return Conflict(e.Message);
        } catch(Exception e)
        {
            throw;
        }
    }
}
