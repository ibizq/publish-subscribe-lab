using PublishSubscribeLab.Interfaces;

namespace PublishSubscribeLab.Events;

// StockLevelOkEvent.cs
public class StockLevelOkEvent : IEvent
{
    public int MachineId { get; set; }
}