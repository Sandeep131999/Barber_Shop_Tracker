# Barber Shop Real-Time Tracking System

A comprehensive system for tracking customer entry/exit in barber shops using entry QR codes and location data with real-time visualization.

## Project Structure

```
barber-shop-tracker/
├── frontend/          # React/Next.js application
├── backend/           # Python FastAPI/Flask backend
└── README.md         # This file
```

## Features

Register screen 
- **Real-time customer tracking** SCANNING STATIC QR codes 
--**Enter the phone number 
- **CLICK ON ENTER** CLICK ON ENTER 
- **Live dashboard** showing shop occupancy
- **Multilingual support** (English/Kannada)
- **WebSocket updates** for real-time visualization
--** barber screen 
--** see the que of the customer (using true caller api to display the name and phone number)
--** remarks 
--**give them exit manually by clicking button 

## Tech Stack

### Frontend
- React.js / Next.js
- Canvas / D3.js for visualization
- i18next for multilingual support
- Socket.IO for real-time updates

### Backend
- Python (FastAPI/Flask)
- MongoDB Atlas for data storage
- WebSockets for real-time communication
- Geolocation distance calculations

## Quick Start

1. Clone and navigate to the project
2. Setup frontend (see `frontend/README.md`)
3. Setup backend (see `backend/README.md`)
4. Configure MongoDB Atlas connection
5. Start both services

## Architecture Overview

Customers scan QR codes → Location captured → Backend processes → Real-time dashboard updates

## Future AI Features

- Peak hour prediction using ML
- Customer flow analysis with RNNs
- Chatbot for booking using LLMs
- Natural language query with LangChain

## Deployment

- Frontend: Vercel/Netlify
- Backend: Render/Railway
- Database: MongoDB Atlas (free tier)
