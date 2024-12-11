namespace ReboteqTask.API.Controllers;

[ApiController]
public class ProductController : BaseController
{
    [HttpGet(Router.ProductRoutes.GetAllProducts)]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await _mediator.Send(new GetAllProducts());
        return NewResult(response);
    }
}
