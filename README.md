# Barber Shop Real-Time Tracking System

A **real-time barber shop tracking backend** designed to mirror how an actual barber shop works.
The system is **staff-controlled**, inclusive for **children, elderly, uneducated people, and customers without smartphones**, and powers a **live visual barber shop layout**

## Project Structure

barber-shop-tracker/
├── frontend/          # React / Next.js application
├── backend/           # ASP.NET Core 9 (Clean Architecture)
└── README.md

## Tech Stack

### Frontend

* React.js / Next.js
* Canvas / D3.js for live shop visualization
* i18next for multilingual support
* Socket.IO for real-time updates

### Backend

* C# / ASP.NET Core 9 Web API
* Entity Framework Core
* SQL Server / PostgreSQL
* SignalR for real-time communication
* Clean Architecture + Repository Pattern

## Backend Clean Architecture Overview

The backend follows **Clean Architecture**, enforcing strict separation of concerns and dependency rules.


