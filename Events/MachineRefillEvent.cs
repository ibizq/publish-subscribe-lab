using PublishSubscribeLab.Interfaces;

namespace PublishSubscribeLab.Events;

// MachineRefillEvent.cs
public class MachineRefillEvent : IEvent
{
    public int MachineId { get; set; }
    public int RefillAmount { get; set; }
}