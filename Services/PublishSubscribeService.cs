using PublishSubscribeLab.Interfaces;

namespace PublishSubscribeLab.Services;

// PublishSubscribeService.cs
public class PublishSubscribeService : IPublishSubscribeService
{
    private readonly Dictionary<Type, List<ISubscriber>> subscribers;

    public PublishSubscribeService()
    {
        subscribers = new Dictionary<Type, List<ISubscriber>>();
    }

    public void Subscribe(ISubscriber subscriber, Type eventType)
    {
        if (!subscribers.ContainsKey(eventType))
        {
            subscribers[eventType] = new List<ISubscriber>();
        }
        subscribers[eventType].Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber, Type eventType)
    {
        if (subscribers.ContainsKey(eventType))
        {
            subscribers[eventType].Remove(subscriber);
        }
    }

    public void Publish(IEvent @event)
    {
        var eventType = @event.GetType();
        if (subscribers.ContainsKey(eventType))
        {
            foreach (var subscriber in subscribers[eventType])
            {
                subscriber.Handle(@event);
            }
        }
    }
}