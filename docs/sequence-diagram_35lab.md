# Lab 35 - Iteration 2
## Sequence Diagram + Architecture Overview

This diagram describes the main use case: **Rent Car**

---

## Use Case: Rent Car Flow

### Participants:
- Console (UI Layer)
- RentCarHandler (Presentation Layer)
- RentalService (Application Layer)
- ICarRepository (Domain Contract)
- InMemoryCarRepository (Infrastructure Layer)
- Car (Domain Entity)
- RentalFileStorage (Persistence Layer)

---

## Sequence Diagram (Rent Car)

```mermaid
sequenceDiagram
    participant UI as Console UI
    participant H as RentCarHandler
    participant S as RentalService
    participant R as ICarRepository
    participant C as Car
    participant FS as RentalFileStorage

    UI->>H: Handle Rent Request (name, carId)
    H->>S: RentCar(name, carId)
    S->>R: GetById(carId)
    R-->>S: Car

    S->>C: Rent()

    S->>FS: LoadRentals()
    FS-->>S: rentals list

    S->>FS: SaveRentals(updated list)

    S-->>H: Result (Success)
    H-->>UI: Success message