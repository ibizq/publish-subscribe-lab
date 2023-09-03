using PublishSubscribeLab.Events;
using PublishSubscribeLab.Interfaces;
using PublishSubscribeLab.Models;

namespace PublishSubscribeLab.Subscribers;

// MachineRefillSubscriber.cs
public class MachineRefillSubscriber : ISubscriber
{
    private readonly List<Machine> machines;

    public MachineRefillSubscriber(List<Machine> machines)
    {
        this.machines = machines;
    }

    public void Handle(IEvent @event)
    {
        if (@event is MachineRefillEvent refillEvent)
        {
            var machine = machines.FirstOrDefault(m => m.Id == refillEvent.MachineId);
            if (machine != null)
            {
                machine.Stock += refillEvent.RefillAmount;
            }
        }
    }
}

