import { useEffect, useState } from "react";
import { getGameById } from "../api/gamesAPI";

export default function GetGame() {
    const [id, setId] = useState("");

    async function handleSubmit(e) {
        e.preventDefault();
        try {
            const game = await getGameById(id);
            alert("Game Found:" + JSON.stringify(game));
        } catch (error) {
            alert("Failed to get game: " + error.message);
        }
    }
    return (
        <div>
            <h2>Get Game By ID</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="number"
                    placeholder="ID"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                />
                <button type="submit">Get Game</button>
            </form>
        </div>
    );
}