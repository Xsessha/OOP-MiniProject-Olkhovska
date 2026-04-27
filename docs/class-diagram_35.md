```mermaid
classDiagram

class Car {
    +Guid Id
    +string Model
    +bool IsAvailable
    +Rent()
    +Return()
}

class Customer {
    <<abstract>>
    +string Name
    +GetDiscount()
}

class EconomyCustomer
class PremiumCustomer

Customer <|-- EconomyCustomer
Customer <|-- PremiumCustomer

class Rental {
    +Guid Id
    +Car Car
    +Customer Customer
    +DateTime Date
}

class ICarRepository {
    <<interface>>
    +Add(Car)
    +GetById(Guid)
    +GetAll()
}

class InMemoryCarRepository {
    +Add(Car)
    +GetById(Guid)
    +GetAll()
}

ICarRepository <|.. InMemoryCarRepository

class IRentalRepository {
    <<interface>>
    +Add(Rental)
    +GetAll()
}

class InMemoryRentalRepository {
    +Add(Rental)
    +GetAll()
}

IRentalRepository <|.. InMemoryRentalRepository

class RentalService {
    +RentCar()
    +ReturnCar()
    +GetAvailableCars()
}

class RentalFileStorage {
    +LoadRentals()
    +SaveRentals()
}

class CustomerFactory {
    +Create()
}

RentalService --> ICarRepository
RentalService --> RentalFileStorage
RentalService --> CustomerFactory
RentalService --> Rental

InMemoryCarRepository --> Car
InMemoryRentalRepository --> Rental