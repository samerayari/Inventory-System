```mermaid
classDiagram

class Item{
  En vare med navn og pris pr. enhed
}

class BulkItem{
  En vare der sælges i kilo eller meter
}

class UnitItem{
  En vare der sælges i antal
}

class OrderLine{
  En linje i en ordre (vare og antal)
}

class Order{
  En ordre med flere varer og samlet pris
}

class Inventory{
  Holder styr på lager og mængder
}

class OrderBook{
  Samling af ordrer – både ventende og færdige
}

class Customer{
  En kunde der opretter ordrer
}

%% Relationer
BulkItem --|> Item
UnitItem --|> Item
Order "1" --> "*" OrderLine
OrderLine "*" --> "1" Item
Inventory --> "*" Item
OrderBook --> "*" Order
Customer --> OrderBook
Customer --> "*" Order
