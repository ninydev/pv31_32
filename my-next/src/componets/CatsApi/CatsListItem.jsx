'use client';

import Image from 'next/image';

export function CatsListItem({ cat }) {
    return (
        <li className="mb-4">
            {/* Using Next.js Image component for optimized image loading */}
            <div className="relative w-[200px] h-[150px] mb-2">
                <Image 
                    src={cat.url} 
                    alt={cat.breeds.length > 0 ? cat.breeds[0].name : 'Cat'} 
                    fill
                    style={{ objectFit: 'cover' }}
                    sizes="200px"
                />
            </div>
            <p className="text-sm">
                <strong>Breed:</strong> {cat.breeds.length > 0 ? cat.breeds[0].name : 'Unknown'}
            </p>
        </li>
    );
}