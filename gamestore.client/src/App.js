import { Routes, Route } from "react-router-dom";
import logo from './logo.svg';
import './App.css';
import GamesList from './components/GamesList';
import GetGame from './components/GetGameByID';
import AddGame from './components/AddGame';
import RemoveGame from "./components/RemoveGame";

function App() {
  return (
    <Routes>
      <Route path="/" element={<GamesList />} />
      <Route path="/add-game" element={<AddGame />} />
      <Route path="/get-game" element={<GetGame />} />
      <Route path="/remove-game" element={<RemoveGame />} />
    </Routes>
  );
}

export default App;
