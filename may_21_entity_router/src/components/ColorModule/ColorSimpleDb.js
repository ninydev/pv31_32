// ColorSimpleDb.js - Simple in-memory database for color entities

// Import UUID library for generating unique IDs
import { v4 as uuidv4 } from 'uuid';

// In-memory storage for color entities
let colors = [];

/**
 * Color entity model with fields:
 * - id: UUID
 * - name: string
 * - rgb: string (e.g., "#RRGGBB")
 * - createdAt: Date
 */

/**
 * Create a new color entity
 * @param {Object} colorData - Color data (name, rgb)
 * @returns {Object} Created color entity
 */
export function create(colorData) {
  const newColor = {
    id: uuidv4(),
    name: colorData.name,
    rgb: colorData.rgb,
    createdAt: new Date()
  };
  
  colors.push(newColor);
  return newColor;
}

/**
 * Read all color entities
 * @returns {Array} Array of all color entities
 */
export function readAll() {
  return [...colors]; // Return a copy to prevent direct modification
}

/**
 * Read a color entity by ID
 * @param {string} id - Color entity ID
 * @returns {Object|null} Color entity or null if not found
 */
export function readById(id) {
  return colors.find(color => color.id === id) || null;
}

/**
 * Update a color entity
 * @param {string} id - Color entity ID
 * @param {Object} colorData - Updated color data (name, rgb)
 * @returns {Object|null} Updated color entity or null if not found
 */
export function update(id, colorData) {
  const index = colors.findIndex(color => color.id === id);
  
  if (index === -1) {
    return null;
  }
  
  // Update only the provided fields, keep the original id and createdAt
  colors[index] = {
    ...colors[index],
    name: colorData.name !== undefined ? colorData.name : colors[index].name,
    rgb: colorData.rgb !== undefined ? colorData.rgb : colors[index].rgb
  };
  
  return colors[index];
}

/**
 * Delete a color entity by ID
 * @param {string} id - Color entity ID
 * @returns {boolean} True if deleted, false if not found
 */
export function deleteById(id) {
  const index = colors.findIndex(color => color.id === id);
  
  if (index === -1) {
    return false;
  }
  
  colors.splice(index, 1);
  return true;
}