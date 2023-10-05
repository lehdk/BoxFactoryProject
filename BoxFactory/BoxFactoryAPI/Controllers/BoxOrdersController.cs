using BoxFactoryApplication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> GetAllOrders()
    {
        _logger.LogInformation("Getting all orders");

        var result = await _boxOrderService.GetAllOrders();

        return Ok(result);
    }

}
