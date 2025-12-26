import { useEffect, useState } from "react";
import { getGames } from "../api/gamesAPI";

export default function GamesList() {
  const [games, setGames] = useState([]);

  useEffect(() => {
    getGames().then(setGames);
  }, []);

  return (
    <div>
      <h1>Games</h1>
      <ul>
        {games.map(g => (
          <li key={g.id}>{g.id} - {g.title} - {g.genre} - Released: {g.releaseDate}</li>
        ))}
      </ul>
    </div>
  );
}