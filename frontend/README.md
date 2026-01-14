# Frontend - Barber Shop Tracker

React/Next.js frontend for real-time barber shop visualization and customer interaction.

## Tech Stack
- **Framework**: Next.js 14+
- **Language**: TypeScript
- **Styling**: Tailwind CSS
- **Visualization**: Canvas API / D3.js
- **Internationalization**: i18next
- **Real-time**: Socket.IO Client
- **QR Codes**: qrcode.js

## Frontend TODO List

### #Todo1: Project Setup
- [ ] Initialize Next.js project with TypeScript
- [ ] Setup Tailwind CSS configuration
- [ ] Install required dependencies
- [ ] Configure project structure

### #Todo2: Internationalization Setup
- [ ] Install and configure i18next
- [ ] Create translation files for English
- [ ] Create translation files for Kannada
- [ ] Implement language toggle component
- [ ] Add RTL/LTR support if needed

### #Todo3: QR Code System
- [ ] Install QR code generation library
- [ ] Create QR code display component
- [ ] Implement QR code scanning (camera access)
- [ ] Handle QR scan results
- [ ] Design QR entry/exit flow UI

### #Todo4: Geolocation Integration
- [ ] Implement browser Geolocation API
- [ ] Handle location permissions
- [ ] Create location tracking service
- [ ] Implement periodic location updates
- [ ] Add location error handling

### #Todo5: Real-time Dashboard
- [ ] Setup Socket.IO client connection
- [ ] Create WebSocket event handlers
- [ ] Design shop layout visualization
- [ ] Implement seat status display
- [ ] Add real-time customer movement

### #Todo6: Canvas Visualization
- [ ] Create Canvas-based shop floor plan
- [ ] Draw barber chairs and waiting area
- [ ] Implement customer avatars
- [ ] Add animations for customer movement
- [ ] Handle responsive canvas sizing

### #Todo7: UI Components
- [ ] Design main dashboard layout
- [ ] Create customer information cards
- [ ] Implement shop statistics display
- [ ] Add loading states and spinners
- [ ] Create error boundary components

### #Todo8: State Management
- [ ] Setup React Context for global state
- [ ] Manage customer data state
- [ ] Handle WebSocket connection state
- [ ] Implement language preference state
- [ ] Add location tracking state

### #Todo9: API Integration
- [ ] Create API service layer
- [ ] Implement QR code API calls
- [ ] Handle location update API calls
- [ ] Add error handling for API failures
- [ ] Implement retry logic

### #Todo10: Responsive Design
- [ ] Mobile-first responsive design
- [ ] Tablet layout optimizations
- [ ] Desktop layout enhancements
- [ ] Touch gesture support
- [ ] Accessibility features

### #Todo11: Performance Optimization
- [ ] Implement code splitting
- [ ] Optimize Canvas rendering
- [ ] Add image lazy loading
- [ ] Implement caching strategies
- [ ] Reduce bundle size

### #Todo12: Testing
- [ ] Unit tests for components
- [ ] Integration tests for API calls
- [ ] WebSocket connection tests
- [ ] E2E tests for user flows
- [ ] Accessibility testing

## Component Structure

```
src/
├── components/
│   ├── common/
│   │   ├── LanguageToggle.tsx
│   │   ├── LoadingSpinner.tsx
│   │   └── ErrorBoundary.tsx
│   ├── qr/
│   │   ├── QRGenerator.tsx
│   │   ├── QRScanner.tsx
│   │   └── QRDisplay.tsx
│   ├── dashboard/
│   │   ├── ShopLayout.tsx
│   │   ├── SeatStatus.tsx
│   │   └── CustomerAvatar.tsx
│   └── location/
│       ├── LocationTracker.tsx
│       └── PermissionRequest.tsx
├── hooks/
│   ├── useWebSocket.ts
│   ├── useGeolocation.ts
│   └── useTranslation.ts
├── services/
│   ├── api.ts
│   ├── websocket.ts
│   └── location.ts
├── utils/
│   ├── constants.ts
│   ├── helpers.ts
│   └── calculations.ts
└── types/
    ├── customer.ts
    ├── shop.ts
    └── api.ts
```

## Key Features Implementation

### 1. Language Toggle
```typescript
// Language toggle component with English/Kannada support
const LanguageToggle = () => {
  const { i18n } = useTranslation();
  
  const changeLanguage = (lng: string) => {
    i18n.changeLanguage(lng);
  };
  
  return (
    <div>
      <button onClick={() => changeLanguage('en')}>English</button>
      <button onClick={() => changeLanguage('kn')}>ಕನ್ನಡ</button>
    </div>
  );
};
```

### 2. QR Code Flow
```typescript
// QR code scanning and processing
const QRScanner = () => {
  const [scanResult, setScanResult] = useState<string>('');
  
  const handleScan = async (data: string) => {
    // Process QR scan result
    await processQRScan(data);
  };
  
  return (
    <div>
      {/* QR scanner UI */}
    </div>
  );
};
```

### 3. Real-time Visualization
```typescript
// Canvas-based shop visualization
const ShopLayout = () => {
  const canvasRef = useRef<HTMLCanvasElement>(null);
  const { customers } = useShopState();
  
  useEffect(() => {
    drawShopLayout(canvasRef.current, customers);
  }, [customers]);
  
  return <canvas ref={canvasRef} />;
};
```

## Installation & Setup

1. Create Next.js project:
```bash
npx create-next-app@latest barber-shop-frontend --typescript --tailwind --eslint
```

2. Install dependencies:
```bash
npm install socket.io-client i18next react-i18next next-i18next qrcode geolocation-api
```

3. Setup environment variables:
```bash
NEXT_PUBLIC_WS_URL=ws://localhost:3001
NEXT_PUBLIC_API_URL=http://localhost:8000
```

4. Run development server:
```bash
npm run dev
```

## Translation Files Structure

### public/locales/en/common.json
```json
{
  "welcome": "Welcome to Barber Shop",
  "scan_qr": "Scan QR Code to Enter",
  "current_wait": "Current Wait Time",
  "seats_available": "Seats Available"
}
```

### public/locales/kn/common.json
```json
{
  "welcome": "ಬಾರ್ಬರ್ ಅಂಗಡಿಗೆ ಸ್ವಾಗತ",
  "scan_qr": "ಪ್ರವೇಶಿಸಲು QR ಕೋಡ್ ಸ್ಕ್ಯಾನ್ ಮಾಡಿ",
  "current_wait": "ಪ್ರಸ್ತುತ ಕಾಯುವ ಸಮಯ",
  "seats_available": "ಲಭ್ಯವಿರುವ ಸ್ಥಾನಗಳು"
}
```
