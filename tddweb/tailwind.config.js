/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["index.html", "src/**/*.jsx"],
  theme: {
    extend: {
      colors: {
        'accessblue': '#2B50EC',
        'accessbluedark': '#111E55',
        'accessgreen': '#1CA883',
        'accessbluebg': '#D9EBF7',
        'accessorange': '#FF7D00',
        'accessdarkblue': '#131B56',
        'accessgray': '#dad9da',
        'accessgraybg': '#F4F5FF',
  
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