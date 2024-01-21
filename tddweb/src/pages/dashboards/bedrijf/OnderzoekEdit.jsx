import React, { useState, useEffect } from "react";
import { useNavigate, useParams, Link } from "react-router-dom";

// Onderzoek bewerken pagina
export default function OnderzoekEdit() {
  const { onderzoekid } = useParams();
  const [vraag, setVraag] = useState("");
  const [questions, setQuestions] = useState([]);
  const navigate = useNavigate();

  const fetchQuestions = async () => {
    try {
      const response = await fetch(
        `http://localhost/api/Onderzoek/${onderzoekid}/vragen`
      );

      if (response.ok) {
        const data = await response.json();
        setQuestions(data);
      } else {
        console.error("Failed to fetch questions");
      }
    } catch (error) {
      console.error("Connection to the endpoint failed", error);
    }
  };

  useEffect(() => {
    if (onderzoekid) {
      fetchQuestions();
    } else {
      console.error("onderzoekid is undefined");
    }
  }, [onderzoekid]);


  // Een vraag toevoegen aan een onderzoek die je hebt geselecteerd
  const handleAddQuestion = async (event) => {
    event.preventDefault();

    if (onderzoekid) {
      try {
        const response = await fetch(
          `http://localhost/api/Onderzoek/${onderzoekid}/vraag/add`,
          {
            method: "POST",
            body: JSON.stringify({
              vraagID: 0,
              onderzoekID: onderzoekid,
              vraag: vraag,
              antwoorden: [],
            }),
            headers: {
              "Content-type": "application/json; charset=UTF-8",
            },
          }
        );

        if (response.ok) {
          fetchQuestions();
          setVraag("");
        } else {
          console.error("Failed to add question");
        }
      } catch (error) {
        console.error("Connection to the endpoint failed", error);
      }
    } else {
      console.error("onderzoekid is undefined");
    }
  };


  // Een vraar verwijderen van het geselecteerde onderzoek
  const handleDeleteQuestion = async (vraagID) => {
    try {
      const response = await fetch(
        `http://localhost/api/Onderzoek/${onderzoekid}/vraag/delete/${vraagID}`,
        {
          method: "DELETE",
        }
      );

      if (response.ok) {
        fetchQuestions();
      } else {
        console.error("Failed to delete question");
      }
    } catch (error) {
      console.error("Connection to the endpoint failed", error);
    }
  };

  return (
    <div className="container mx-auto my-10 p-6 bg-white border border-gray-300 rounded-lg shadow-lg max-w-screen-md">
      <h1 className="text-2xl font-bold mb-4">Onderzoek bewerken</h1>
      <form onSubmit={handleAddQuestion} className="mb-4">
        <label className="block mb-2">
          Vraag:
          <input
            type="text"
            name="titel"
            className="border p-2 rounded w-full focus:outline-accessblue focus:border-accessblue"
            value={vraag}
            onChange={(e) => setVraag(e.target.value)}
          />
        </label>
        <div className="flex space-x-2">
          <button
            type="submit"
            className="w-1/2 bg-accessblue text-white py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue transition duration-300 ease-in-out"
          >
            Voeg toe
          </button>
          <Link
            to="/dashboard/bedrijf"
            className="w-1/2 bg-white text-black text-center py-2 px-4 rounded outline-none hover:outline-solid hover:outline-2 hover:outline-accessblue transition duration-300 ease-in-out"
          >
            Klaar
          </Link>
        </div>
      </form>

      <div className="mt-4">
        <h2 className="text-lg font-semibold mb-2">Toegevoegde vragen:</h2>
        <ul>
          {questions.map((question) => (
            <li key={question.vraagID} className="flex items-center mb-2">
              <span className="flex-1">{question.vraag}</span>
              <button
                onClick={() => handleDeleteQuestion(question.vraagID)}
                className="text-red-500"
              >
                x
              </button>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}
