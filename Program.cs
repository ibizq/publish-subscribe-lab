// See https://aka.ms/new-console-template for more information
using PublishSubscribeLab.Events;
using PublishSubscribeLab.Models;
using PublishSubscribeLab.Services;
using PublishSubscribeLab.Subscribers;

Console.WriteLine("Hello, Machine!");

// 1. Create instances of Machines
List<Machine> machines = new List<Machine>
{
    new Machine { Id = 1, Name = "Machine 1", Stock = 5 },
    new Machine { Id = 2, Name = "Machine 2", Stock = 8 }
};

// 2. Initialize the Publish-Subscribe Service
IPublishSubscribeService publishSubscribeService = new PublishSubscribeService();

// 3. Create and Subscribe Subscribers
var machineRefillSubscriber = new MachineRefillSubscriber(machines);
var stockWarningSubscriber = new StockWarningSubscriber(publishSubscribeService, machines);

publishSubscribeService.Subscribe(machineRefillSubscriber, typeof(MachineRefillEvent));
publishSubscribeService.Subscribe(stockWarningSubscriber, typeof(MachineSaleEvent));

// 4. Publish Events
var saleEvent = new MachineSaleEvent { MachineId = 1, Quantity = 2 };
var refillEvent = new MachineRefillEvent { MachineId = 1, RefillAmount = 5 };

Console.WriteLine("Before events:");
PrintMachineStock(machines);

publishSubscribeService.Publish(saleEvent);
publishSubscribeService.Publish(refillEvent);

Console.WriteLine("After events:");
PrintMachineStock(machines);

// 5. Unsubscribe (Optional)
publishSubscribeService.Unsubscribe(machineRefillSubscriber, typeof(MachineRefillEvent));

static void PrintMachineStock(List<Machine> machines)
{
    foreach (var machine in machines)
    {
        Console.WriteLine($"Machine {machine.Id}: {machine.Name}, Stock: {machine.Stock}");
    }
    Console.WriteLine();
}