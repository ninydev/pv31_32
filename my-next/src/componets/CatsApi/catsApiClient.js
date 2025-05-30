'use server';

const CATS_API_KEY = 'live_0HN8uL4Aeoujin4RY2uUVi12QRbJIAC97LL9YbPJ93QKJPK7wEELYmI13aJiJmUU';
const CATS_BASE_URL = 'https://api.thecatapi.com/v1/images/search';

export async function catsApiClient(searchParams = {}) {
    // Set default values for searchParams if not provided
    if (!('limit' in searchParams)) { searchParams.limit = '5'; }
    if (!('page' in searchParams)) { searchParams.page = '0'; }
    if (!('order' in searchParams)) { searchParams.order = 'RANDOM'; }
    if (!('has_breeds' in searchParams)) { searchParams.has_breeds = 'true'; }

    // Create URL with search parameters
    let urlSearchParams = new URLSearchParams(searchParams);
    const urlWithParams = `${CATS_BASE_URL}?${urlSearchParams.toString()}`;

    // Fetch data from the API
    const response = await fetch(urlWithParams, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'x-api-key': CATS_API_KEY
        },
        // Next.js specific options for server-side fetching
        cache: 'no-store' // Disable caching for fresh data each request
    });

    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }

    return response.json();
}