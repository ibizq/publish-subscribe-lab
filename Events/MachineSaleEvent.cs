using PublishSubscribeLab.Interfaces;

namespace PublishSubscribeLab.Events;

// MachineSaleEvent.cs
public class MachineSaleEvent : IEvent
{
    public int MachineId { get; set; }
    public int Quantity { get; set; }
}