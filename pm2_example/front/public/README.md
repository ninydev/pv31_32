# Public Frontend (Next.js)

Simple Next.js frontend that shows the list of colors from the API and displays toast notifications from the Socket.IO server on user join/leave.

## Requirements
- Node.js 18+

## Environment
Create or edit `.env.local`:

```
NEXT_PUBLIC_API_URL=http://localhost:4000
NEXT_PUBLIC_SOCKET_URL=http://localhost:5000
```

## Run
```
cd front/public
npm install
npm run dev
# production
npm run build
npm start
```

Open http://localhost:3000

## Notes
- API endpoint used: GET `${NEXT_PUBLIC_API_URL}/colors`
- Socket events handled: `user:joined`, `user:left`, and `welcome`.
