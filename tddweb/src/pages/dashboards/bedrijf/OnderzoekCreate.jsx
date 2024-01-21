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
    titel: "",
    beschrijving: "",
    bedrijfMail: decodedToken.email,
    begindatum: "2024-01-18",
    einddatum: "2024-01-18",
    locatie: {
      postCode: "",
      plaatsNaam: "",
      straatNaam: "",
      huisnummer: 0,
    },
    beloningBeschrijving: "",
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
      <h1 className="text-2xl font-bold mb-4">Onderzoek creeeren</h1>
      <form onSubmit={handleCreate}>
        <label className="block mb-2">
          Titel:
          <input
            type="text"
            name="titel"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
            value={onderzoekData.titel}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label className="block mb-2">
          Beschrijving:
          <textarea
            name="beschrijving"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
            value={onderzoekData.beschrijving}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label className="block mb-2">
          Begindatum:
          <input
            type="date"
            name="begindatum"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
            value={onderzoekData.begindatum}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label className="block mb-2">
          Einddatum:
          <input
            type="date"
            name="einddatum"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
            value={onderzoekData.einddatum}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <label className="block mb-2">
          Postcode:
          <input
            type="text"
            name="postCode"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
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
        <label className="block mb-2">
          Plaatsnaam:
          <input
            type="text"
            name="plaatsNaam"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
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
        <label className="block mb-2">
          Straatnaam:
          <input
            type="text"
            name="straatNaam"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
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
        <label className="block mb-2">
          Huisnummer:
          <input
            type="number"
            name="huisnummer"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
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
        <label className="block mb-2">
          Beloning Beschrijving:
          <input
            type="text"
            name="beloningBeschrijving"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
            value={onderzoekData.beloningBeschrijving}
            onChange={handleInputChange}
          />
        </label>
        <br />
        <button
          type="submit"
          className="w-full bg-accessblue hover: text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue"
        >
          Verder
        </button>
      </form>
    </div>
  );

}
