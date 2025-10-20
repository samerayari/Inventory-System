# Klassediagram – Inventory System

```mermaid
---
title: Inventory System – Klassediagram (forenklet)
---
classDiagram

class Item{
  +Name : string
  +PricePerUnit : double
  ---
  Beskrivelse: En vare med navn og pris pr. enhed
}

class BulkItem{
  +MeasurementUnit : string
  ---
  Beskrivelse: En vare der sælges i kilo eller meter
}

class UnitItem{
  +Weight : double
  ---
  Beskrivelse: En vare der sælges i antal
}

class OrderLine{
  +Item : Item
  +Quantity : double
  ---
  Beskrivelse: En linje i en ordre (vare og antal)
}

class Order{
  +OrderLines : List~OrderLine~
  +TotalPrice() : double
  ---
  Beskrivelse: En ordre med flere varer og samlet pris
}

class Inventory{
  +Stock : Dictionary~Item,double~
  +AddStock(item, qty)
  +UpdateStockAfterOrder(order)
  +LowStockItems() : List~Item~
  ---
  Beskrivelse: Holder styr på lager og mængder
}

class OrderBook{
  +QueuedOrders : ObservableCollection~Order~
  +ProcessedOrders : ObservableCollection~Order~
  +ProcessNextOrder()
  +TotalRevenue() : double
  ---
  Beskrivelse: Samling af ordrer – både ventende og færdige
}

class Customer{
  +Name : string
  +Orders : List~Order~
  +CreateOrder(orderBook, order)
  ---
  Beskrivelse: En kunde der opretter ordrer
}

BulkItem --|> Item
UnitItem --|> Item
Order "1" --> "*" OrderLine : indeholder
OrderLine "*" --> "1" Item : refererer til
OrderBook o-- "*" Order : ordrer
Inventory o-- "*" Item : lager af
Customer --> OrderBook : opretter ordrer i
Customer "1" --> "*" Order : har ordrer
