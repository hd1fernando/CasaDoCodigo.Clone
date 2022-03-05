using CasaDoCodigo.Clone.Domain.Interfaces;

namespace CasaDoCodigo.Clone.Domain.Notifications;

public class Notifier : INotifier
{
    private IList<Notification> _notifications;

    public Notifier()
        => _notifications = new List<Notification>();

    public bool DontHasNotification()
        => HasNotification() == false;

    public IList<Notification> GetNotifications()
        => _notifications;

    public void Handler(Notification Notification)
        => _notifications.Add(Notification);

    public bool HasNotification()
        => _notifications.Any();
}
