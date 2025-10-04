const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:4000';

// Minimal custom dataProvider for react-admin to read the colors list
// Only implements getList for resource "colors".
const dataProvider = {
  // React-admin calls getList(resource, params)
  async getList(resource, params) {
    if (resource !== 'colors') {
      // Return empty list for unsupported resources
      return { data: [], total: 0 };
    }

    const res = await fetch(`${API_URL}/colors`);
    if (!res.ok) {
      throw new Error(`API error ${res.status}`);
    }
    const json = await res.json();
    const colors = Array.isArray(json.colors) ? json.colors : [];

    // Map to records with id & name fields for react-admin
    const data = colors.map((c, idx) => ({ id: c || idx, name: c }));
    return {
      data,
      total: data.length,
    };
  },

  // Optional stubs for other methods to avoid warnings
  getOne: async () => ({ data: { id: 0 } }),
  getMany: async () => ({ data: [] }),
  getManyReference: async () => ({ data: [], total: 0 }),
  create: async () => ({ data: { id: Date.now() } }),
  update: async () => ({ data: { id: 0 } }),
  updateMany: async () => ({ data: [] }),
  delete: async () => ({ data: { id: 0 } }),
  deleteMany: async () => ({ data: [] }),
};

export default dataProvider;
