# Backend - Barber Shop Tracker

.NET Core backend for handling QR scans, location tracking, and real-time updates.

## Tech Stack
- **Framework**: .NET Core
- **Database**: MongoDB Atlas (Cloud-hosted)
- **Real-time**: SignalR
- **Location**: Geolocation distance calculations

## Backend TODO List

### #Todo1: Project Setup
- [] Initialize .NET Core project
- [ ] Setup project structure and folders
- [ ] Install required NuGet packages (MongoDB, SignalR, JWT)
- [ ] Configure MongoDB connection

### #Todo2: Database Configuration
- [ ] Setup MongoDB Atlas connection
- [ ] Create MongoDB collections based on schema:
  - shops (id, name, address, language, timestamps)
  - barbers (id, shop_id, name, user_id, password_hash, is_active, timestamps)
  - customers (id, phone, name, no_of_visits, recent_visit_date, last_verified, timestamps)
  - visits (id, customer_id, shop_id, barber_id, status, entry_time, start_time, end_time, timestamps)
  - queue (id, visit_id, shop_id, position, timestamps)
- [ ] Create MongoDB models/entities

### #Todo3: API Endpoints
- [ ] Shop management endpoints (static only)
- [ ] Barber authentication and management (static only)
- [ ] Customer registration and profile
- [ ] Visit management (entry, start, end)
- [ ] Queue management system
- [ ] Real-time status updates

### #Todo4: Location Logic
- [ ] Implement geolocation distance calculation
- [ ] Create shop location tracking
- [ ] Handle customer location updates
- [ ] Automatic visit completion based on location

### #Todo5: SignalR Implementation
- [ ] Setup SignalR hub
- [ ] Handle real-time queue updates
- [ ] Broadcast visit status changes
- [ ] Manage barber-customer connections

### #Todo6: Business Logic
- [ ] Customer visit flow (entry → queue → service → exit)
- [ ] Barber assignment logic
- [ ] Queue position management
- [ ] Service time calculations

### #Todo7: Data Processing
- [ ] Visit history and analytics
- [ ] Customer visit statistics
- [ ] Peak hour analysis
- [ ] Barber performance metrics

### #Todo8: Security & Validation
- [ ] Input validation for all endpoints
- [ ] Barber authentication system
- [ ] Customer phone verification
- [ ] Rate limiting and error handling

### #Todo9: Testing
- [ ] Unit tests for all endpoints
- [ ] Integration tests for visit flow
- [ ] SignalR connection tests
- [ ] MongoDB operation tests

### #Todo10: Deployment Setup
- [ ] Docker configuration
- [ ] Environment variables setup
- [ ] Production MongoDB Atlas configuration
- [ ] Performance optimizations

## Database Schema Design

### Shops Collection
```json
{
  "_id": "ObjectId",
  "name": "Shop Name",
  "address": "Shop Address",
  "language": "en",
  "location": {
    "latitude": 12.9716,
    "longitude": 77.5946
  },
  "created_at": "2024-01-01T00:00:00Z",
  "updated_at": "2024-01-01T00:00:00Z"
}
```

### Barbers Collection
```json
{
  "_id": "ObjectId",
  "shop_id": "ObjectId",
  "name": "Barber Name",
  "user_id": "unique_user_id",
  "password_hash": "hashed_password",
  "is_active": true,
  "created_at": "2024-01-01T00:00:00Z",
  "updated_at": "2024-01-01T00:00:00Z"
}
```

### Customers Collection
```json
{
  "_id": "ObjectId",
  "phone": "1234567890",
  "name": "Customer Name",
  "no_of_visits": 5,
  "recent_visit_date": "2024-01-01",
  "last_verified": true,
  "created_at": "2024-01-01T00:00:00Z",
  "updated_at": "2024-01-01T00:00:00Z"
}
```

### Visits Collection
```json
{
  "_id": "ObjectId",
  "customer_id": "ObjectId",
  "shop_id": "ObjectId",
  "barber_id": "ObjectId",
  "status": "entered|queued|in_progress|completed|cancelled",
  "entry_time": "2024-01-01T10:00:00Z",
  "start_time": "2024-01-01T10:30:00Z",
  "end_time": "2024-01-01T11:30:00Z",
  "created_at": "2024-01-01T00:00:00Z",
  "updated_at": "2024-01-01T00:00:00Z"
}
```

### Queue Collection
```json
{
  "_id": "ObjectId",
  "visit_id": "ObjectId",
  "shop_id": "ObjectId",
  "position": 1,
  "created_at": "2024-01-01T00:00:00Z",
  "updated_at": "2024-01-01T00:00:00Z"
}
```

## API Endpoints Design

### Shop Management (Static Only)
- `POST /api/shops` - Create new shop
- `GET /api/shops/{id}` - Get shop details
- `PUT /api/shops/{id}` - Update shop information

### Barber Management (Static Only)
- `POST /api/barbers/login` - Barber authentication
- `POST /api/barbers/register` - Register new barber
- `GET /api/barbers/shop/{shop_id}` - Get barbers for a shop

### Customer Management
- `POST /api/customers/register` - Register new customer
- `GET /api/customers/{phone}` - Get customer details
- `POST /api/customers/verify` - Verify customer phone

### Visit Management
- `POST /api/visits/enter` - Customer enters shop
- `POST /api/visits/start/{visit_id}` - Start service
- `POST /api/visits/complete/{visit_id}` - Complete visit
- `GET /api/visits/customer/{customer_id}` - Get customer visit history

### Queue Management
- `GET /api/queue/shop/{shop_id}` - Get current queue
- `POST /api/queue/join` - Join queue
- `DELETE /api/queue/leave/{visit_id}` - Leave queue

### SignalR Events
- `QueueUpdate` - Queue position changes
- `VisitStatusUpdate` - Visit status updates
- `BarberAvailable` - Barber availability changes

## Installation & Setup

1. Create new .NET Core Web API project:
```bash
dotnet new webapi -n BarberShop.API
cd BarberShop.API
```

2. Install required NuGet packages:
```bash
dotnet add package MongoDB.Driver
dotnet add package Microsoft.AspNetCore.SignalR
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.Extensions.Configuration
dotnet add package System.ComponentModel.Annotations
dotnet add package GeoCoordinate.NetCore
```

3. Setup environment variables (appsettings.json):
```json
{
  "MongoDB": {
    "ConnectionString": "mongodb+srv://username:password@cluster.mongodb.net/barber_shop?retryWrites=true&w=majority",
    "DatabaseName": "barber_shop"
  },
  "Jwt": {
    "Key": "your-secret-key-here",
    "Issuer": "BarberShop.API",
    "Audience": "BarberShop.Client",
    "ExpireMinutes": 30
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

4. Run the application:
```bash
dotnet run
```

5. Access the API:
- API Base URL: https://localhost:5001 or http://localhost:5000
- Swagger UI: https://localhost:5001/swagger

## Project Structure
```
BarberShop.API/
├── Controllers/
│   ├── ShopsController.cs
│   ├── BarbersController.cs
│   ├── CustomersController.cs
│   ├── VisitsController.cs
│   └── QueueController.cs
├── Models/
│   ├── Entities/
│   │   ├── Shop.cs
│   │   ├── Barber.cs
│   │   ├── Customer.cs
│   │   ├── Visit.cs
│   │   └── Queue.cs
│   └── DTOs/
├── Services/
│   ├── IMongoService.cs
│   ├── MongoService.cs
│   ├── IAuthService.cs
│   ├── AuthService.cs
│   └── LocationService.cs
├── Hubs/
│   └── BarberShopHub.cs
├── Configuration/
│   └── MongoConfiguration.cs
├── Program.cs
├── appsettings.json
└── BarberShop.API.csproj
```