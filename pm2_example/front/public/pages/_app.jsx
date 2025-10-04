import React from 'react';
import { Toaster } from 'react-hot-toast';

export default function MyApp({ Component, pageProps }) {
  return (
    <>
      <Toaster position="top-right" />
      <Component {...pageProps} />
      <style jsx global>{`
        body { font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen,
          Ubuntu, Cantarell, 'Fira Sans', 'Droid Sans', 'Helvetica Neue', sans-serif;
          margin: 0; padding: 0; background: #f5f5f5; }
        .container { max-width: 800px; margin: 40px auto; background: #fff; padding: 24px; border-radius: 12px; box-shadow: 0 2px 12px rgba(0,0,0,0.06); }
        h1 { margin-top: 0; }
        ul { padding-left: 20px; }
        .colors { display: flex; flex-wrap: wrap; gap: 10px; }
        .color { padding: 8px 12px; border-radius: 8px; background: #eee; }
        .header { display: flex; align-items: center; justify-content: space-between; }
        .hint { color: #666; font-size: 14px; }
        .row { display: flex; align-items: center; gap: 10px; }
        code { background: #f0f0f0; padding: 2px 6px; border-radius: 4px; }
      `}</style>
    </>
  );
}
