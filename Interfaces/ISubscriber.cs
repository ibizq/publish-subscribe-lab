namespace PublishSubscribeLab.Interfaces;

// ISubscriber.cs
public interface ISubscriber
{
    void Handle(IEvent @event);
}