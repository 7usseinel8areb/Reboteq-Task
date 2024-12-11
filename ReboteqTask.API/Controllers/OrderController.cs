namespace ReboteqTask.API.Controllers;

[ApiController]
public class OrderController : BaseController
{
    [HttpPost(Router.OrderRoutes.AddOrder)]
    public async Task<IActionResult> AddOrder(AddOrder orderCommand)
    {
        var response = await _mediator.Send(orderCommand);
        return NewResult(response);
    }

}
