# Iteration 2

## Added
- Persistence (JSON)
- LINQ queries
- Extended tests
- New use cases

## Use Cases
1. Rent car
2. Return car
3. View available cars

## Improvements
- Business logic added
- Better error handling

## Risks
- File storage issues

## What was implemented
- Added persistence using JSON file storage
- Extended use cases: rent car, return car, view available cars
- Introduced LINQ queries for filtering and searching cars
- Added rental history persistence
- Improved separation of concerns in architecture

## Use Cases
1. Rent a car with availability check
2. Return a rented car
3. View available cars using LINQ filtering

## Persistence
- Rentals are stored in rentals.json
- Data is loaded on application startup
- Data is saved after each rental operation

## Architecture improvements
- Added File-based persistence layer
- Introduced LINQ in repository layer
- Improved service-layer responsibility separation

## Testing
- Unit tests for domain entities
- Service tests for rental logic
- Negative scenarios covered (double rent, invalid input)

## Next iteration goals
- Add analytics (most rented cars)
- Improve error handling with Result pattern
- Add advanced LINQ reporting queries