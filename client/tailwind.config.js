/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#0066cc",
        secondary: "#0099ff",
        background: "#1c1c1c",
        contraste: "#2e2e2e",
        destaque: "#f5f5f5",
      }
    },  
  },
  plugins: [],
}