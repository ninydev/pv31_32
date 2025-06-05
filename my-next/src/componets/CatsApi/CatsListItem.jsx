'use client';

import Image from 'next/image';
import { useState } from 'react';

export function CatsListItem({ cat }) {
    const [isLoading, setIsLoading] = useState(true);

    return (
        <li className="mb-4">
            {/* Using Next.js Image component for optimized image loading */}
            <div className="relative w-[200px] h-[150px] mb-2">
                {isLoading && (
                    <div className="absolute inset-0 flex items-center justify-center bg-gray-100 dark:bg-gray-800">
                        <div className="animate-spin rounded-full h-10 w-10 border-t-2 border-b-2 border-blue-500"></div>
                    </div>
                )}
                <Image
                    src={cat.url}
                    alt={cat.breeds.length > 0 ? cat.breeds[0].name : 'Cat'}
                    fill
                    style={{ objectFit: 'cover' }}
                    sizes="200px"
                    onLoad={() => setIsLoading(false)}
                />
            </div>
            <p className="text-sm">
                <strong>Breed:</strong> {cat.breeds.length > 0 ? cat.breeds[0].name : 'Unknown'}
            </p>
        </li>
    );
}
