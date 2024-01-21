import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { jwtDecode } from "jwt-decode";


export default function OnderzoekCreate() {
  let navigate = useNavigate();

  const token = localStorage.getItem("token")
    let decodedToken = null;
    if (token) {
        decodedToken = jwtDecode(token);
    }


  const [onderzoekData, setOnderzoekData] = useState({
    titel: "Voer een titel in",
    beschrijving: "Voer een beschrijving in",
    bedrijfMail: decodedToken.email,
    begindatum: "2024-01-18",
    einddatum: "2024-01-18",
    locatie: {
      postCode: "1234AB",
      plaatsNaam: "Voer plaatsnaam in",
      straatNaam: "Voer straatnaam in",
      huisnummer: 0,
    },
    beloningBeschrijving: "Geef een beloning op",
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setOnderzoekData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleCreate = async (event) => {
    event.preventDefault();
    console.log("Formulier verzonden");

    try {
      const response = await fetch(
        "http://localhost/api/Onderzoek/create",
        {
          method: "POST",
          body: JSON.stringify(onderzoekData),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
          },
        }
      );

      if (response.status === 200) {
        response.json().then((result) => {
          const id = result.id;
          navigate(`/onderzoek/edit/${id}`);
        });
      } else {
        console.error("Iets klopt niet");
      }
    } catch (error) {
      console.error("Verbinding met endpoint mislukt", error);
    }
  };

  return (
    <div className="container mx-auto my-10 p-6 bg-white border border-gray-300 rounded-lg shadow-lg max-w-screen-md">
      <form onSubmit={handleCreate}>
        <label>
          Titel:
          <input
            type="text"
            name="titel"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.titel}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Beschrijving:
          <textarea
            name="beschrijving"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.beschrijving}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Begindatum:
          <input
            type="date"
            name="begindatum"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.begindatum}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Einddatum:
          <input
            type="date"
            name="einddatum"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.einddatum}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label>
          Postcode:
          <input
            type="text"
            name="postCode"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.locatie.postCode}
            onChange={(e) =>
              setOnderzoekData((prevData) => ({
                ...prevData,
                locatie: { ...prevData.locatie, postCode: e.target.value },
              }))
            }
          />
        </label>
        <br />
        <label>
          Plaatsnaam:
          <input
            type="text"
            name="plaatsNaam"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.locatie.plaatsNaam}
            onChange={(e) =>
              setOnderzoekData((prevData) => ({
                ...prevData,
                locatie: { ...prevData.locatie, plaatsNaam: e.target.value },
              }))
            }
          />
        </label>
        <br />
        <label>
          Straatnaam:
          <input
            type="text"
            name="straatNaam"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.locatie.straatNaam}
            onChange={(e) =>
              setOnderzoekData((prevData) => ({
                ...prevData,
                locatie: { ...prevData.locatie, straatNaam: e.target.value },
              }))
            }
          />
        </label>
        <br />
        <label>
          Huisnummer:
          <input
            type="number"
            name="huisnummer"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.locatie.huisnummer}
            onChange={(e) =>
              setOnderzoekData((prevData) => ({
                ...prevData,
                locatie: { ...prevData.locatie, huisnummer: e.target.value },
              }))
            }
          />
        </label>
        <br />
        <label>
          Beloning Beschrijving:
          <input
            type="text"
            name="beloningBeschrijving"
            className="border-gray-300 border p-2 rounded"
            value={onderzoekData.beloningBeschrijving}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <button type="submit" className="mr-2 outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue text-black p-2 px-4 rounded-lg transition ease-in-out flex items-center focus:outline-accessblue">Verder</button>
      </form>
    </div>
  );
}
