using PublishSubscribeLab.Interfaces;

namespace PublishSubscribeLab.Services;

// IPublishSubscribeService.cs
public interface IPublishSubscribeService
{
    void Subscribe(ISubscriber subscriber, Type eventType);
    void Unsubscribe(ISubscriber subscriber, Type eventType);
    void Publish(IEvent @event);
}