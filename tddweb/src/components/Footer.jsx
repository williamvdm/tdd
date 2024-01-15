export default function Footer() {
    return (
        <footer className="bg-gray-900 text-white py-12">
  <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
    <div className="flex flex-wrap justify-between">
      {/* Over ons sectie */}
      <div className="w-full md:w-1/4 mb-8">
        <h2 className="text-xl font-bold mb-4">Over Ons</h2>
        <p className="text-sm pr-1">Beknopte beschrijving over jouw organisatie.</p>
      </div>

      {/* Snelle Links sectie */}
      <div className="w-full md:w-1/4 mb-8">
        <h2 className="text-xl font-bold mb-4">Snelle Links</h2>
        <ul>
          <li><a href="/" className="text-sm hover:text-gray-400">Home</a></li>
          <li><a href="/ervaringsdeskundigeportaal" className="text-sm hover:text-gray-400">Ervaringsdeskundige</a></li>
          <li><a href="/bedrijven" className="text-sm hover:text-gray-400">Bedrijven</a></li>
        </ul>
      </div>

      {/* Contactsectie */}
      <div className="w-full md:w-1/4 mb-8">
        <h2 className="text-xl font-bold mb-4">Contact</h2>
        <p className="text-sm">123 Straatnaam<br />Plaats, Land<br />Email: voorbeeld@voorbeeld.com<br />Telefoon: +123456789</p>
      </div>

      {/* Volg Ons sectie */}
      <div className="w-full md:w-1/4 mb-8">
        <h2 className="text-xl font-bold mb-4">Volg Ons</h2>
        <div className="flex space-x-4">
          {/* Voeg hier je social media iconen toe */}
        </div>
      </div>
    </div>
  </div>
</footer>

        
    )
};

