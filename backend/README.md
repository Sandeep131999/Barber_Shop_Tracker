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

##  Core Design Principles

* **No customer app, no QR scanning**
* **No GPS or location enforcement**
* **One active visit per person per shop**
* **Staff controls customer entry, presence, and flow**
* **System reflects reality, does not dictate it**


## 🧱 Tech Stack

* **Framework**: ASP.NET Core Web API (.NET 9)
* **Database**: PostgreSQL
* **ORM**: Dapper / EF Core (Next Phase)
* **Real-time**: SignalR
* **API Docs**: Swagger
* **Authentication**: JWT (Barber / Staff only)
* **Deployment**: Docker

* [ ] Create customer (phone optional)
* [ ] Create walk-in / temporary customer
* [ ] Prevent duplicate **active visits**
* [ ] Fetch visit history




