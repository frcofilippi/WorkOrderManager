
namespace WorkOrderManager.Presentation.Controllers;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class ApiController : ControllerBase
{

    public IActionResult Problem(List<Error> errors)
    {
        var error = errors[0];

        return Problem(detail: error.Code, statusCode: StatusCodes.Status404NotFound, title: error.Description);
    }
}
