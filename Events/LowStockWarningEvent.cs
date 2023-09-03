using PublishSubscribeLab.Interfaces;

namespace PublishSubscribeLab.Events;

// LowStockWarningEvent.cs
public class LowStockWarningEvent : IEvent
{
    public int MachineId { get; set; }
}