/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["index.html", "src/**/*.jsx"],
  theme: {
    extend: {
      colors: {
        'accessblue': '#2B50EC',
        'accessgreen': '#1CA883',
        'accessbluebg': '#D9EBF7',
        'accessorange': '#FF7D00',
        'accessdarkblue': '#131B56',
  
      },
      fontFamily: {
        muli: ['Muli']
      },
      screens: {
        'avg': '1425px',
      }
    },
  },
  plugins: [],
};