# Backend – Barber Shop Tracker

A **real-time barber shop tracking backend** designed to mirror how an actual barber shop works.
The system is **staff-controlled**, inclusive for **children, elderly, uneducated people, and customers without smartphones**, and powers a **live visual barber shop layout**.


## 🎯 Project Goal

Build a backend system that:

* Tracks customers, barbers, and queues in **real time**
* Displays a **live barber shop layout** (chairs, customers, waiting time)
* Avoids duplicate registrations **without using GPS or customer apps**
* Works for **walk-ins, kids, elderly, and no-phone users**
* Keeps control strictly with **barbers / shop staff**

## 🧠 Core Design Principles

* **No customer app, no QR scanning**
* **No GPS or location enforcement**
* **One active visit per person per shop**
* **Staff controls customer entry, presence, and flow**
* **System reflects reality, does not dictate it**


## 🧱 Tech Stack

* **Framework**: ASP.NET Core Web API (.NET)
* **Database**: PostgreSQL
* **ORM**: Dapper / EF Core (Next Phase)
* **Real-time**: SignalR
* **API Docs**: OpenAPI (Swagger)
* **Authentication**: JWT (Barber / Staff only)
* **Deployment**: Docker


## 🗂 Backend TODO List

### #Todo1: Project Setup

* [ ] Initialize ASP.NET Core Web API
* [ ] Apply Clean Architecture structure
* [ ] Configure PostgreSQL connection
* [ ] Enable OpenAPI (Swagger)
* [ ] Environment-based configuration


### #Todo2: Domain & Database Design

* [ ] Shops
* [ ] Barbers
* [ ] Customers (registered & temporary)
* [ ] Visits (active & historical)
* [ ] Queue management
* [ ] Presence tracking

---

### #Todo3: API Endpoints

#### Customer & Walk-in Management

* [ ] Create customer (phone optional)
* [ ] Create walk-in / temporary customer
* [ ] Prevent duplicate **active visits**
* [ ] Fetch visit history

#### Barber Management

* [ ] Barber authentication
* [ ] Barber availability status
* [ ] Barber-chair mapping

#### Visit & Queue Management

* [ ] Customer entry (staff only)
* [ ] Join queue
* [ ] Mark customer as TEMP_OUT
* [ ] Skip / No-show handling
* [ ] Start service
* [ ] Complete service

---

### #Todo4: Real-Time Barber Layout

* [ ] Live queue updates
* [ ] Barber chair status updates
* [ ] Customer movement (waiting → service)
* [ ] Live waiting time calculation

---

### #Todo5: SignalR Implementation

* [ ] SignalR Hub setup
* [ ] Queue update broadcasting
* [ ] Visit status updates
* [ ] Barber availability events
* [ ] Auto-sync for new clients

---

### #Todo6: Business Logic

#### Visit Lifecycle

```
ENTER → WAITING → IN_SERVICE → COMPLETED
```

#### Presence States

```
PRESENT
TEMP_OUT
NO_SHOW
```

Rules:

* Only **one active visit** (WAITING / IN_SERVICE) per person per shop
* TEMP_OUT customers are skipped but not removed
* Repeated skips can mark customer as NO_SHOW
* Staff always controls state changes

---

### #Todo7: Analytics & Reporting

* [ ] Visit history
* [ ] Average waiting time
* [ ] Peak hours
* [ ] Barber performance
* [ ] Daily shop summary

---

### #Todo8: Security & Validation

* [ ] Input validation
* [ ] JWT-based barber authentication
* [ ] Role-based access (Staff / Admin)
* [ ] Rate limiting
* [ ] Centralized error handling

---

### #Todo9: Testing

* [ ] Unit tests (Domain & Services)
* [ ] Integration tests (Visit flow)
* [ ] SignalR hub tests
* [ ] Database integration tests

---

### #Todo10: Deployment Setup

* [ ] Dockerfile
* [ ] Docker Compose (API + PostgreSQL)
* [ ] Environment variable configuration
* [ ] Production performance tuning

---

## 🗄 Database Schema (High-Level)

### Customers

* `id` (UUID)
* `display_name`
* `phone` (nullable)
* `is_temporary`
* `created_at`

### Barbers

* `id` (UUID)
* `name`
* `chair_number`
* `status` (AVAILABLE, BUSY)

### Visits

* `id` (UUID)
* `customer_id`
* `barber_id` (nullable)
* `shop_id`
* `status` (WAITING, IN_SERVICE, COMPLETED, CANCELLED)
* `presence_status` (PRESENT, TEMP_OUT, NO_SHOW)
* `joined_at`
* `started_at`
* `completed_at`

> **Database rule**: Only one active visit per customer per shop
> (enforced via partial unique index)

---

## 🌐 API Endpoints (Draft)

### Customer

* `POST /api/customers`
* `GET /api/customers/{id}`
* `GET /api/customers/{id}/visits`

### Visits

* `POST /api/visits/enter`
* `POST /api/visits/temp-out/{visitId}`
* `POST /api/visits/start/{visitId}`
* `POST /api/visits/complete/{visitId}`
* `POST /api/visits/no-show/{visitId}`

### Queue

* `GET /api/queue/shop/{shopId}`
* `POST /api/queue/reorder`

---

## 🔴 SignalR Events

* `QueueUpdated`
* `VisitStatusChanged`
* `PresenceChanged`
* `BarberStatusChanged`
* `WaitingTimeUpdated`

---

## ⚙ Installation & Setup

### 1. Create Project

```bash
dotnet new webapi -n BarberShop.API
cd BarberShop.API
```

### 2. Install Packages

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.AspNetCore.SignalR
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Swashbuckle.AspNetCore
```

### 3. App Settings (PostgreSQL)

```json
{
  "Postgres": {
    "ConnectionString": "Host=localhost;Port=5432;Database=barbershop;Username=postgres;Password=password"
  },
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "BarberShop.API",
    "Audience": "BarberShop.Client",
    "ExpireMinutes": 60
  }
}
```

---

## 📂 Clean Architecture Structure

```
backend/
 ├── API
 │   ├── Controllers
 │   ├── Hubs
 │   ├── DTOs
 │   └── Program.cs
 ├── Application
 │   ├── Interfaces
 │   ├── Services
 │   └── Validators
 ├── Domain
 │   ├── Entities
 │   └── Enums
 ├── Infrastructure
 │   ├── Data
 │   ├── Repositories
 │   └── SignalR
 └── Tests
```

---

## 🏁 Final Note

This backend is intentionally designed to:

* Match **real barber shop behavior**
* Be **inclusive and simple**
* Support **real-time visual layouts**
* Scale from **single shop to multiple branches**

> **Barbers control reality.
> The system reflects reality.**

---

🚀 **Next possible steps**:

* Real-time UI wireframe
* SignalR hub implementation
* Queue algorithm
* PostgreSQL index & constraint design
