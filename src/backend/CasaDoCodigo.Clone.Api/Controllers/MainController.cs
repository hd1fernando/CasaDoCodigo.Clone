using CasaDoCodigo.Clone.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[ApiController]
// CI: 2
public abstract class MainController : ControllerBase
{
    // 1
    private readonly INotifier _notifier;

    protected MainController(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected bool IsValidOperation()
        => _notifier.DontHasNotification()
        && DontHasErrorMessage();

    protected ActionResult CustomResponse(object? result)
        => IsValidOperation()
        ? StatusCode(200, result)
        : BadRequest(_notifier
            .GetNotifications()
            .Select(n => n.Message)
            .Union(ErrorMessage));

    protected ActionResult CustomResponse()
        => CustomResponse(null);


    private bool DontHasErrorMessage() => ErrorMessage.Any() == false;
    protected bool HasErrorMessage() => ErrorMessage.Any();

    private List<string> ErrorMessage = new List<string>();
    protected void AddErrorMessage(params string[] messages)
    {
        ErrorMessage.AddRange(messages);
    }

    protected void ValidateWithMessage(bool validation, string message)
    {
        // 1
        if (validation)
            AddErrorMessage(message);
    }
}
