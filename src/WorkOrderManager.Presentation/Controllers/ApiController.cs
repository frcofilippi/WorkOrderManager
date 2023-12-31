﻿using ErrorOr;

using Microsoft.AspNetCore.Mvc;

namespace WorkOrderManager.Presentation.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ApiController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Problem(List<Error> errors)
    {
        var error = errors[0];
        return Problem(detail: error.Code, statusCode: StatusCodes.Status404NotFound, title: error.Description);
    }
}
