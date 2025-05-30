import { CatsProvider } from '@/componets/CatsApi/CatsContext';
import { CatsList } from '@/componets/CatsApi/CatsList';
import MainMenu from '@/componets/layout/MainMenu';

export const metadata = {
  title: 'Cats Gallery',
  description: 'A gallery of cat images from The Cat API',
};

export default function CatsPage() {
  return (
    <div className="container mx-auto p-4">
      <MainMenu />
      
      <h1 className="text-3xl font-bold mb-6">Cats Gallery</h1>
      
      {/* Wrap the CatsList component with the CatsProvider */}
      <CatsProvider>
        <CatsList />
      </CatsProvider>
    </div>
  );
}