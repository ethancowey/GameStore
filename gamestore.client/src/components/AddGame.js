import { useEffect, useState } from "react";
import { createGame } from "../api/gamesAPI";
import GamesList from "./GamesList";

export default function AddGame() {
  const [title, setTitle] = useState("");
  const [genre, setGenre] = useState("");
  const [releaseDate, setReleaseDate] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();
    const newGame = { title, genre, releaseDate };
    try{
        await createGame(newGame);
        alert("Game added successfully!");
        setTitle("");
        setGenre("");
        setReleaseDate("");
    }
    catch(error){
        alert("Failed to add game: " + error.message);
    }
}
    return (
        <div>
            <h2>Add New Game</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Title"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Genre"
                    value={genre}
                    onChange={(e) => setGenre(e.target.value)}
                />
                <input
                    type="date"
                    placeholder="Release Date"
                    value={releaseDate}
                    onChange={(e) => setReleaseDate(e.target.value)}
                />
                <button type="submit">Add Game</button>
            </form>
            <GamesList />
        </div>
    );
}