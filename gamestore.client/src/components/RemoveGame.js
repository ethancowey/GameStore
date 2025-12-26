import { useEffect, useState } from "react";
import { deleteGame } from "../api/gamesAPI";

export default function RemoveGame() {
    const [id, setId] = useState("");
    async function handleSubmit(e) {
        e.preventDefault();
        try {
            await deleteGame(id);
            alert("Game removed successfully!");
            setId("");
        } catch (error) {
            alert("Failed to remove game: " + error.message);
        }
    }
    return (
        <div>
            <h2>Remove Game By ID</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="number"
                    placeholder="ID"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                />
                <button type="submit">Remove Game</button>
            </form>
        </div> );
}