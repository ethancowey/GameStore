const API_URL = "http://localhost:5000/api/videogames";

export async function getGames() {
  const response = await fetch(API_URL);
  return response.json();
}

export async function getGameById(id) {
  const response = await fetch(`${API_URL}/${id}`);
  return response.json();
}

export async function createGame(gameData) {
  const response = await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(gameData),
  });
  return response.json();
}

export async function deleteGame(id) {
  const response = await fetch(`${API_URL}/${id}`, {
    method: "DELETE",
  });
   if (!response.ok) {
    throw new Error(`Failed to delete game: ${response.status}`);
  }
  return true;
}