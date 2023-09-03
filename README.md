# Publish-Subscribe Mechanism in .NET Core (C#)

This project implements a simple Publish-Subscribe mechanism in .NET Core using C#. The mechanism allows subscribers to register for specific event types and receive notifications when those events occur.

## Overview Diagram
![alt text](Machine.png)

## Components

### 1. Machine
Represents a vending machine with an ID, name, and stock quantity.

### 2. Events
- `MachineSaleEvent`: Represents a machine sale event, which decreases the stock of a machine.
- `MachineRefillEvent`: Represents a machine refill event, which increases the stock of a machine.
- `LowStockWarningEvent`: Indicates that a machine's stock has dropped below 3.
- `StockLevelOkEvent`: Indicates that a machine's stock has reached 3 or above.

### 3. Subscribers
- `MachineRefillSubscriber`: Subscribes to `MachineRefillEvent` and increases the stock of the corresponding machine.
- `StockWarningSubscriber`: Subscribes to `MachineSaleEvent`, generates `LowStockWarningEvent` and `StockLevelOkEvent` based on stock levels, and handles them.

### 4. IPublishSubscribeService
The interface for the Publish-Subscribe service with methods for subscribing, unsubscribing, and publishing events.

### 5. PublishSubscribeService
An implementation of `IPublishSubscribeService` that manages subscribers and event publication.

## Usage

1. Create instances of `Machine` and initialize their stock.
2. Create an instance of `PublishSubscribeService`.
3. Create instances of subscribers (`MachineRefillSubscriber` and `StockWarningSubscriber
