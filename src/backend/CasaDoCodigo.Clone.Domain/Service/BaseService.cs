using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Notifications;

namespace CasaDoCodigo.Clone.Domain.Service;

public abstract class BaseService
{
    private INotifier _notifier;

    public BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected virtual void SendNotification(string message) 
        => _notifier.Handler(new Notification(message));
}
