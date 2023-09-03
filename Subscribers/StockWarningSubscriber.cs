using PublishSubscribeLab.Events;
using PublishSubscribeLab.Interfaces;
using PublishSubscribeLab.Models;
using PublishSubscribeLab.Services;

namespace PublishSubscribeLab.Subscribers;

// StockWarningSubscriber.cs
public class StockWarningSubscriber : ISubscriber
{
    private readonly IPublishSubscribeService publishSubscribeService;
    private readonly List<Machine> machines;
    private readonly HashSet<int> lowStockMachines;

    public StockWarningSubscriber(IPublishSubscribeService publishSubscribeService, List<Machine> machines)
    {
        this.publishSubscribeService = publishSubscribeService;
        this.machines = machines;
        this.lowStockMachines = new HashSet<int>();
    }

    public void Handle(IEvent @event)
    {
        if (@event is MachineSaleEvent saleEvent)
        {
            var machine = machines.FirstOrDefault(m => m.Id == saleEvent.MachineId);
            if (machine != null)
            {
                if (machine.Stock < 3 && !lowStockMachines.Contains(machine.Id))
                {
                    lowStockMachines.Add(machine.Id);
                    publishSubscribeService.Publish(new LowStockWarningEvent { MachineId = machine.Id });
                }
                else if (machine.Stock >= 3 && lowStockMachines.Contains(machine.Id))
                {
                    lowStockMachines.Remove(machine.Id);
                    publishSubscribeService.Publish(new StockLevelOkEvent { MachineId = machine.Id });
                }
            }
        }
    }
}