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
      width: {
        '7/10': '70%',
        '6/10': '60%',
        '12/25': '48%',
      },
      screens: {
        'avg': '1425px',
        'reg': '850px',
        'mini': '490px',
      }
    },
  },
  plugins: [],
};