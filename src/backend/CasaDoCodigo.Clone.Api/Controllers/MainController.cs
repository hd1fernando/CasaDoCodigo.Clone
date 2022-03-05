using CasaDoCodigo.Clone.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotifier _notifier;

    protected MainController(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected bool IsValidOperation()
        => _notifier.DontHasNotification();

    protected ActionResult CustomResponse(object? result)
        => IsValidOperation()
        ? Ok(result)
        : BadRequest(_notifier
            .GetNotifications()
            .Select(n => n.Message));

    protected ActionResult CustomResponse()
        => CustomResponse(null);
}
