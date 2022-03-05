using CasaDoCodigo.Clone.Domain.Notifications;

namespace CasaDoCodigo.Clone.Domain.Interfaces;
public interface INotifier
{
    public bool HasNotification();
    public bool DontHasNotification();
    public IList<Notification> GetNotifications();
    public void Handler(Notification Notification);
}
